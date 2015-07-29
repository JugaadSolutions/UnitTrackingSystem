
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace LogisticsApp
{
    public class LogisticTransaction : Transaction
    {
        public int LogisticTransactionID { get; set; }



        public int TestUnitID { get; set; }
        public virtual TestUnit TestUnit { get; set; }
    }
}
