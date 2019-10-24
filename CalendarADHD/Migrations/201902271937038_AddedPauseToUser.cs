namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPauseToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalendarUsers", "LengthOfPausesMin", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CalendarUsers", "LengthOfPausesMin");
        }
    }
}
