namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateArtworksTableToTakeForeignIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Artworks", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Artworks", "Medium_Id", "dbo.Media");
            DropIndex("dbo.Artworks", new[] { "Genre_Id" });
            DropIndex("dbo.Artworks", new[] { "Medium_Id" });
            RenameColumn(table: "dbo.Artworks", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.Artworks", name: "Genre_Id", newName: "GenreId");
            RenameColumn(table: "dbo.Artworks", name: "Medium_Id", newName: "MediumId");
            RenameIndex(table: "dbo.Artworks", name: "IX_Artist_Id", newName: "IX_ArtistId");
            AlterColumn("dbo.Artworks", "GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Artworks", "MediumId", c => c.Int(nullable: false));
            CreateIndex("dbo.Artworks", "GenreId");
            CreateIndex("dbo.Artworks", "MediumId");
            AddForeignKey("dbo.Artworks", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Artworks", "MediumId", "dbo.Media", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artworks", "MediumId", "dbo.Media");
            DropForeignKey("dbo.Artworks", "GenreId", "dbo.Genres");
            DropIndex("dbo.Artworks", new[] { "MediumId" });
            DropIndex("dbo.Artworks", new[] { "GenreId" });
            AlterColumn("dbo.Artworks", "MediumId", c => c.Int());
            AlterColumn("dbo.Artworks", "GenreId", c => c.Int());
            RenameIndex(table: "dbo.Artworks", name: "IX_ArtistId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Artworks", name: "MediumId", newName: "Medium_Id");
            RenameColumn(table: "dbo.Artworks", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Artworks", name: "ArtistId", newName: "Artist_Id");
            CreateIndex("dbo.Artworks", "Medium_Id");
            CreateIndex("dbo.Artworks", "Genre_Id");
            AddForeignKey("dbo.Artworks", "Medium_Id", "dbo.Media", "Id");
            AddForeignKey("dbo.Artworks", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
