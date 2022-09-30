using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SalesmanBL
    {
        public int SalesmanDate(DataTable DT)
        {
            try
            {
                SalesmanDA dataAccess = new SalesmanDA();
                return dataAccess.GetSalesmanData(DT);
            }
            catch
            {
                return 0;
            }
        }

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

        public int UpdateSalesman(SalesmanBO salesman)
        {
            try
            {
                SalesmanDA dataAccess = new SalesmanDA();
                return dataAccess.UpdateSalesman(salesman);
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteSalesman(SalesmanBO salesman)
        {
            try
            {
                SalesmanDA dataAccess = new SalesmanDA();
                return dataAccess.DeleteSalesman(salesman);
            }
            catch
            {
                return 0;
            }
        }


    }
}
