using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsApp
{
    public partial class TestUnit
    {

        public TestUnit(int pID, TransactionStatus Status, String sNo)
        {
            this.ProductModelID = pID;
            this.Status = Status;
            this.SerialNo = sNo;
            this.TestCycles = new HashSet<TestCycle>();

        }


        public void UpdateTestCycle(int bay, String by, String remarks,DateTime on,int cycle,TransactionStatus status  )
        {
            TestCycle tc = TestCycles.First(c => c.TestCycleID == cycle);
            tc.AddTransaction(bay,by,remarks,on,status);
            tc.Status = (int)status;
        }

      
       
    }
}
