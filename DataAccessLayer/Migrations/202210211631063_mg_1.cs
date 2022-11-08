namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserSurName = c.String(maxLength: 50),
                        UserImage = c.String(maxLength: 2000),
                        UserAbout = c.String(maxLength: 1000),
                        UserMail = c.String(maxLength: 200),
                        UserPassword = c.String(maxLength: 50),
                        UserTitle = c.String(maxLength: 100),
                        UserStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            AddColumn("dbo.Headings", "UserID", c => c.Int());
            AddColumn("dbo.Contents", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Abouts", "Description", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String());
            AlterColumn("dbo.Headings", "HeadingName", c => c.String(maxLength: 500));
            AlterColumn("dbo.Contents", "ContentValue", c => c.String());
            AlterColumn("dbo.Contacts", "UserName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contacts", "UserMail", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contacts", "Subject", c => c.String(maxLength: 80));
            CreateIndex("dbo.Headings", "UserID");
            CreateIndex("dbo.Contents", "UserID");
            AddForeignKey("dbo.Contents", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Headings", "UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headings", "UserID", "dbo.Users");
            DropForeignKey("dbo.Contents", "UserID", "dbo.Users");
            DropIndex("dbo.Contents", new[] { "UserID" });
            DropIndex("dbo.Headings", new[] { "UserID" });
            AlterColumn("dbo.Contacts", "Subject", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "UserMail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "UserName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Contents", "ContentValue", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Headings", "HeadingName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String(maxLength: 200));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Abouts", "Description", c => c.String(maxLength: 1000));
            DropColumn("dbo.Contents", "UserID");
            DropColumn("dbo.Headings", "UserID");
            DropTable("dbo.Users");
        }
    }
}
