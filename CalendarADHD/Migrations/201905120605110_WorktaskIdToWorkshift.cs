namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorktaskIdToWorkshift : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workshifts", "IdWorkTask", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workshifts", "IdWorkTask");
        }
    }
}
