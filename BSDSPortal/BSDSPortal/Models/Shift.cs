using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public class Shift
    {
        public int ShiftID { get; set; }

         [MaxLength(100)]
        [Index("NameIndex", IsUnique = true)]
        [Display(Name = "Shift Name")]
        public String Name { get; set; }


        public virtual ICollection<Member> Members { get; set; }

    }
}