namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddressLine2ColumnInAddressTableTypo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "AddressLine2", c => c.String());
            DropColumn("dbo.Addresses", "AdressLine2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "AdressLine2", c => c.String());
            DropColumn("dbo.Addresses", "AddressLine2");
        }
    }
}
