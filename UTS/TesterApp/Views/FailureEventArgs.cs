using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesterApp.Models;

namespace TesterApp.Views
{
    public class FailureEventArgs
    {

        public String EngineerID { get; set; }
        public String Remarks { get; set; }
        public List<Bay> Bays { get; set; }
    }
}
