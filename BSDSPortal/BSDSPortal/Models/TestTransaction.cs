using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    

    public class TestTransaction
    {
        public int TestTransactionID { get; set; }

        public TransactionParameters TransactionParameters { get; set; }
        

        public int TestCycleID { get; set; }
        public virtual TestCycle TestCycle{ get; set; }

        public int BayID { get; set; }
        public virtual Bay Bay { get; set; }
    }
}