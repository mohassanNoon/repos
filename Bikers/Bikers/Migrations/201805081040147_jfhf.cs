namespace Bikers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jfhf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TeamMembers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TeamMembers", "Name", c => c.String());
        }
    }
}
