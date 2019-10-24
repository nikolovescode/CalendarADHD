namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskTitleString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkTasks", "TitleWorkTask", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkTasks", "TitleWorkTask", c => c.Int(nullable: false));
        }
    }
}
