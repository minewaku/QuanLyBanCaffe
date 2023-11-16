using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps;
using System.Data.SqlClient;
using System.Security.RightsManagement;

using QuanLyBanCaffe.LIB.Error;

namespace QuanLyBanCaffe.DAO
{
    public class DataProvider
    {
       /* private static string connectionString = "Data Source=MSI\\MINEWAKU;Initial Catalog=QuanLYBanThucAn;Persist Security Info=True;User ID=sa;Password=sqlmnwk11112003";

        public DataProvider()
        {

        }

        public static DataTable ExecuteQuery(string query)
        {
            try
            {
                try
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    if (connection == null)
                    {
                        throw new AppException(404, "Lỗi kết nối sql");
                    }
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    connection.Close();

                    return dataTable;
                }
                catch (SqlException ex)
                {
                    throw new AppException(405, string.Format("Lỗi query SQL \n{0}", query));
                }
            }
            catch (AppException ex)
            {
                throw ex;
            }
        }

        public static int ExecuteNonQuery(string query)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                if (connection == null)
                {
                    throw new AppException(404, "Lỗi kết nối sql");
                }
                SqlCommand command = new SqlCommand(query, connection);
                int affectedRows = command.ExecuteNonQuery();
                connection.Close();

                return affectedRows;
            }
            catch (SqlException ex)
            {
                throw new AppException(405, string.Format("Lỗi query SQL \n{0}", query));
            }
            catch (AppException ex)
            {
                throw ex;
            }
        }

        public static object ExecuteScalar(string query)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                if (connection == null)
                {
                    throw new AppException(404, "Lỗi kết nối sql");
                }
                SqlCommand command = new SqlCommand(query, connection);
                object scalar = command.ExecuteScalar();
                connection.Close();
                return scalar;
            }
            catch (SqlException ex)
            {
                throw new AppException(405, string.Format("Lỗi query SQL \n{0}", query));
            }
            catch (AppException ex)
            {
                throw ex;
            }
        }*/
    }
}
