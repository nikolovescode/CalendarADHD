namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkshiftWorktaskTitleIncluded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workshifts", "TitleWorkTask", c => c.String());
            DropColumn("dbo.Workshifts", "PlannedWorkshiftId");
            DropColumn("dbo.Workshifts", "TitleWorkshift");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workshifts", "TitleWorkshift", c => c.String());
            AddColumn("dbo.Workshifts", "PlannedWorkshiftId", c => c.Int(nullable: false));
            DropColumn("dbo.Workshifts", "TitleWorkTask");
        }
    }
}
