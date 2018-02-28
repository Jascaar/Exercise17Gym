namespace Exercise17Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bugFixing13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GymClasses", "Duration", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GymClasses", "Duration", c => c.Time(nullable: false, precision: 7));
        }
    }
}
