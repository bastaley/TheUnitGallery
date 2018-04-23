namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBlocksAndHompage : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Blocks (Name, Content) VALUES ('AboutUs', '<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non semper quam. In hac habitasse platea dictumst. Integer tellus eros, facilisis non diam at, pellentesque vestibulum sapien. Praesent volutpat imperdiet neque, quis pretium orci consectetur eget. Aliquam maximus eu nibh vitae ultricies. Aenean bibendum bibendum laoreet.</p><p> Lorem ipsum dolor sit amet, consectetur adipiscing elit.In scelerisque nibh magna, eu scelerisque lectus blandit eget.Lorem ipsum dolor sit amet, consectetur adipiscing elit.In scelerisque nibh magna, eu scelerisque lectus blandit eget.</p>')");
            Sql("INSERT INTO Pages (Identifier, Title, ContentId) VALUES ('homepage', 'Modern Art By The Unit', 1)");
        }
        
        public override void Down()
        {
        }
    }
}
