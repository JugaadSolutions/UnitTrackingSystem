using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public class TesterBreakdown
    {
        public int TesterBreakdownID { get; set; }

        public TransactionParameters BeginParameters { get; set; }
        public TransactionParameters EndParameters { get; set; }

        public int TesterID { get; set; }
        public virtual Tester Tester { get; set; }

        


    }
}