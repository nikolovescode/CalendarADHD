namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkTasks", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkTasks", "Description");
        }
    }
}
