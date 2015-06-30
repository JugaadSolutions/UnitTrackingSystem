using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogisticsApp.Views
{
    public class LoginParams
    {
        
        public LoginParams(String id)
        {
            OperatorID = id;
        }
        public String OperatorID { get; set; }
    }
}
