namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPriorityToSubtask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkSubtasks", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkSubtasks", "Priority");
        }
    }
}
