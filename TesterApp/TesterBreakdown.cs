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
    
    public partial class TesterBreakdown
    {
        public TesterBreakdown()
        {
            this.StatusInfoes = new HashSet<StatusInfo>();
        }
    
        public int TesterBreakdownID { get; set; }
        public int TesterID { get; set; }
    
        public virtual ICollection<StatusInfo> StatusInfoes { get; set; }
        public virtual Tester Tester { get; set; }
    }
}