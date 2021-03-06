namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(nullable: false),
                        AdressLine2 = c.String(),
                        AddressLine3 = c.String(),
                        City = c.String(nullable: false),
                        County = c.String(nullable: false),
                        PostCode = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Addresses");
        }
    }
}
