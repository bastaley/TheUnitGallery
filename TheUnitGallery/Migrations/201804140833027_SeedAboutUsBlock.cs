namespace TheUnitGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAboutUsBlock : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Blocks (Name, Content) VALUES ('AboutUs', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non semper quam. In hac habitasse platea dictumst. Integer tellus eros, facilisis non diam at, pellentesque vestibulum sapien. Praesent volutpat imperdiet neque, quis pretium orci consectetur eget. Aliquam maximus eu nibh vitae ultricies. Aenean bibendum bibendum laoreet. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In scelerisque nibh magna, eu scelerisque lectus blandit eget.')");
        }
        
        public override void Down()
        {
        }
    }
}
