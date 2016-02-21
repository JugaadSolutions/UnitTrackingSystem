using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [MaxLength(100)]
        public String Name { get; set; }

       

        public ICollection<Member> Members { get; set; }
    }
}