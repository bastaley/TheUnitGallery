namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateToCurrent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Identifier = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        ContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Identifier)
                .ForeignKey("dbo.Blocks", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            AddColumn("dbo.Artworks", "Page_Identifier", c => c.String(maxLength: 128));
            CreateIndex("dbo.Artworks", "Page_Identifier");
            AddForeignKey("dbo.Artworks", "Page_Identifier", "dbo.Pages", "Identifier");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artworks", "Page_Identifier", "dbo.Pages");
            DropForeignKey("dbo.Pages", "ContentId", "dbo.Blocks");
            DropIndex("dbo.Pages", new[] { "ContentId" });
            DropIndex("dbo.Artworks", new[] { "Page_Identifier" });
            DropColumn("dbo.Artworks", "Page_Identifier");
            DropTable("dbo.Pages");
            DropTable("dbo.Blocks");
        }
    }
}
