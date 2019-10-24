namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPlannedWorkshift : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlannedWorkshifts", "Priority", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlannedWorkshifts", "Priority");
        }
    }
}
