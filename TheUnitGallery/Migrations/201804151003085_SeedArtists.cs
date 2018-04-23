namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedArtists : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Artists (FirstName, LastName, Alias) VALUES ('Benjamin','Button','B. Button')");
            Sql("INSERT INTO Artists (FirstName, LastName, Alias) VALUES ('Sarah','Sally','S. Sally')");
            Sql("INSERT INTO Artists (FirstName, LastName, Alias) VALUES ('Jackie','Jones','J. Jones')");
        }
        
        public override void Down()
        {
        }
    }
}
