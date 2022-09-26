using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public int InsertCustomer(CustomerBO customer)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                var query = $"insert into customer(customer_id, cust_name, city, grade, salesman_id) values({customer.CustomerId}, '{customer.CustomerName}', '{customer.City}', {customer.Grade}, {customer.SalesId});";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
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
                var query = $"update customer set cust_name = '{customer.CustomerName}', city='{customer.City}', grade={customer.Grade}, salesman_id={customer.CustomerId} where customer_id={customer.CustomerId};";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
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
                var query = $"delete customer where customer_id={customer.CustomerId};";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
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
