namespace TesterApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestCycle
    {
        public TestCycle()
        {
            TestTransactions = new HashSet<TestTransaction>();
        }

        public int TestCycleID { get; set; }

        public DateTime StartTimestamp { get; set; }

        public DateTime? EndTimestamp { get; set; }

        public int? Status { get; set; }

        public int TestUnitID { get; set; }

        public virtual TestUnit TestUnit { get; set; }

        public virtual ICollection<TestTransaction> TestTransactions { get; set; }

      
    }
}
