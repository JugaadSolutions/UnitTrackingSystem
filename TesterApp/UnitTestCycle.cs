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
    
    public partial class UnitTestCycle
    {
        public UnitTestCycle()
        {
            this.TestTransactions = new HashSet<TestTransaction>();
        }
    
        public int UnitTestCycleID { get; set; }
        public Nullable<int> Status { get; set; }
        public int TestUnitID { get; set; }
        public System.DateTime StartTimestamp { get; set; }
        public Nullable<System.DateTime> EndTimestamp { get; set; }
    
        public virtual ICollection<TestTransaction> TestTransactions { get; set; }
        public virtual TestUnit TestUnit { get; set; }
    }
}