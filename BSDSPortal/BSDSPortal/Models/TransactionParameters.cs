using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public enum TransactionStatus { DISPATCHED,RECEIVED,RELEASED,TEST_STARTED, TEST_COMPLETE_ONTIME,
        TEST_COMPLETE_DELAY,TEST_COMPLETE_EARLY, TEST_FAILURE,TEST_PAUSED,REWORK,BAYBREAKDOWN, TESTERBREAKDOWN };

    [ComplexType]
    public abstract class TransactionParameters
    {
       
        [MaxLength(100)]
        public String OperatorID { get; set; }
        public int Location { get; set; }
        public String Remarks { get; set; }
        public DateTime Timestamp { get; set; }
        public TransactionStatus Status { get; set; }
    }
}