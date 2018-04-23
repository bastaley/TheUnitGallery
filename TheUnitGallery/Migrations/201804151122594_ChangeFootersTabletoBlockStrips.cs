namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFootersTabletoBlockStrips : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Footers", newName: "Blockstrips");
            AddColumn("dbo.Blockstrips", "Identifier", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blockstrips", "Identifier");
            RenameTable(name: "dbo.Blockstrips", newName: "Footers");
        }
    }
}
