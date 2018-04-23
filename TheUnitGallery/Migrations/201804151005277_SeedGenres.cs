namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name, VisibleFrontEnd) VALUES ('Street', 1)");
            Sql("INSERT INTO Genres (Name, VisibleFrontEnd) VALUES ('Landscape', 1)");
            Sql("INSERT INTO Genres (Name, VisibleFrontEnd) VALUES ('Portrait', 1)");
        }
        
        public override void Down()
        {
        }
    }
}
