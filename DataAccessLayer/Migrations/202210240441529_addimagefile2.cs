namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimagefile2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galleries", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Galleries", "ImagePath");
        }
    }
}
