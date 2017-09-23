namespace Calls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barangays",
                c => new
                    {
                        BarangayId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        City = c.String(nullable: false, maxLength: 25),
                        State = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.BarangayId);
            
            CreateTable(
                "dbo.Calls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CongregationID = c.String(maxLength: 10),
                        Title = c.String(nullable: false, maxLength: 20),
                        nameFirst = c.String(nullable: false, maxLength: 25),
                        nameLast = c.String(maxLength: 25),
                        Street = c.String(maxLength: 50),
                        Barangay = c.String(maxLength: 25),
                        City = c.String(maxLength: 25),
                        State = c.String(maxLength: 25),
                        dateFirstVisit = c.DateTime(nullable: false),
                        dateLastVisit = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 15),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneID = c.Int(nullable: false, identity: true),
                        CallID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneID)
                .ForeignKey("dbo.Calls", t => t.CallID, cascadeDelete: true)
                .Index(t => t.CallID);
            
            CreateTable(
                "dbo.Congregations",
                c => new
                    {
                        CongregationId = c.Int(nullable: false, identity: true),
                        CongregationCode = c.String(maxLength: 10),
                        Name = c.String(maxLength: 25),
                        Street = c.String(maxLength: 50),
                        Barangay = c.String(maxLength: 25),
                        City = c.String(maxLength: 25),
                        State = c.String(maxLength: 25),
                        Country = c.String(maxLength: 25),
                        PostCode = c.String(maxLength: 15),
                        Email = c.String(maxLength: 50),
                        phoneMobile = c.String(maxLength: 20),
                        phoneLandline = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.CongregationId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        SettingId = c.Int(nullable: false, identity: true),
                        CongregationID = c.String(maxLength: 10),
                        InitialScreen = c.Int(),
                    })
                .PrimaryKey(t => t.SettingId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        StatusCode = c.String(maxLength: 10),
                        Description = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.StatusID);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleID = c.Int(nullable: false, identity: true),
                        abbrTitle = c.String(maxLength: 10),
                        fullTitle = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.TitleID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        CountryOfService = c.String(),
                        BirthDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Phones", "CallID", "dbo.Calls");
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Phones", new[] { "CallID" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Titles");
            DropTable("dbo.Status");
            DropTable("dbo.Settings");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Congregations");
            DropTable("dbo.Phones");
            DropTable("dbo.Calls");
            DropTable("dbo.Barangays");
        }
    }
}
