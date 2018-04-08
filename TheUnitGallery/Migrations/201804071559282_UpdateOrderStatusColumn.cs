namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderStatusColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Paid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Paid", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "OrderStatus");
        }
    }
}
