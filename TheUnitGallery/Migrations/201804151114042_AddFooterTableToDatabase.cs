namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFooterTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeftContentId = c.Int(),
                        MiddleContentId = c.Int(),
                        RightContentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blocks", t => t.LeftContentId)
                .ForeignKey("dbo.Blocks", t => t.MiddleContentId)
                .ForeignKey("dbo.Blocks", t => t.RightContentId)
                .Index(t => t.LeftContentId)
                .Index(t => t.MiddleContentId)
                .Index(t => t.RightContentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Footers", "RightContentId", "dbo.Blocks");
            DropForeignKey("dbo.Footers", "MiddleContentId", "dbo.Blocks");
            DropForeignKey("dbo.Footers", "LeftContentId", "dbo.Blocks");
            DropIndex("dbo.Footers", new[] { "RightContentId" });
            DropIndex("dbo.Footers", new[] { "MiddleContentId" });
            DropIndex("dbo.Footers", new[] { "LeftContentId" });
            DropTable("dbo.Footers");
        }
    }
}
