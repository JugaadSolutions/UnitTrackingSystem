using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterApp.Models
{

    public partial class TestUnitFactory
    {
        public enum UNIT_STATUS { PARTIAL = 1, COMPLETE = 2 }
        public TestUnit Unit { get; set; }

        public  TestUnitFactory(String SerialNo,String ProductModel)
        {
            using (BSDSContext db = new BSDSContext())
            {
                ProductModel p = db.ProductModels.SingleOrDefault(t=>t.Name == ProductModel);
                if( p == null )
                {
                    Unit = null;
                    return;
                }
                Unit = new TestUnit();
                Unit.ProductModelID = p.ProductModelID;
                Unit.Status = (int)UNIT_STATUS.PARTIAL;
                Unit.SerialNo = SerialNo;

                UnitTestCycle cycle = new UnitTestCycle();
               


               
            }
        }

    }
}
