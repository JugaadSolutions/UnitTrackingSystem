using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BSDSPortal.Models
{
    public enum UNIT_STATUS { DESPATCHED, RECEIVED, RELEASED,UNDER_TEST, FINISHED }
    public class TestUnit
    {
        public int TestUnitID { get; set; }

        [MaxLength(100)]
        [Index("SerialNoIndex", IsUnique = true)]
        public String SerialNo { get; set; }

        public int ProductModelID { get; set; }
        public virtual ProductModel ProductModel { get; set; }

        public UNIT_STATUS Status { get; set; }

        public int DespatchedFrom { get; set; }
        public DateTime DespatchedAt { get; set; }
        public int DespatchedBy { get; set; }

        public int ReceivedBy { get; set; }
        public DateTime ReceivedAt { get; set; }

        public int ReleasedBy { get; set; }
        public DateTime ReleasedAt { get; set; }

        public ICollection<TestCycle> TestCycles { get; set; }

    }
}
