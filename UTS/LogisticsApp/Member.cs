namespace LogisticsApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        public Member()
        {
            Testers = new HashSet<Tester>();
            Sectors = new HashSet<Sector>();
            Shifts = new HashSet<Shift>();
        }

        public int MemberID { get; set; }

        public string Name { get; set; }

        [StringLength(100)]
        public string OperatorID { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public virtual ICollection<Tester> Testers { get; set; }

        public virtual ICollection<Sector> Sectors { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
