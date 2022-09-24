using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDA
    {
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString);

        public int InsertOrder(OrderBO order)
        {
            try
            {
                var query = $"INSERT INTO orders(order_no, purch_amt, ord_date, customer_id, salesman_id) VAlUES({order.OrderNo}, {order.PurchAmt}, '{order.OrderDate.Date}', {order.CustomerId}, {order.SalesmanId});";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
