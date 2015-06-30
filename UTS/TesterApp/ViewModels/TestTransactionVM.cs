using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterApp
{
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
