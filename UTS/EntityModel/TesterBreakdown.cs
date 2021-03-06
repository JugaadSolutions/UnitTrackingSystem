
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


namespace UTS
{
    public partial class TesterBreakdown
    {
        public int TesterBreakdownID { get; set; }

        public int? Status { get; set; }

        [StringLength(100)]
        public string BeginParameters_OperatorID { get; set; }

        public string BeginParameters_Location { get; set; }

        public string BeginParameters_Remarks { get; set; }

        public DateTime? BeginParameters_Timestamp { get; set; }

        public int BeginParameters_Status { get; set; }

        [StringLength(100)]
        public string EndParameters_OperatorID { get; set; }

        public string EndParameters_Location { get; set; }

        public string EndParameters_Remarks { get; set; }

        public DateTime? EndParameters_Timestamp { get; set; }

        public int EndParameters_Status { get; set; }

        public int TesterID { get; set; }

        public virtual Tester Tester { get; set; }
    }
}
