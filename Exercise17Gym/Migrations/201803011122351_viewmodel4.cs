namespace Exercise17Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class viewmodel4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GymClasses", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GymClasses", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
