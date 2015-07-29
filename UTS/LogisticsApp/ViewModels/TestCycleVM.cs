using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsApp
{
    public partial class TestCycle
    {
        public TestCycle( DateTime ts, int status)
        {
            
            this.StartTimestamp = ts;
            this.Status = status;
            this.TestTransactions = new HashSet<TestTransaction>();
            
        }

        public TestCycle(int tID,DateTime ts, int status)
        {
            this.TestUnitID = tID;
            this.StartTimestamp = ts;
            this.Status = status;
            this.TestTransactions = new HashSet<TestTransaction>();
            

        }

        public void UpdateTestCycle(int CycleStatus , int TransactionStatus)
        {

        }

        internal void AddTransaction(int bay, String by, String remarks,DateTime on,TransactionStatus status)
        {
            TestTransactions.Add(new TestTransaction(bay,by,on,remarks,status));
        }
     
    }
}
