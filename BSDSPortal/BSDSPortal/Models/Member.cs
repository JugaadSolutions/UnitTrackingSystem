using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public class Member
    {
        public int MemberID { get; set; }

        [MaxLength(100)]
        public String Name { get; set; }

      
        public String Email { get; set; }
        public String Mobile { get; set; }

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        public int LocationID { get; set; }
        public virtual Location Location { get; set; }



        
    }

    public class OperatorInfo
    {
        public String OperatorID { get; set; }
        public String Department { get; set; }
        public String Location { get; set; }
    }
}