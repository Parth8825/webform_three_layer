using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDA
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;

        public int GetOrderData(DataTable DT)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                var query = "select * from orders;";
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(DT);
                return DT.Rows.Count;
            }
            catch
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public int InsertOrder(OrderBO order)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@orderno", SqlDbType.Int).Value = order.OrderNo;
                cmd.Parameters.Add("@purchAmt", SqlDbType.Decimal).Value = order.PurchAmt;
                cmd.Parameters.Add("@orderDate", SqlDbType.Date).Value = order.OrderDate;
                cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = order.CustomerId;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = order.SalesmanId;
                connection.Open();
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
                connection.Close();
            }
        }

        public int UpdateOrder(OrderBO order)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@orderNo", SqlDbType.Int).Value = order.OrderNo;
                cmd.Parameters.Add("@purchAmt", SqlDbType.Decimal).Value = order.PurchAmt;
                cmd.Parameters.Add("@orderDate", SqlDbType.Date).Value = order.OrderDate;
                cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = order.CustomerId;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = order.SalesmanId;
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                //cmd.Dispose();
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public int DeleteOrder(OrderBO order)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@orderNo", SqlDbType.Int).Value = order.OrderNo;
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                //cmd.Dispose();
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
