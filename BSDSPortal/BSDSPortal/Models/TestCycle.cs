using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSDSPortal.Models
{
    public enum TestCycleStatus { INPROGRESS, ONTIME,DELAYED,EARLY, FAILED, PAUSED };
    public class TestCycle
    {
        public int TestCycleID { get; set; }
        public DateTime StartTimestamp { get; set; }
        public Nullable<DateTime> EndTimestamp { get; set; }

        public Nullable<TestCycleStatus> Status { get; set; }
        

        


        public int TestUnitID { get; set; }
        public virtual TestUnit TestUnit { get; set; }

        public ICollection<TestTransaction> TestTransactions { get; set; }

    }
}
