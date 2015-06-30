namespace TesterApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Family
    {
        public Family()
        {
            ProductModels = new HashSet<ProductModel>();
        }

        public int FamilyID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<ProductModel> ProductModels { get; set; }
    }
}
