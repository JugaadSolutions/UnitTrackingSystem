namespace LogisticsApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tester
    {
        public Tester()
        {
            Bays = new HashSet<Bay>();
            TesterBreakdowns = new HashSet<TesterBreakdown>();
            Members = new HashSet<Member>();
        }

        public int TesterID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int Status { get; set; }

        public int SectorID { get; set; }

        public virtual ICollection<Bay> Bays { get; set; }

        public virtual Sector Sector { get; set; }

        public virtual ICollection<TesterBreakdown> TesterBreakdowns { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
