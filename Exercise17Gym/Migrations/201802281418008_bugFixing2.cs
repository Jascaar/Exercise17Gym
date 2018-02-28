namespace Exercise17Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bugFixing2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GymClasses", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.GymClasses", "Description", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GymClasses", "Description", c => c.String());
            AlterColumn("dbo.GymClasses", "Name", c => c.String());
        }
    }
}
