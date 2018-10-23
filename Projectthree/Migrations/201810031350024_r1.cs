namespace Projectthree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccountViewModels", newName: "AccountVMs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AccountVMs", newName: "AccountViewModels");
        }
    }
}
