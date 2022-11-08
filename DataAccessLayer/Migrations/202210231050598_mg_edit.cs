namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galleries", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Galleries", "ImageName");
        }
    }
}
