namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntStringBugg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkNotes", "CalendarUserEmail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkNotes", "CalendarUserEmail", c => c.Int(nullable: false));
        }
    }
}
