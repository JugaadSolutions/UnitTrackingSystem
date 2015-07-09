using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public class Member
    {
        public int MemberID { get; set; }
      [Display(Name = "Member Name")] 
        public String Name { get; set; }

         [MaxLength(100)]
        [Index("SesaIDIndex", IsUnique = true)]
        public String SesaID { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }

        public virtual ICollection<Sector> Sectors { get; set; }
        public virtual ICollection<Tester> Testers { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }

        
       

        
    }
}