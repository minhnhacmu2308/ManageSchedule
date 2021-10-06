namespace ManageSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newngyuen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduleWorks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 255),
                        start = c.Time(nullable: false, precision: 7),
                        endTime = c.Time(nullable: false, precision: 7),
                        date = c.DateTime(nullable: false),
                        purpose = c.String(nullable: false, maxLength: 255),
                        address = c.String(nullable: false, maxLength: 500),
                        note = c.String(),
                        status = c.Int(nullable: false),
                        Merchant_id = c.Int(),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Merchants", t => t.Merchant_id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.Merchant_id)
                .Index(t => t.User_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleWorks", "User_id", "dbo.Users");
            DropForeignKey("dbo.ScheduleWorks", "Merchant_id", "dbo.Merchants");
            DropIndex("dbo.ScheduleWorks", new[] { "User_id" });
            DropIndex("dbo.ScheduleWorks", new[] { "Merchant_id" });
            DropTable("dbo.ScheduleWorks");
        }
    }
}
