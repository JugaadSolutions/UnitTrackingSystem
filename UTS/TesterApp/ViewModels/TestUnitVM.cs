using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterApp
{
    public partial class TestUnit
    {

        public TestUnit(int pID, int Status, String sNo)
        {
            this.ProductModelID = pID;
            this.Status = Status;
            this.SerialNo = sNo;
            this.TestCycles = new HashSet<TestCycle>();

        }

       
    }
}
