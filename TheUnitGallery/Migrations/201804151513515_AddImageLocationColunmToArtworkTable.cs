namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageLocationColunmToArtworkTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artworks", "IamgeLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artworks", "IamgeLocation");
        }
    }
}
