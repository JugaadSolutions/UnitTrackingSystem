using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BSDSPortal.Models
{
    public class ProductModel
    {

        public int ProductModelID { get; set; }

         [MaxLength(100)]
        [Index("NameIndex", IsUnique = true)]
        [Display(Name = "Family Name")]
        public String Name { get; set; }
        public String Rating {get;set;}

        public Nullable<int> CycleTime { get; set; }

        public int FamilyID { get; set; }
        public virtual Family Family { get; set; }

        public String Image { get; set; }


        public virtual ICollection<TestUnit> TestUnits { get; set; }

    }
}
