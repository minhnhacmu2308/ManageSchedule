namespace ManageSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalTimekeepings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.Int(nullable: false),
                        typeChild = c.Int(nullable: false),
                        start = c.Time(nullable: false, precision: 7),
                        end = c.Time(nullable: false, precision: 7),
                        date = c.DateTime(nullable: false),
                        note = c.String(),
                        status = c.Int(nullable: false),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fullName = c.String(nullable: false, maxLength: 255),
                        userName = c.String(nullable: false, maxLength: 255),
                        password = c.String(nullable: false, maxLength: 255),
                        status = c.Int(nullable: false),
                        Role_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Roles", t => t.Role_id)
                .Index(t => t.Role_id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Merchants",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fullName = c.String(nullable: false, maxLength: 255),
                        phoneNumber = c.String(nullable: false, maxLength: 255),
                        email = c.String(nullable: false, maxLength: 255),
                        nameStore = c.String(nullable: false, maxLength: 255),
                        typeMerchant = c.String(nullable: false, maxLength: 255),
                        service = c.String(nullable: false, maxLength: 255),
                        headquarter = c.String(nullable: false, maxLength: 255),
                        status = c.Int(nullable: false),
                        Category_id = c.Int(),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.Category_id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.Category_id)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.CheckIns",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        checkIn = c.Time(nullable: false, precision: 7),
                        checkOut = c.Time(nullable: false, precision: 7),
                        date = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.User_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckIns", "User_id", "dbo.Users");
            DropForeignKey("dbo.Merchants", "User_id", "dbo.Users");
            DropForeignKey("dbo.Merchants", "Category_id", "dbo.Categories");
            DropForeignKey("dbo.AdditionalTimekeepings", "User_id", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_id", "dbo.Roles");
            DropIndex("dbo.CheckIns", new[] { "User_id" });
            DropIndex("dbo.Merchants", new[] { "User_id" });
            DropIndex("dbo.Merchants", new[] { "Category_id" });
            DropIndex("dbo.Users", new[] { "Role_id" });
            DropIndex("dbo.AdditionalTimekeepings", new[] { "User_id" });
            DropTable("dbo.CheckIns");
            DropTable("dbo.Merchants");
            DropTable("dbo.Categories");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.AdditionalTimekeepings");
        }
    }
}
