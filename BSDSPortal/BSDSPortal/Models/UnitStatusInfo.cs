using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public enum UnitStatus { }
    public class UnitStatusInfo : TransactionParameters
    {
        public UNIT_STATUS Status { get; set; }


    }
}