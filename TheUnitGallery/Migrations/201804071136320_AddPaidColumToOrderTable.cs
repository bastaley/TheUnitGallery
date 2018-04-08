namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaidColumToOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Paid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Paid");
        }
    }
}
