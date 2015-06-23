using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterApp
{
    public partial class UnitTestCycle
    {
        public UnitTestCycle( DateTime ts, int status)
        {
            
            this.StartTimestamp = ts;
            this.Status = status;
            this.TestTransactions = new HashSet<TestTransaction>();
            
        }

        public UnitTestCycle(int tID,DateTime ts, int status)
        {
            this.TestUnitID = tID;
            this.StartTimestamp = ts;
            this.Status = status;
            this.TestTransactions = new HashSet<TestTransaction>();

        }

     
    }
}
