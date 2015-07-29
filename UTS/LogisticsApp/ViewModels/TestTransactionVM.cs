using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsApp
{
  
    public partial class TestTransaction
    {
        public TestTransaction(int bID, String eID, DateTime ts, String remarks, TransactionStatus Status)
        {
            this.OperatorID= eID;
            this.Remarks = remarks;
            this.Status = Status;
            this.Timestamp = ts;
            this.BayID = bID;
        }

        public TestTransaction(int bID, String eID, DateTime ts, 
            String remarks, TransactionStatus Status,int cycleID)
        {
            this.TestCycleID = cycleID;
            this.Location = eID;
            this.Remarks = remarks;
            this.Status = Status;
            this.Timestamp = ts;
            this.BayID = bID;
        }

        public TestTransaction()
        {
        }
    }
}
