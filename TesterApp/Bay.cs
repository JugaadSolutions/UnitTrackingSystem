//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TesterApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bay
    {
        public Bay()
        {
            this.BayBreakdowns = new HashSet<BayBreakdown>();
            this.TestTransactions = new HashSet<TestTransaction>();
        }
    
        public int BayID { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int TesterID { get; set; }
    
        public virtual ICollection<BayBreakdown> BayBreakdowns { get; set; }
        public virtual Tester Tester { get; set; }
        public virtual ICollection<TestTransaction> TestTransactions { get; set; }
    }
}
