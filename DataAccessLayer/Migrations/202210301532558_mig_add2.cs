namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "UserID", "dbo.Users");
            DropForeignKey("dbo.Headings", "UserID", "dbo.Users");
            DropIndex("dbo.Headings", new[] { "UserID" });
            DropIndex("dbo.Contents", new[] { "UserID" });
            DropColumn("dbo.Headings", "UserID");
            DropColumn("dbo.Contents", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Headings", "UserID", c => c.Int());
            CreateIndex("dbo.Contents", "UserID");
            CreateIndex("dbo.Headings", "UserID");
            AddForeignKey("dbo.Headings", "UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Contents", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
