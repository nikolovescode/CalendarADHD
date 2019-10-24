namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMinutesToPlanned : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlannedWorkshifts", "Minute", c => c.Int(nullable: false));
            DropColumn("dbo.WorkTasks", "CalendarUserEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkTasks", "CalendarUserEmail", c => c.String());
            DropColumn("dbo.PlannedWorkshifts", "Minute");
        }
    }
}
