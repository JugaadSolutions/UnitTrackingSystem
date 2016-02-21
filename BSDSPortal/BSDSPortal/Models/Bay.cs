using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public enum BAY_TYPE { MVA_1 =1 , KVA_500 = 2,KVA_250=3 };
    public enum BAY_STATUS { IDLE = 1,INUSE=2, BREAKDOWN = 3  };

    public class Bay
    {
        public int BayID { get; set; }

        [MaxLength(100)]
        [Index("NameIndex", IsUnique = true)]
        [Display(Name = "Bay Name")]
        public String Name { get; set; }
        public BAY_STATUS Status { get; set; }
        public BAY_TYPE Type { get; set; }
       

        public virtual ICollection<Transaction> Transactions { get; set; }
      
    }


    public class BayDTO
    {
       
        public String Name { get; set; }
        public int Status { get; set; }
    }
}