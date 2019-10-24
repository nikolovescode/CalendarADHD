namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAveragePauseOnWorkshift : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workshifts", "AverageMinutesOnBreak", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workshifts", "AverageMinutesOnBreak");
        }
    }
}
