namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorktaskIdToPlanned : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlannedWorkshifts", "IdWorkTask", c => c.Int(nullable: false));
            AddColumn("dbo.Workshifts", "PlannedWorkshiftId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workshifts", "PlannedWorkshiftId");
            DropColumn("dbo.PlannedWorkshifts", "IdWorkTask");
        }
    }
}
