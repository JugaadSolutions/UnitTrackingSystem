using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public enum TESTER_STATUS {OK = 0,BREAKDOWN = 1};
    public class Tester
    {
        
        public int TesterID { get; set; }

         [MaxLength(100)]
        [Index("NameIndex", IsUnique = true)]
        [Display(Name = "Test Name")]
        public String Name { get; set; }

        public TESTER_STATUS Status { get; set; }

        [NotMapped]
        public int Bays { get; set; }

        public int SectorID { get; set; }
        public virtual Sector Sector { get; set; }

        public virtual ICollection<TesterBreakdown> TesterBreakdowns { get; set; }

        public virtual ICollection<Member> Members { get; set; }


    }
}