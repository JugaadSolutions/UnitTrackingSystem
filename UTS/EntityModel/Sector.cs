
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace UTS
{
    public partial class Sector
    {
        public Sector()
        {
            Testers = new HashSet<Tester>();
            Members = new HashSet<Member>();
        }

        public int SectorID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int LocationID { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<Tester> Testers { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
