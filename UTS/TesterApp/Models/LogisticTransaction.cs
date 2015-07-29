using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesterApp.Models
{
    public class LogisticTransaction : Transaction
    {
        public int LogisticTransactionID { get; set; }

       

        public int TestUnitID { get; set; }
        public virtual TestUnit TestUnit { get; set; }
    }
}
