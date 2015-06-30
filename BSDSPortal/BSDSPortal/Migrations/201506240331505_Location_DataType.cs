namespace BSDSPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Location_DataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BayBreakdowns", "BeginParameters_Location", c => c.String());
            AlterColumn("dbo.BayBreakdowns", "EndParameters_Location", c => c.String());
            AlterColumn("dbo.TesterBreakdowns", "BeginParameters_Location", c => c.String());
            AlterColumn("dbo.TesterBreakdowns", "EndParameters_Location", c => c.String());
            AlterColumn("dbo.TestTransactions", "TransactionParameters_Location", c => c.String());
            AlterColumn("dbo.TestUnits", "DispatchParams_Location", c => c.String());
            AlterColumn("dbo.TestUnits", "ReceiveParams_Location", c => c.String());
            AlterColumn("dbo.TestUnits", "ReleaseParams_Location", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestUnits", "ReleaseParams_Location", c => c.Int(nullable: false));
            AlterColumn("dbo.TestUnits", "ReceiveParams_Location", c => c.Int(nullable: false));
            AlterColumn("dbo.TestUnits", "DispatchParams_Location", c => c.Int(nullable: false));
            AlterColumn("dbo.TestTransactions", "TransactionParameters_Location", c => c.Int(nullable: false));
            AlterColumn("dbo.TesterBreakdowns", "EndParameters_Location", c => c.Int(nullable: false));
            AlterColumn("dbo.TesterBreakdowns", "BeginParameters_Location", c => c.Int(nullable: false));
            AlterColumn("dbo.BayBreakdowns", "EndParameters_Location", c => c.Int(nullable: false));
            AlterColumn("dbo.BayBreakdowns", "BeginParameters_Location", c => c.Int(nullable: false));
        }
    }
}
