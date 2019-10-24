namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDetailsOfTask : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.WorkTasks", "LengthOfPause");
            DropColumn("dbo.WorkTasks", "LengthOfWork");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkTasks", "LengthOfWork", c => c.Int(nullable: false));
            AddColumn("dbo.WorkTasks", "LengthOfPause", c => c.Int(nullable: false));
        }
    }
}
