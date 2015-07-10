namespace BSDSPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finishparams : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestUnits", "FinishParams_OperatorID", c => c.String(maxLength: 100));
            AddColumn("dbo.TestUnits", "FinishParams_Location", c => c.String());
            AddColumn("dbo.TestUnits", "FinishParams_Remarks", c => c.String());
            AddColumn("dbo.TestUnits", "FinishParams_Timestamp", c => c.DateTime());
            AddColumn("dbo.TestUnits", "FinishParams_Status", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestUnits", "FinishParams_Status");
            DropColumn("dbo.TestUnits", "FinishParams_Timestamp");
            DropColumn("dbo.TestUnits", "FinishParams_Remarks");
            DropColumn("dbo.TestUnits", "FinishParams_Location");
            DropColumn("dbo.TestUnits", "FinishParams_OperatorID");
        }
    }
}
