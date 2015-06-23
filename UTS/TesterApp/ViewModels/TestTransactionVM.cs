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
            this.EngineerID = eID;
            this.Remarks = remarks;
            this.Status = Status;
            this.Timestamp = ts;
            this.BayID = bID;
        }

        public TestTransaction(int bID, String eID, DateTime ts, 
            String remarks, int Status,int cycleID)
        {
            this.UnitTestCycleID = cycleID;
            this.EngineerID = eID;
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
