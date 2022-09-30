using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDA
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;

        public int GetCustomerData(DataTable DT)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                var query = "select * from customer;";
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

        public int InsertCustomer(CustomerBO customer)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertCustomer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = customer.CustomerId;
                cmd.Parameters.Add("@custName", SqlDbType.VarChar).Value = customer.CustomerName;
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = customer.City;
                cmd.Parameters.Add("@grade", SqlDbType.Int).Value = customer.Grade;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = customer.SalesId;
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

        public int UpdateCustomer(CustomerBO customer)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            { 
                SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = customer.CustomerId;
                cmd.Parameters.Add("@custName", SqlDbType.VarChar).Value = customer.CustomerName;
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = customer.City;
                cmd.Parameters.Add("@grade", SqlDbType.Int).Value = customer.Grade;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = customer.SalesId;
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

        public int DeleteCustomer(CustomerBO customer)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteCustomer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = customer.CustomerId;
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
