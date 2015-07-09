using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BSDSPortal.Models
{
    public class Family
    {
        public int FamilyID { get; set; }

         [MaxLength(100)]
        [Index("NameIndex", IsUnique = true)]

        [Display(Name = "Product Name")]
        public String Name { get; set; }

        public virtual ICollection<ProductModel> ProductModels { get; set; }

    }

    public class FamilyDTO
    {
        public int FamilyID { get; set; }
        public String Name { get; set; }

        

    }
}
