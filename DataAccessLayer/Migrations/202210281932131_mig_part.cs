namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_part : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        PartnerID = c.Int(nullable: false, identity: true),
                        PartnerName = c.String(),
                        PartnerDescription = c.String(),
                        PartnerCountry = c.String(),
                    })
                .PrimaryKey(t => t.PartnerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Partners");
        }
    }
}
