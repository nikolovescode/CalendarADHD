namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGetDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlannedWorkshifts", "DatePlannedWorkshift", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlannedWorkshifts", "DatePlannedWorkshift");
        }
    }
}
