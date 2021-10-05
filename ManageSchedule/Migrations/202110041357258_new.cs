namespace ManageSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "email", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Merchants", "created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Merchants", "created");
            DropColumn("dbo.Users", "email");
        }
    }
}
