namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateArtworkTearLengthMaxTo4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artworks", "Year", c => c.String(maxLength: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artworks", "Year", c => c.String());
        }
    }
}
