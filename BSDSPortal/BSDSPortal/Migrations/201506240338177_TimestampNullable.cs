namespace BSDSPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimestampNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BayBreakdowns", "BeginParameters_Timestamp", c => c.DateTime());
            AlterColumn("dbo.BayBreakdowns", "EndParameters_Timestamp", c => c.DateTime());
            AlterColumn("dbo.TesterBreakdowns", "BeginParameters_Timestamp", c => c.DateTime());
            AlterColumn("dbo.TesterBreakdowns", "EndParameters_Timestamp", c => c.DateTime());
            AlterColumn("dbo.TestTransactions", "TransactionParameters_Timestamp", c => c.DateTime());
            AlterColumn("dbo.TestUnits", "DispatchParams_Timestamp", c => c.DateTime());
            AlterColumn("dbo.TestUnits", "ReceiveParams_Timestamp", c => c.DateTime());
            AlterColumn("dbo.TestUnits", "ReleaseParams_Timestamp", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestUnits", "ReleaseParams_Timestamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TestUnits", "ReceiveParams_Timestamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TestUnits", "DispatchParams_Timestamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TestTransactions", "TransactionParameters_Timestamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TesterBreakdowns", "EndParameters_Timestamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TesterBreakdowns", "BeginParameters_Timestamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BayBreakdowns", "EndParameters_Timestamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BayBreakdowns", "BeginParameters_Timestamp", c => c.DateTime(nullable: false));
        }
    }
}
