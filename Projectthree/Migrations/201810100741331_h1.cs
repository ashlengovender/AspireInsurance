namespace Projectthree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Claims", "CustID", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.Customers", "CustID", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.Customers", "CellNum", c => c.String(maxLength: 10));
            AlterColumn("dbo.Customers", "HomeNum", c => c.String(maxLength: 10));
            AddPrimaryKey("dbo.Customers", "CustID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "HomeNum", c => c.String());
            AlterColumn("dbo.Customers", "CellNum", c => c.String());
            AlterColumn("dbo.Customers", "CustID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Claims", "CustID", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Customers", "CustID");
        }
    }
}
