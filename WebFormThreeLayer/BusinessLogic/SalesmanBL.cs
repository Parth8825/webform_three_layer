using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SalesmanBL
    {
        public int InsertNewSalesman(SalesmanBO newSalesman)
        {
            try
            {
                SalesmanDA dataAccess = new SalesmanDA();
                return dataAccess.InsertSalesman(newSalesman);
            }
            catch
            {
                return 0;
            }
        }
    }
}
