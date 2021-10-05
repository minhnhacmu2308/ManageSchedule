namespace ManageSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdditionalTimekeepings", "type", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AdditionalTimekeepings", "typeChild", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AdditionalTimekeepings", "typeChild", c => c.Int(nullable: false));
            AlterColumn("dbo.AdditionalTimekeepings", "type", c => c.Int(nullable: false));
        }
    }
}
