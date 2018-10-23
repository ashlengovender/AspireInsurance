namespace Projectthree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "CustID", c => c.String(nullable: false, maxLength: 13));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "CustID", c => c.String(nullable: false));
        }
    }
}
