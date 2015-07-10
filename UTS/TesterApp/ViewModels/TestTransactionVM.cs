using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterApp
{
    public enum TransactionStatus
    {
        DISPATCHED, RECEIVED, RELEASED, TEST_STARTED, TEST_COMPLETE_ONTIME,
        TEST_COMPLETE_DELAY, TEST_COMPLETE_EARLY, TEST_FAILURE, TEST_PAUSED, REWORK, BAYBREAKDOWN, TESTERBREAKDOWN, FINISHED
    };
    public partial class TestTransaction
    {
        public TestTransaction(int bID, String eID, DateTime ts, String remarks, int Status)
        {
            this.TransactionParameters_OperatorID= eID;
            this.TransactionParameters_Remarks = remarks;
            this.TransactionParameters_Status = Status;
            this.TransactionParameters_Timestamp = ts;
            this.BayID = bID;
        }

        public TestTransaction(int bID, String eID, DateTime ts, 
            String remarks, int Status,int cycleID)
        {
            this.TestCycleID = cycleID;
            this.TransactionParameters_OperatorID = eID;
            this.TransactionParameters_Remarks = remarks;
            this.TransactionParameters_Status = Status;
            this.TransactionParameters_Timestamp = ts;
            this.BayID = bID;
        }

        public TestTransaction()
        {
        }
    }
}
