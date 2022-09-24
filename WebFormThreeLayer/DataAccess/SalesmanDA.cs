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
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString);
        public int InsertSalesman(SalesmanBO salesman)
        {
            try
            {
                var query = $"insert into salesman(salesman_id, name, city, commission) values({salesman.SalesmanId},'{salesman.SalesmanName}','{salesman.City}',{salesman.Commision});";
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
