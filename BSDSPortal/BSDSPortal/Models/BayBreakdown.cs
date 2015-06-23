using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public class BayBreakdown
    {
        public int BayBreakdownID { get; set; }

        public TransactionParameters BeginParameters { get; set; }
        public TransactionParameters EndParameters { get; set; }

        public int BayID { get; set; }
        public virtual Bay Bay { get; set; }

        

    }
}