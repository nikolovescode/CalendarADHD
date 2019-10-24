namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserToTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkTasks", "CalendarUserEmail", c => c.String());
            AddColumn("dbo.WorkTasks", "CalendarUser_Id", c => c.Int());
            AddColumn("dbo.WorkSubtasks", "CalendarUserEmail", c => c.String());
            AddColumn("dbo.WorkSubtasks", "CalendarUser_Id", c => c.Int());
            CreateIndex("dbo.WorkTasks", "CalendarUser_Id");
            CreateIndex("dbo.WorkSubtasks", "CalendarUser_Id");
            AddForeignKey("dbo.WorkTasks", "CalendarUser_Id", "dbo.CalendarUsers", "Id");
            AddForeignKey("dbo.WorkSubtasks", "CalendarUser_Id", "dbo.CalendarUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkSubtasks", "CalendarUser_Id", "dbo.CalendarUsers");
            DropForeignKey("dbo.WorkTasks", "CalendarUser_Id", "dbo.CalendarUsers");
            DropIndex("dbo.WorkSubtasks", new[] { "CalendarUser_Id" });
            DropIndex("dbo.WorkTasks", new[] { "CalendarUser_Id" });
            DropColumn("dbo.WorkSubtasks", "CalendarUser_Id");
            DropColumn("dbo.WorkSubtasks", "CalendarUserEmail");
            DropColumn("dbo.WorkTasks", "CalendarUser_Id");
            DropColumn("dbo.WorkTasks", "CalendarUserEmail");
        }
    }
}
