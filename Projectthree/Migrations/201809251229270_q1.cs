namespace Projectthree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class q1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Claims", "CustID", c => c.String(nullable: false));
            AddColumn("dbo.Vehicles", "CustID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "CustID");
            DropColumn("dbo.Claims", "CustID");
        }
    }
}
