namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPauseWotkToTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkTasks", "LengthOfPause", c => c.Int(nullable: false));
            AddColumn("dbo.WorkTasks", "LengthOfWork", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkTasks", "LengthOfWork");
            DropColumn("dbo.WorkTasks", "LengthOfPause");
        }
    }
}
