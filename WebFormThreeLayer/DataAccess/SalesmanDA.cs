using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess
{
    public class SalesmanDA
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
        public int InsertSalesman(SalesmanBO salesman)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                var query = $"insert into salesman(salesman_id, name, city, commission) values({salesman.SalesmanId},'{salesman.SalesmanName}','{salesman.City}',{salesman.Commision});";
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

        public int UpdateSalesman(SalesmanBO salesman)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                var query = $"update salesman Set name = '{salesman.SalesmanName}', city = '{salesman.City}', commission = {salesman.Commision} where salesman_id = {salesman.SalesmanId};";
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

        public int DeleteSalesman(SalesmanBO salesman)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                var query = $"delete salesman where salesman_id = {salesman.SalesmanId};";
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
