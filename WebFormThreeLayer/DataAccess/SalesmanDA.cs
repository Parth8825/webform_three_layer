using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SalesmanDA
    {
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString);

        public int GetSalesmanData(DataTable DT)
        {
            try
            {
                _connection.Open();
                var query = "select * from salesman;";
                SqlCommand cmd = new SqlCommand(query, _connection);

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
                _connection.Close();
            }
        }

        public int InsertSalesman(SalesmanBO salesman)
        {
            try
            {
                
                SqlCommand cmd = new SqlCommand("sp_InsertSalesman", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = salesman.SalesmanId;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = salesman.SalesmanName;
                cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = salesman.City;
                cmd.Parameters.Add("@commission", SqlDbType.Decimal).Value = salesman.Commision;
                _connection.Open();
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

        public int UpdateSalesman(SalesmanBO salesman)
        {
            try
            {
                
                SqlCommand cmd = new SqlCommand("sp_UpdateSalesman", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = salesman.SalesmanId;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = salesman.SalesmanName;
                cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = salesman.City;
                cmd.Parameters.Add("@commission", SqlDbType.Decimal).Value = salesman.Commision;
                _connection.Open();
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

        public int DeleteSalesman(SalesmanBO salesman)
        {
            try
            {
                
                SqlCommand cmd = new SqlCommand("sp_DeleteSalesman", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = salesman.SalesmanId;
                _connection.Open();
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
