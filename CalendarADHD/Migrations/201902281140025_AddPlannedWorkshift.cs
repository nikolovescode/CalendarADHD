namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlannedWorkshift : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlannedWorkshifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleWorkTask = c.String(),
                        CalendarUserEmail = c.String(),
                        MinutesWorking = c.Int(nullable: false),
                        MinuteStartedWorking = c.Int(nullable: false),
                        HourStartedWorking = c.Int(nullable: false),
                        DayOfWeek = c.Int(nullable: false),
                        CalendarUser_Id = c.Int(),
                        WorkTask_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CalendarUsers", t => t.CalendarUser_Id)
                .ForeignKey("dbo.WorkTasks", t => t.WorkTask_Id)
                .Index(t => t.CalendarUser_Id)
                .Index(t => t.WorkTask_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlannedWorkshifts", "WorkTask_Id", "dbo.WorkTasks");
            DropForeignKey("dbo.PlannedWorkshifts", "CalendarUser_Id", "dbo.CalendarUsers");
            DropIndex("dbo.PlannedWorkshifts", new[] { "WorkTask_Id" });
            DropIndex("dbo.PlannedWorkshifts", new[] { "CalendarUser_Id" });
            DropTable("dbo.PlannedWorkshifts");
        }
    }
}
