namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMediums : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Media (Name, VisibleFrontEnd) VALUES ('Painting', 1)");
            Sql("INSERT INTO Media (Name, VisibleFrontEnd) VALUES ('Statue', 1)");
            Sql("INSERT INTO Media (Name, VisibleFrontEnd) VALUES ('Metalwork', 1)");
        }
        
        public override void Down()
        {
        }
    }
}
