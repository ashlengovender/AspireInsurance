namespace Projectthree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class q : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ReportNum = c.Int(nullable: false, identity: true),
                        ClaimPolicyID = c.String(nullable: false),
                        DateOI = c.DateTime(nullable: false),
                        Location = c.String(),
                        DriverName = c.String(),
                        DamageDescription = c.String(),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ReportNum);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        CellNum = c.String(),
                        HomeNum = c.String(),
                        Address = c.String(),
                        Claims_ReportNum = c.Int(),
                        Vehicles_PolicyID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustID)
                .ForeignKey("dbo.Claims", t => t.Claims_ReportNum)
                .ForeignKey("dbo.Vehicles", t => t.Vehicles_PolicyID)
                .Index(t => t.Claims_ReportNum)
                .Index(t => t.Vehicles_PolicyID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        PolicyID = c.String(nullable: false, maxLength: 128),
                        PDriverName = c.String(),
                        PDLicenceNum = c.String(),
                        SDriverName = c.String(),
                        SDLicenceNum = c.String(),
                        Make = c.String(),
                        Model = c.String(),
                        year = c.String(),
                        RegNum = c.String(),
                        VinNum = c.String(),
                        party3 = c.Boolean(nullable: false),
                        Compre = c.Boolean(nullable: false),
                        Engineplan = c.Boolean(nullable: false),
                        writeoff = c.Boolean(nullable: false),
                        Claim_ReportNum = c.Int(),
                    })
                .PrimaryKey(t => t.PolicyID)
                .ForeignKey("dbo.Claims", t => t.Claim_ReportNum)
                .Index(t => t.Claim_ReportNum);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VehiclePricings",
                c => new
                    {
                        PID = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Model = c.String(),
                        year = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Vehicles", "Claim_ReportNum", "dbo.Claims");
            DropForeignKey("dbo.Customers", "Vehicles_PolicyID", "dbo.Vehicles");
            DropForeignKey("dbo.Customers", "Claims_ReportNum", "dbo.Claims");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Vehicles", new[] { "Claim_ReportNum" });
            DropIndex("dbo.Customers", new[] { "Vehicles_PolicyID" });
            DropIndex("dbo.Customers", new[] { "Claims_ReportNum" });
            DropTable("dbo.VehiclePricings");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Customers");
            DropTable("dbo.Claims");
        }
    }
}
