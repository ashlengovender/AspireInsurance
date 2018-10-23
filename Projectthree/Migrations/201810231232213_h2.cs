namespace Projectthree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Claims", "Status", c => c.String());
            AddColumn("dbo.Vehicles", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Status");
            DropColumn("dbo.Claims", "Status");
        }
    }
}
