using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class OrderBL
    {
        public int InsertNewOrder(OrderBO newOrder)
        {
            try
            {
                OrderDA dataAccess = new OrderDA();
                return dataAccess.InsertOrder(newOrder);
            }
            catch
            {
                return 0;
            }
        }
        public int UpdateOrder(OrderBO order)
        {
            try
            {
                OrderDA dataAccess = new OrderDA();
                return dataAccess.UpdateOrder(order);
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteOrder(OrderBO order)
        {
            try
            {
                OrderDA dataAccess = new OrderDA();
                return dataAccess.DeleteOrder(order);
            }
            catch
            {
                return 0;
            }
        }
    }
}
