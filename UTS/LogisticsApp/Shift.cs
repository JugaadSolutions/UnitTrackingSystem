namespace LogisticsApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shift
    {
        public Shift()
        {
            Members = new HashSet<Member>();
        }

        public int ShiftID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
