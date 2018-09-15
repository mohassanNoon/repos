namespace Bikers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yuyu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Camps", "Phone", c => c.String());
            AddColumn("dbo.Camps", "Address", c => c.String());
            AddColumn("dbo.Hotels", "Phone", c => c.String());
            AddColumn("dbo.Hotels", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hotels", "Address");
            DropColumn("dbo.Hotels", "Phone");
            DropColumn("dbo.Camps", "Address");
            DropColumn("dbo.Camps", "Phone");
        }
    }
}
