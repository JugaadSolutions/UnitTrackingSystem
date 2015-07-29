namespace TesterApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestUnit
    {
        public int TestUnitID { get; set; }

        [StringLength(100)]
        public string SerialNo { get; set; }

        public int? ProductModelID { get; set; }

        public TransactionStatus Status { get; set; }

        public virtual ICollection<LogisticTransaction> LogisticsTransactions { get; set; }

        public virtual ProductModel ProductModel { get; set; }

        public virtual ICollection<TestCycle> TestCycles { get; set; }
    }
}