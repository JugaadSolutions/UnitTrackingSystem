namespace LogisticsApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestTransaction
    {
        public int TestTransactionID { get; set; }

        [StringLength(100)]
        public string TransactionParameters_OperatorID { get; set; }

        public int TransactionParameters_Location { get; set; }

        public string TransactionParameters_Remarks { get; set; }

        public DateTime TransactionParameters_Timestamp { get; set; }

        public int TransactionParameters_Status { get; set; }

        public int TestCycleID { get; set; }

        public int BayID { get; set; }

        public virtual Bay Bay { get; set; }

        public virtual TestCycle TestCycle { get; set; }
    }
}
