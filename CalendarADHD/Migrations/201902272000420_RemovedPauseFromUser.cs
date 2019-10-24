namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedPauseFromUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CalendarUsers", "LengthOfPausesMin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CalendarUsers", "LengthOfPausesMin", c => c.Int(nullable: false));
        }
    }
}
