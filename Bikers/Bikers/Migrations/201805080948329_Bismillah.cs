namespace Bikers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bismillah : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Camps",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                        UpdatedOn = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        DeletedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EventName = c.String(),
                        Images = c.String(),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                        UpdatedOn = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        DeletedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Images = c.String(),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                        UpdatedOn = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        DeletedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                        UpdatedOn = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        DeletedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Heading = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                        UpdatedOn = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        DeletedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
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
                "dbo.TeamMembers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Designation = c.String(),
                        Image = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                        UpdatedOn = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        DeletedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.UpcomingEvents",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EventName = c.String(),
                        Images = c.String(),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                        UpdatedOn = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        DeletedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UpcomingEvents", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UpcomingEvents", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UpcomingEvents", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TeamMembers", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TeamMembers", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TeamMembers", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.News", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.News", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.News", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hotels", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hotels", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hotels", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Galleries", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Galleries", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Galleries", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Camps", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Camps", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Camps", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UpcomingEvents", new[] { "DeletedBy" });
            DropIndex("dbo.UpcomingEvents", new[] { "UpdatedBy" });
            DropIndex("dbo.UpcomingEvents", new[] { "CreatedBy" });
            DropIndex("dbo.TeamMembers", new[] { "DeletedBy" });
            DropIndex("dbo.TeamMembers", new[] { "UpdatedBy" });
            DropIndex("dbo.TeamMembers", new[] { "CreatedBy" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.News", new[] { "DeletedBy" });
            DropIndex("dbo.News", new[] { "UpdatedBy" });
            DropIndex("dbo.News", new[] { "CreatedBy" });
            DropIndex("dbo.Hotels", new[] { "DeletedBy" });
            DropIndex("dbo.Hotels", new[] { "UpdatedBy" });
            DropIndex("dbo.Hotels", new[] { "CreatedBy" });
            DropIndex("dbo.Galleries", new[] { "DeletedBy" });
            DropIndex("dbo.Galleries", new[] { "UpdatedBy" });
            DropIndex("dbo.Galleries", new[] { "CreatedBy" });
            DropIndex("dbo.Events", new[] { "DeletedBy" });
            DropIndex("dbo.Events", new[] { "UpdatedBy" });
            DropIndex("dbo.Events", new[] { "CreatedBy" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Camps", new[] { "DeletedBy" });
            DropIndex("dbo.Camps", new[] { "UpdatedBy" });
            DropIndex("dbo.Camps", new[] { "CreatedBy" });
            DropTable("dbo.UpcomingEvents");
            DropTable("dbo.TeamMembers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.News");
            DropTable("dbo.Hotels");
            DropTable("dbo.Galleries");
            DropTable("dbo.Events");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Camps");
        }
    }
}
