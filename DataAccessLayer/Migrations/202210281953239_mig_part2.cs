namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_part2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Partners", "PartnerStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Partners", "PartnerStatus");
        }
    }
}
