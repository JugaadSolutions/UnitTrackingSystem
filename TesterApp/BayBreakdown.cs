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
    
    public partial class BayBreakdown
    {
        public BayBreakdown()
        {
            this.StatusInfoes = new HashSet<StatusInfo>();
        }
    
        public int BayBreakdownID { get; set; }
        public int BayID { get; set; }
        public Nullable<int> TesterStatusInfo_ID { get; set; }
    
        public virtual Bay Bay { get; set; }
        public virtual StatusInfo StatusInfo { get; set; }
        public virtual ICollection<StatusInfo> StatusInfoes { get; set; }
    }
}
