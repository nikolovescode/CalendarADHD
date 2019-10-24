namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateToWorkshift : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workshifts", "dateOfWorkshift", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workshifts", "dateOfWorkshift");
        }
    }
}
