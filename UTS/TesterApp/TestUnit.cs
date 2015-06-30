namespace TesterApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestUnit
    {
        public TestUnit()
        {
            TestCycles = new HashSet<TestCycle>();
        }

        public int TestUnitID { get; set; }

        [StringLength(100)]
        public string SerialNo { get; set; }

        public int? ProductModelID { get; set; }

        public int Status { get; set; }

        [StringLength(100)]
        public string DispatchParams_OperatorID { get; set; }

        public string DispatchParams_Location { get; set; }

        public string DispatchParams_Remarks { get; set; }

        public DateTime? DispatchParams_Timestamp { get; set; }

        public int DispatchParams_Status { get; set; }

        [StringLength(100)]
        public string ReceiveParams_OperatorID { get; set; }

        public string ReceiveParams_Location { get; set; }

        public string ReceiveParams_Remarks { get; set; }

        public DateTime? ReceiveParams_Timestamp { get; set; }

        public int ReceiveParams_Status { get; set; }

        [StringLength(100)]
        public string ReleaseParams_OperatorID { get; set; }

        public string ReleaseParams_Location { get; set; }

        public string ReleaseParams_Remarks { get; set; }

        public DateTime? ReleaseParams_Timestamp { get; set; }

        public int ReleaseParams_Status { get; set; }

        public virtual ProductModel ProductModel { get; set; }

        public virtual ICollection<TestCycle> TestCycles { get; set; }
    }
}
