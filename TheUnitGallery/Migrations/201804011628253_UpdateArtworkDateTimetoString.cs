namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateArtworkDateTimetoString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artworks", "Year", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artworks", "Year", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
