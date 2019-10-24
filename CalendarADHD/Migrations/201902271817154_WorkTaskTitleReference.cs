namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkTaskTitleReference : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workshifts", "WorkTaskId", "dbo.WorkTasks");
            DropIndex("dbo.Workshifts", new[] { "WorkTaskId" });
            RenameColumn(table: "dbo.Workshifts", name: "WorkTaskId", newName: "WorkTask_Id");
            AddColumn("dbo.Workshifts", "TitleWorkTask", c => c.String());
            AlterColumn("dbo.Workshifts", "WorkTask_Id", c => c.Int());
            CreateIndex("dbo.Workshifts", "WorkTask_Id");
            AddForeignKey("dbo.Workshifts", "WorkTask_Id", "dbo.WorkTasks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workshifts", "WorkTask_Id", "dbo.WorkTasks");
            DropIndex("dbo.Workshifts", new[] { "WorkTask_Id" });
            AlterColumn("dbo.Workshifts", "WorkTask_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Workshifts", "TitleWorkTask");
            RenameColumn(table: "dbo.Workshifts", name: "WorkTask_Id", newName: "WorkTaskId");
            CreateIndex("dbo.Workshifts", "WorkTaskId");
            AddForeignKey("dbo.Workshifts", "WorkTaskId", "dbo.WorkTasks", "Id", cascadeDelete: true);
        }
    }
}
