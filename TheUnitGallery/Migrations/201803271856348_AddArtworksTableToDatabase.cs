namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArtworksTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Subject = c.String(),
                        Year = c.DateTime(nullable: false),
                        CostPrice = c.Double(nullable: false),
                        SalesPrice = c.Double(nullable: false),
                        ArtworkStatus = c.Int(nullable: false),
                        Artist_Id = c.Int(nullable: false),
                        Genre_Id = c.Int(),
                        Medium_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.Media", t => t.Medium_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.Medium_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artworks", "Medium_Id", "dbo.Media");
            DropForeignKey("dbo.Artworks", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Artworks", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Artworks", new[] { "Medium_Id" });
            DropIndex("dbo.Artworks", new[] { "Genre_Id" });
            DropIndex("dbo.Artworks", new[] { "Artist_Id" });
            DropTable("dbo.Artworks");
        }
    }
}
