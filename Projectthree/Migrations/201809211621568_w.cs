namespace Projectthree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class w : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutoIds",
                c => new
                    {
                        IdName = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AutoIds");
        }
    }
}
