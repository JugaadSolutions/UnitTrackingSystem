using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public enum BAY_STATUS { OK = 1, BREAKDOWN = 2 };

    public class Bay
    {
        public int BayID { get; set; }

        [MaxLength(100)]
        [Index("NameIndex", IsUnique = true)]
        [Display(Name = "Bay Name")]
        public String Name { get; set; }
        public BAY_STATUS Status { get; set; }

        public int TesterID { get; set; }
        public virtual Tester Tester { get; set; }

        public virtual ICollection<TestTransaction> TestTransactions { get; set; }
        public virtual ICollection<BayBreakdown> BayBreakdowns { get; set; }
    }
}