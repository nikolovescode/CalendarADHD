namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringReferenceWorkTaskSubclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkSubtasks", "WorkTaskId", "dbo.WorkTasks");
            DropIndex("dbo.WorkSubtasks", new[] { "WorkTaskId" });
            RenameColumn(table: "dbo.WorkSubtasks", name: "WorkTaskId", newName: "WorkTask_Id");
            AddColumn("dbo.WorkSubtasks", "TitleWorkTask", c => c.String());
            AlterColumn("dbo.WorkSubtasks", "WorkTask_Id", c => c.Int());
            CreateIndex("dbo.WorkSubtasks", "WorkTask_Id");
            AddForeignKey("dbo.WorkSubtasks", "WorkTask_Id", "dbo.WorkTasks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkSubtasks", "WorkTask_Id", "dbo.WorkTasks");
            DropIndex("dbo.WorkSubtasks", new[] { "WorkTask_Id" });
            AlterColumn("dbo.WorkSubtasks", "WorkTask_Id", c => c.Int(nullable: false));
            DropColumn("dbo.WorkSubtasks", "TitleWorkTask");
            RenameColumn(table: "dbo.WorkSubtasks", name: "WorkTask_Id", newName: "WorkTaskId");
            CreateIndex("dbo.WorkSubtasks", "WorkTaskId");
            AddForeignKey("dbo.WorkSubtasks", "WorkTaskId", "dbo.WorkTasks", "Id", cascadeDelete: true);
        }
    }
}
