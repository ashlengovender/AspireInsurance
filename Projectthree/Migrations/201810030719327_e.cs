namespace Projectthree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountViewModels",
                c => new
                    {
                        AccNum = c.String(nullable: false, maxLength: 128),
                        CustID = c.String(nullable: false),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.AccNum);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountViewModels");
        }
    }
}
