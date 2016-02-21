using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BSDSPortal.Models
{
    public enum UNIT_STATUS
    {
        DESPATCHED, RECEIVED, RELEASED, UNDER_TEST, FINISHED, TEST_COMPLETE_ONTIME,
        TEST_COMPLETE_EARLY, TEST_COMPLETE_DELAY,
        REWORK,
        REPAIR
    };
    public class Unit
    {
        public int UnitID { get; set; }

        [MaxLength(100)]
        [Index("SerialNoIndex", IsUnique = true)]
        public String SerialNo { get; set; }

        public int? ProductModelID { get; set; }
        public virtual ProductModel ProductModel { get; set; }

        public UNIT_STATUS Status { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        
     

     

       

        public Unit()
        {
            Transactions = new HashSet<Transaction>();
            
           
        }

    }

    public class UnitUpdateInfo
    {
        public String Operator { get; set; }
        public String Location { get; set; }
        public String Department { get; set; }
        public String SerialNo { get; set; }
        public int ProductModelID { get; set; }
    }
}
