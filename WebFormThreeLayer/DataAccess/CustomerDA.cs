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
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString);

        public int InsertCustomer(CustomerBO customer)
        {
            try
            {
                var query = $"INSERT INTO customer(customer_id, cust_name, city, grade, salesman_id) VALUES({customer.CustomerId}, '{customer.CustomerName}', '{customer.City}', {customer.Grade}, {customer.SalesId});";
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
