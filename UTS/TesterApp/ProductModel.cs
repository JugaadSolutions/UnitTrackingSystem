namespace TesterApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductModel
    {
        public ProductModel()
        {
            TestUnits = new HashSet<TestUnit>();
        }

        public int ProductModelID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string Rating { get; set; }

        public int? CycleTime { get; set; }

        public int FamilyID { get; set; }

        public string Image { get; set; }

        public virtual Family Family { get; set; }

        public virtual ICollection<TestUnit> TestUnits { get; set; }
    }
}
