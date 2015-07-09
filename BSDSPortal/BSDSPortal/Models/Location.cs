using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public class Location
    {
        public int LocationID { get; set; }

         [MaxLength(100)]
        [Index("NameIndex", IsUnique = true)]
        [Display(Name = "Location Name")]
        public String Name { get; set; }

        public virtual ICollection<Sector> Sectors { get; set; }
    }

    public class LocationDTO
    {
        public int LocationID { get; set; }
        public String Name { get; set; }
    }
}