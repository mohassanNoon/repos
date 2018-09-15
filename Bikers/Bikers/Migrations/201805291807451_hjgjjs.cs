namespace Bikers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hjgjjs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UpcomingEvents", "Location", c => c.String());
            AddColumn("dbo.UpcomingEvents", "EventDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UpcomingEvents", "EventDate");
            DropColumn("dbo.UpcomingEvents", "Location");
        }
    }
}
