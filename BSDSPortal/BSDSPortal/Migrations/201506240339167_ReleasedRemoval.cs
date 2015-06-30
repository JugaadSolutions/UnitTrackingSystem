namespace BSDSPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReleasedRemoval : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TestUnits", "ReleasedBy");
            DropColumn("dbo.TestUnits", "ReleasedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestUnits", "ReleasedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.TestUnits", "ReleasedBy", c => c.Int(nullable: false));
        }
    }
}
