namespace ManageSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class naa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdditionalTimekeepings", "endTime", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.AdditionalTimekeepings", "end");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdditionalTimekeepings", "end", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.AdditionalTimekeepings", "endTime");
        }
    }
}
