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
    
    public partial class StatusInfo
    {
        public StatusInfo()
        {
            this.BayBreakdowns = new HashSet<BayBreakdown>();
        }
    
        public int ID { get; set; }
        public string EngineerID { get; set; }
        public string Remarks { get; set; }
        public System.DateTime Timestamp { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> Status1 { get; set; }
        public Nullable<int> TesterBreakdownID { get; set; }
        public Nullable<int> Status2 { get; set; }
        public string Discriminator { get; set; }
        public Nullable<int> BayBreakdown_BayBreakdownID { get; set; }
    
        public virtual ICollection<BayBreakdown> BayBreakdowns { get; set; }
        public virtual BayBreakdown BayBreakdown { get; set; }
        public virtual TesterBreakdown TesterBreakdown { get; set; }
    }
}
