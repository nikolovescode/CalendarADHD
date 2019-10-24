namespace CalendarADHD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSettingsPause : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SettingsPauses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinPauseBeforeActivity = c.Int(nullable: false),
                        CalendarUserEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SettingsPauses");
        }
    }
}
