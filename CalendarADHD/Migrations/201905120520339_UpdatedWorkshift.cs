namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedWorkshift : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Workshifts", "MinutesOnBreak");
            DropColumn("dbo.Workshifts", "StartedWorking");
            DropColumn("dbo.WorkTasks", "LengthOfPause");
            DropColumn("dbo.WorkTasks", "LengthOfWork");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkTasks", "LengthOfWork", c => c.Int(nullable: false));
            AddColumn("dbo.WorkTasks", "LengthOfPause", c => c.Int(nullable: false));
            AddColumn("dbo.Workshifts", "StartedWorking", c => c.DateTime(nullable: false));
            AddColumn("dbo.Workshifts", "MinutesOnBreak", c => c.Int(nullable: false));
        }
    }
}
