namespace Bikers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Camps", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Camps", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Camps", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Galleries", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Galleries", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Galleries", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hotels", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hotels", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hotels", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.News", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.News", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.News", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TeamMembers", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TeamMembers", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TeamMembers", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UpcomingEvents", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UpcomingEvents", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UpcomingEvents", "UpdatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Camps", new[] { "CreatedBy" });
            DropIndex("dbo.Camps", new[] { "UpdatedBy" });
            DropIndex("dbo.Camps", new[] { "DeletedBy" });
            DropIndex("dbo.Events", new[] { "CreatedBy" });
            DropIndex("dbo.Events", new[] { "UpdatedBy" });
            DropIndex("dbo.Events", new[] { "DeletedBy" });
            DropIndex("dbo.Galleries", new[] { "CreatedBy" });
            DropIndex("dbo.Galleries", new[] { "UpdatedBy" });
            DropIndex("dbo.Galleries", new[] { "DeletedBy" });
            DropIndex("dbo.Hotels", new[] { "CreatedBy" });
            DropIndex("dbo.Hotels", new[] { "UpdatedBy" });
            DropIndex("dbo.Hotels", new[] { "DeletedBy" });
            DropIndex("dbo.News", new[] { "CreatedBy" });
            DropIndex("dbo.News", new[] { "UpdatedBy" });
            DropIndex("dbo.News", new[] { "DeletedBy" });
            DropIndex("dbo.TeamMembers", new[] { "CreatedBy" });
            DropIndex("dbo.TeamMembers", new[] { "UpdatedBy" });
            DropIndex("dbo.TeamMembers", new[] { "DeletedBy" });
            DropIndex("dbo.UpcomingEvents", new[] { "CreatedBy" });
            DropIndex("dbo.UpcomingEvents", new[] { "UpdatedBy" });
            DropIndex("dbo.UpcomingEvents", new[] { "DeletedBy" });
            AlterColumn("dbo.Camps", "CreatedBy", c => c.String());
            AlterColumn("dbo.Camps", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Camps", "DeletedBy", c => c.String());
            AlterColumn("dbo.Events", "CreatedBy", c => c.String());
            AlterColumn("dbo.Events", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Events", "DeletedBy", c => c.String());
            AlterColumn("dbo.Galleries", "CreatedBy", c => c.String());
            AlterColumn("dbo.Galleries", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Galleries", "DeletedBy", c => c.String());
            AlterColumn("dbo.Hotels", "CreatedBy", c => c.String());
            AlterColumn("dbo.Hotels", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Hotels", "DeletedBy", c => c.String());
            AlterColumn("dbo.News", "CreatedBy", c => c.String());
            AlterColumn("dbo.News", "UpdatedBy", c => c.String());
            AlterColumn("dbo.News", "DeletedBy", c => c.String());
            AlterColumn("dbo.TeamMembers", "CreatedBy", c => c.String());
            AlterColumn("dbo.TeamMembers", "UpdatedBy", c => c.String());
            AlterColumn("dbo.TeamMembers", "DeletedBy", c => c.String());
            AlterColumn("dbo.UpcomingEvents", "CreatedBy", c => c.String());
            AlterColumn("dbo.UpcomingEvents", "UpdatedBy", c => c.String());
            AlterColumn("dbo.UpcomingEvents", "DeletedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UpcomingEvents", "DeletedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.UpcomingEvents", "UpdatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.UpcomingEvents", "CreatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.TeamMembers", "DeletedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.TeamMembers", "UpdatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.TeamMembers", "CreatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.News", "DeletedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.News", "UpdatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.News", "CreatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Hotels", "DeletedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Hotels", "UpdatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Hotels", "CreatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Galleries", "DeletedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Galleries", "UpdatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Galleries", "CreatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "DeletedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "UpdatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "CreatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Camps", "DeletedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Camps", "UpdatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Camps", "CreatedBy", c => c.String(maxLength: 128));
            CreateIndex("dbo.UpcomingEvents", "DeletedBy");
            CreateIndex("dbo.UpcomingEvents", "UpdatedBy");
            CreateIndex("dbo.UpcomingEvents", "CreatedBy");
            CreateIndex("dbo.TeamMembers", "DeletedBy");
            CreateIndex("dbo.TeamMembers", "UpdatedBy");
            CreateIndex("dbo.TeamMembers", "CreatedBy");
            CreateIndex("dbo.News", "DeletedBy");
            CreateIndex("dbo.News", "UpdatedBy");
            CreateIndex("dbo.News", "CreatedBy");
            CreateIndex("dbo.Hotels", "DeletedBy");
            CreateIndex("dbo.Hotels", "UpdatedBy");
            CreateIndex("dbo.Hotels", "CreatedBy");
            CreateIndex("dbo.Galleries", "DeletedBy");
            CreateIndex("dbo.Galleries", "UpdatedBy");
            CreateIndex("dbo.Galleries", "CreatedBy");
            CreateIndex("dbo.Events", "DeletedBy");
            CreateIndex("dbo.Events", "UpdatedBy");
            CreateIndex("dbo.Events", "CreatedBy");
            CreateIndex("dbo.Camps", "DeletedBy");
            CreateIndex("dbo.Camps", "UpdatedBy");
            CreateIndex("dbo.Camps", "CreatedBy");
            AddForeignKey("dbo.UpcomingEvents", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UpcomingEvents", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UpcomingEvents", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TeamMembers", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TeamMembers", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TeamMembers", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.News", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.News", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.News", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Hotels", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Hotels", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Hotels", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Galleries", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Galleries", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Galleries", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Events", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Events", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Events", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Camps", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Camps", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Camps", "CreatedBy", "dbo.AspNetUsers", "Id");
        }
    }
}
