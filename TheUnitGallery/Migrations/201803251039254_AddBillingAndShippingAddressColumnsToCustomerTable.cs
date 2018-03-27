namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillingAndShippingAddressColumnsToCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BillingAddressId", c => c.Int());
            AddColumn("dbo.Customers", "ShippingAddressId", c => c.Int());
            CreateIndex("dbo.Customers", "BillingAddressId");
            CreateIndex("dbo.Customers", "ShippingAddressId");
            AddForeignKey("dbo.Customers", "BillingAddressId", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Customers", "ShippingAddressId", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ShippingAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "BillingAddressId", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "ShippingAddressId" });
            DropIndex("dbo.Customers", new[] { "BillingAddressId" });
            DropColumn("dbo.Customers", "ShippingAddressId");
            DropColumn("dbo.Customers", "BillingAddressId");
        }
    }
}
