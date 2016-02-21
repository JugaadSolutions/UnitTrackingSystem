
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


namespace UTS
{
    public partial class TestTransaction : Transaction
    {
        public int TestTransactionID { get; set; }

        public int TestCycleID { get; set; }
        public virtual TestCycle TestCycle { get; set; }

        public int BayID { get; set; }
        public virtual Bay Bay { get; set; }

       
    }
}
