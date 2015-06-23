using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public class Sector
    {
        public int SectorID { get; set; }

         [MaxLength(100)]
        [Index("NameIndex", IsUnique = true)]
        public String Name { get; set; }

        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<Member> Members { get; set; }

        public virtual ICollection<Tester> Testers { get; set; }

    }
}