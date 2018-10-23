namespace Projectthree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountVMs",
                c => new
                    {
                        AccNum = c.Int(nullable: false, identity: true),
                        CustID = c.String(),
                        FirstName = c.String(),
                        Surname = c.String(),
                        PolicyID = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AccNum);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountVMs");
        }
    }
}
