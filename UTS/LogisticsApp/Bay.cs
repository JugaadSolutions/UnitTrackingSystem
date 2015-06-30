namespace LogisticsApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bay
    {
        public Bay()
        {
            BayBreakdowns = new HashSet<BayBreakdown>();
            TestTransactions = new HashSet<TestTransaction>();
        }

        public int BayID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int Status { get; set; }

        public int TesterID { get; set; }

        public virtual ICollection<BayBreakdown> BayBreakdowns { get; set; }

        public virtual Tester Tester { get; set; }

        public virtual ICollection<TestTransaction> TestTransactions { get; set; }
    }
}
