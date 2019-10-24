namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLengthOfWork : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pauses", "CalendarUser_Id", "dbo.CalendarUsers");
            DropForeignKey("dbo.PlannedWorkshifts", "CalendarUser_Id", "dbo.CalendarUsers");
            DropForeignKey("dbo.WorkTasks", "CalendarUser_Id", "dbo.CalendarUsers");
            DropForeignKey("dbo.PlannedWorkshifts", "WorkTask_Id", "dbo.WorkTasks");
            DropForeignKey("dbo.Reminders", "CalendarUser_Id", "dbo.CalendarUsers");
            DropForeignKey("dbo.Workshifts", "CalendarUser_Id", "dbo.CalendarUsers");
            DropForeignKey("dbo.Workshifts", "WorkTask_Id", "dbo.WorkTasks");
            DropForeignKey("dbo.WorkSubtasks", "CalendarUser_Id", "dbo.CalendarUsers");
            DropForeignKey("dbo.WorkSubtasks", "WorkTask_Id", "dbo.WorkTasks");
            DropIndex("dbo.Pauses", new[] { "CalendarUser_Id" });
            DropIndex("dbo.PlannedWorkshifts", new[] { "CalendarUser_Id" });
            DropIndex("dbo.PlannedWorkshifts", new[] { "WorkTask_Id" });
            DropIndex("dbo.WorkTasks", new[] { "CalendarUser_Id" });
            DropIndex("dbo.Reminders", new[] { "CalendarUser_Id" });
            DropIndex("dbo.Workshifts", new[] { "CalendarUser_Id" });
            DropIndex("dbo.Workshifts", new[] { "WorkTask_Id" });
            DropIndex("dbo.WorkSubtasks", new[] { "CalendarUser_Id" });
            DropIndex("dbo.WorkSubtasks", new[] { "WorkTask_Id" });
            CreateTable(
                "dbo.WorkNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleWorkNote = c.String(),
                        TitleWorkTask = c.String(),
                        CalendarUserEmail = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PlannedWorkshifts", "MinutesToWork", c => c.Int(nullable: false));
            AddColumn("dbo.PlannedWorkshifts", "Hour", c => c.Int(nullable: false));
            AddColumn("dbo.PlannedWorkshifts", "Day", c => c.Int(nullable: false));
            AddColumn("dbo.PlannedWorkshifts", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.PlannedWorkshifts", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.PlannedWorkshifts", "Done", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkTasks", "LengthOfPause", c => c.Int(nullable: false));
            AddColumn("dbo.WorkTasks", "LengthOfWork", c => c.Int(nullable: false));
            AddColumn("dbo.Workshifts", "PlannedWorkshiftId", c => c.Int(nullable: false));
            AddColumn("dbo.Workshifts", "TitleWorkshift", c => c.String());
            AddColumn("dbo.Workshifts", "MinutesOnBreak", c => c.Int(nullable: false));
            AddColumn("dbo.Workshifts", "StartedWorking", c => c.DateTime(nullable: false));
            DropColumn("dbo.PlannedWorkshifts", "MinutesWorking");
            DropColumn("dbo.PlannedWorkshifts", "MinuteStartedWorking");
            DropColumn("dbo.PlannedWorkshifts", "HourStartedWorking");
            DropColumn("dbo.PlannedWorkshifts", "DayOfWeek");
            DropColumn("dbo.PlannedWorkshifts", "DatePlannedWorkshift");
            DropColumn("dbo.PlannedWorkshifts", "CalendarUser_Id");
            DropColumn("dbo.PlannedWorkshifts", "WorkTask_Id");
            DropColumn("dbo.WorkTasks", "CalendarUser_Id");
            DropColumn("dbo.Workshifts", "TitleWorkTask");
            DropColumn("dbo.Workshifts", "AverageMinutesOnBreak");
            DropColumn("dbo.Workshifts", "HourStartedWorking");
            DropColumn("dbo.Workshifts", "DayOfWeek");
            DropColumn("dbo.Workshifts", "Emotion");
            DropColumn("dbo.Workshifts", "dateOfWorkshift");
            DropColumn("dbo.Workshifts", "CalendarUser_Id");
            DropColumn("dbo.Workshifts", "WorkTask_Id");
            DropTable("dbo.CalendarUsers");
            DropTable("dbo.Pauses");
            DropTable("dbo.Reminders");
            DropTable("dbo.WorkSubtasks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkSubtasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleSubtask = c.String(),
                        Priority = c.Int(nullable: false),
                        TitleWorkTask = c.String(),
                        CalendarUserEmail = c.String(),
                        CalendarUser_Id = c.Int(),
                        WorkTask_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinBeforeTaskStart = c.Int(nullable: false),
                        CalendarUserEmail = c.String(),
                        CalendarUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pauses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LengthOfPauseMin = c.Int(nullable: false),
                        CalendarUserEmail = c.String(),
                        CalendarUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CalendarUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Workshifts", "WorkTask_Id", c => c.Int());
            AddColumn("dbo.Workshifts", "CalendarUser_Id", c => c.Int());
            AddColumn("dbo.Workshifts", "dateOfWorkshift", c => c.DateTime(nullable: false));
            AddColumn("dbo.Workshifts", "Emotion", c => c.Int(nullable: false));
            AddColumn("dbo.Workshifts", "DayOfWeek", c => c.Int(nullable: false));
            AddColumn("dbo.Workshifts", "HourStartedWorking", c => c.Int(nullable: false));
            AddColumn("dbo.Workshifts", "AverageMinutesOnBreak", c => c.Int(nullable: false));
            AddColumn("dbo.Workshifts", "TitleWorkTask", c => c.String());
            AddColumn("dbo.WorkTasks", "CalendarUser_Id", c => c.Int());
            AddColumn("dbo.PlannedWorkshifts", "WorkTask_Id", c => c.Int());
            AddColumn("dbo.PlannedWorkshifts", "CalendarUser_Id", c => c.Int());
            AddColumn("dbo.PlannedWorkshifts", "DatePlannedWorkshift", c => c.DateTime(nullable: false));
            AddColumn("dbo.PlannedWorkshifts", "DayOfWeek", c => c.Int(nullable: false));
            AddColumn("dbo.PlannedWorkshifts", "HourStartedWorking", c => c.Int(nullable: false));
            AddColumn("dbo.PlannedWorkshifts", "MinuteStartedWorking", c => c.Int(nullable: false));
            AddColumn("dbo.PlannedWorkshifts", "MinutesWorking", c => c.Int(nullable: false));
            DropColumn("dbo.Workshifts", "StartedWorking");
            DropColumn("dbo.Workshifts", "MinutesOnBreak");
            DropColumn("dbo.Workshifts", "TitleWorkshift");
            DropColumn("dbo.Workshifts", "PlannedWorkshiftId");
            DropColumn("dbo.WorkTasks", "LengthOfWork");
            DropColumn("dbo.WorkTasks", "LengthOfPause");
            DropColumn("dbo.PlannedWorkshifts", "Done");
            DropColumn("dbo.PlannedWorkshifts", "Year");
            DropColumn("dbo.PlannedWorkshifts", "Month");
            DropColumn("dbo.PlannedWorkshifts", "Day");
            DropColumn("dbo.PlannedWorkshifts", "Hour");
            DropColumn("dbo.PlannedWorkshifts", "MinutesToWork");
            DropTable("dbo.WorkNotes");
            CreateIndex("dbo.WorkSubtasks", "WorkTask_Id");
            CreateIndex("dbo.WorkSubtasks", "CalendarUser_Id");
            CreateIndex("dbo.Workshifts", "WorkTask_Id");
            CreateIndex("dbo.Workshifts", "CalendarUser_Id");
            CreateIndex("dbo.Reminders", "CalendarUser_Id");
            CreateIndex("dbo.WorkTasks", "CalendarUser_Id");
            CreateIndex("dbo.PlannedWorkshifts", "WorkTask_Id");
            CreateIndex("dbo.PlannedWorkshifts", "CalendarUser_Id");
            CreateIndex("dbo.Pauses", "CalendarUser_Id");
            AddForeignKey("dbo.WorkSubtasks", "WorkTask_Id", "dbo.WorkTasks", "Id");
            AddForeignKey("dbo.WorkSubtasks", "CalendarUser_Id", "dbo.CalendarUsers", "Id");
            AddForeignKey("dbo.Workshifts", "WorkTask_Id", "dbo.WorkTasks", "Id");
            AddForeignKey("dbo.Workshifts", "CalendarUser_Id", "dbo.CalendarUsers", "Id");
            AddForeignKey("dbo.Reminders", "CalendarUser_Id", "dbo.CalendarUsers", "Id");
            AddForeignKey("dbo.PlannedWorkshifts", "WorkTask_Id", "dbo.WorkTasks", "Id");
            AddForeignKey("dbo.WorkTasks", "CalendarUser_Id", "dbo.CalendarUsers", "Id");
            AddForeignKey("dbo.PlannedWorkshifts", "CalendarUser_Id", "dbo.CalendarUsers", "Id");
            AddForeignKey("dbo.Pauses", "CalendarUser_Id", "dbo.CalendarUsers", "Id");
        }
    }
}
