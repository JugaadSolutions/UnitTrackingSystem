namespace BSDSPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TesterBreakDownStatus_TransactionParam_NullableStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TesterBreakdowns", "Status", c => c.Int());
            AlterColumn("dbo.BayBreakdowns", "BeginParameters_Status", c => c.Int());
            AlterColumn("dbo.BayBreakdowns", "EndParameters_Status", c => c.Int());
            AlterColumn("dbo.TesterBreakdowns", "BeginParameters_Status", c => c.Int());
            AlterColumn("dbo.TesterBreakdowns", "EndParameters_Status", c => c.Int());
            AlterColumn("dbo.TestTransactions", "TransactionParameters_Status", c => c.Int());
            AlterColumn("dbo.TestUnits", "DispatchParams_Status", c => c.Int());
            AlterColumn("dbo.TestUnits", "ReceiveParams_Status", c => c.Int());
            AlterColumn("dbo.TestUnits", "ReleaseParams_Status", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestUnits", "ReleaseParams_Status", c => c.Int(nullable: false));
            AlterColumn("dbo.TestUnits", "ReceiveParams_Status", c => c.Int(nullable: false));
            AlterColumn("dbo.TestUnits", "DispatchParams_Status", c => c.Int(nullable: false));
            AlterColumn("dbo.TestTransactions", "TransactionParameters_Status", c => c.Int(nullable: false));
            AlterColumn("dbo.TesterBreakdowns", "EndParameters_Status", c => c.Int(nullable: false));
            AlterColumn("dbo.TesterBreakdowns", "BeginParameters_Status", c => c.Int(nullable: false));
            AlterColumn("dbo.BayBreakdowns", "EndParameters_Status", c => c.Int(nullable: false));
            AlterColumn("dbo.BayBreakdowns", "BeginParameters_Status", c => c.Int(nullable: false));
            DropColumn("dbo.TesterBreakdowns", "Status");
        }
    }
}
