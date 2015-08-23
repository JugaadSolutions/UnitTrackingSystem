
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;



namespace UTS
{
    public partial class Location
    {
        public Location()
        {
            Sectors = new HashSet<Sector>();
        }

        public int LocationID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Sector> Sectors { get; set; }
    }
}
