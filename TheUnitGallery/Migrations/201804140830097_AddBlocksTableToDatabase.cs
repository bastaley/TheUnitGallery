namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlocksTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blocks",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Blocks");
        }
    }
}
