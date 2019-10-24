namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPausesClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pauses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LengthOfPauseMin = c.Int(nullable: false),
                        CalendarUserEmail = c.String(),
                        CalendarUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CalendarUsers", t => t.CalendarUser_Id)
                .Index(t => t.CalendarUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pauses", "CalendarUser_Id", "dbo.CalendarUsers");
            DropIndex("dbo.Pauses", new[] { "CalendarUser_Id" });
            DropTable("dbo.Pauses");
        }
    }
}
