using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public enum TransactionStatus
    {
        DISPATCHED, RECEIVED, RELEASED, TEST_STARTED, TEST_COMPLETE_ONTIME,
        TEST_COMPLETE_DELAY, TEST_COMPLETE_EARLY, TEST_FAILURE, TEST_PAUSED, REWORK, BAYBREAKDOWN, TESTERBREAKDOWN, FINISHED
    };


    public class Transaction
    {

        
        public int TransactionID { get; set; }

        [MaxLength(100)]
        public String OperatorID { get; set; }
        public String Location { get; set; }
        public String Remarks { get; set; }
        public Nullable<DateTime> Timestamp { get; set; }
        public Nullable<TransactionStatus> Status { get; set; }

        public String SerialNo { get; set; }

        public Nullable<int> BayID { get; set; }
        public virtual Bay Bay { get; set; }


       
    }

    public class TransactionDTO
    {


       

       
        public String OperatorID { get; set; }
        public String Location { get; set; }
        public String Remarks { get; set; }
        public Nullable<DateTime> Timestamp { get; set; }
        public String Status { get; set; }

        public String SerialNo { get; set; }

       



    }


}