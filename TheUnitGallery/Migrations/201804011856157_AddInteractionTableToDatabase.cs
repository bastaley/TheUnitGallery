namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInteractionTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        StaffId = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.StaffId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interactions", "StaffId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Interactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Interactions", new[] { "StaffId" });
            DropIndex("dbo.Interactions", new[] { "CustomerId" });
            DropTable("dbo.Interactions");
        }
    }
}
