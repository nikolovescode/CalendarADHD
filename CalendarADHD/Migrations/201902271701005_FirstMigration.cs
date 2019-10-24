namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalendarUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workshifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkTaskId = c.Int(nullable: false),
                        CalendarUserEmail = c.String(),
                        WasEffective = c.Boolean(nullable: false),
                        MinutesWorking = c.Int(nullable: false),
                        HourStartedWorking = c.Int(nullable: false),
                        DayOfWeek = c.Int(nullable: false),
                        Emotion = c.Int(nullable: false),
                        CalendarUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CalendarUsers", t => t.CalendarUser_Id)
                .ForeignKey("dbo.WorkTasks", t => t.WorkTaskId, cascadeDelete: true)
                .Index(t => t.WorkTaskId)
                .Index(t => t.CalendarUser_Id);
            
            CreateTable(
                "dbo.WorkTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleWorkTask = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkSubtasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleSubtask = c.String(),
                        WorkTaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkTasks", t => t.WorkTaskId, cascadeDelete: true)
                .Index(t => t.WorkTaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkSubtasks", "WorkTaskId", "dbo.WorkTasks");
            DropForeignKey("dbo.Workshifts", "WorkTaskId", "dbo.WorkTasks");
            DropForeignKey("dbo.Workshifts", "CalendarUser_Id", "dbo.CalendarUsers");
            DropIndex("dbo.WorkSubtasks", new[] { "WorkTaskId" });
            DropIndex("dbo.Workshifts", new[] { "CalendarUser_Id" });
            DropIndex("dbo.Workshifts", new[] { "WorkTaskId" });
            DropTable("dbo.WorkSubtasks");
            DropTable("dbo.WorkTasks");
            DropTable("dbo.Workshifts");
            DropTable("dbo.CalendarUsers");
        }
    }
}
