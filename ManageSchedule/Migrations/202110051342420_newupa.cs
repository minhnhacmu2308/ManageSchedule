namespace ManageSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newupa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdditionalTimekeepings", "created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdditionalTimekeepings", "created");
        }
    }
}
