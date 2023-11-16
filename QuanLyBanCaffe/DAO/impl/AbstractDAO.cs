using Microsoft.Windows.Themes;
using QuanLyBanCaffe.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace QuanLyBanCaffe.DAO.impl
{
    public class AbstractDAO<T> : GenericDAO<T>
    {

        public SqlConnection getConnection()
        {
            string connectionString = "Data Source=MSI\\MINEWAKU;Initial Catalog=QuanLyBanCaffe;Persist Security Info=True;User ID=sa;Password=sqlmnwk11112003";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public List<T> dataConvert(DataTable dataTable, GenericDTO<T> model)
        {
            List<T> list = new List<T>();
            foreach (DataRow item in dataTable.Rows)
            {
                list.Add(model.instance(item));
            }

            return list;
        }

        public void setParameters(ref SqlCommand command, ref string sql, params Object[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                SqlParameter param;

                if (parameters[i] is int)
                {
                    param = new SqlParameter("@" + i, System.Data.SqlDbType.Int);
                    param.Value = parameters[i];
                    command.Parameters.Add(param);
                }
                else if (parameters[i] is long)
                {
                    param = new SqlParameter("@" + i, System.Data.SqlDbType.BigInt);
                    param.Value = parameters[i];
                    command.Parameters.Add(param);
                }
                else if (parameters[i] is string)
                {
                    param = new SqlParameter("@" + i, System.Data.SqlDbType.VarChar);
                    param.Value = parameters[i];
                    command.Parameters.Add(param);
                } 
                else if (parameters[i] is decimal)
                {
                    param = new SqlParameter("@" + i, System.Data.SqlDbType.Money);
                    param.Value = parameters[i];
                    command.Parameters.Add(param);
                } 
                else if (parameters[i] is bool)
                {
                    param = new SqlParameter("@" + i, System.Data.SqlDbType.Bit);
                    param.Value = parameters[i];
                    command.Parameters.Add(param);
                }
                else if (parameters[i] is DateTime)
                {
                    param = new SqlParameter("@" + i, System.Data.SqlDbType.DateTime);
                    param.Value = parameters[i];
                    command.Parameters.Add(param);
                }
            }
        }

        List<T> GenericDAO<T>.query(ref string sql, GenericDTO<T> model, params Object[] parameters)
        {   
            SqlConnection connection = getConnection();

            try
            {
                List<T> list = new List<T>();
                SqlCommand command = new SqlCommand(sql, connection);
                setParameters(ref command, ref sql, parameters);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                connection.Close();

                return dataConvert(dataTable, model);
            } 

            catch(SqlException ex) {
                throw new Exception(ex.Message);
            }
            
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            
            finally { 
                connection.Close(); 
            }
        }

        int GenericDAO<T>.insert(ref string sql, params Object[] parameters) 
        {

            SqlConnection connection = getConnection();

            try
            {
                SqlCommand command = new SqlCommand(sql, connection);
                setParameters(ref command, ref sql, parameters);
                int affectedRows = command.ExecuteNonQuery();
                return affectedRows;
            }

            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                connection.Close();
            }
        }

        void GenericDAO<T>.delete(ref string sql, params Object[] parameters)
        {

            SqlConnection connection = getConnection();

            try
            {
                SqlCommand command = new SqlCommand(sql, connection);
                setParameters(ref command, ref sql, parameters);
                int affectedRows = command.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                connection.Close();
            }
        }
        int GenericDAO<T>.count(ref string sql, params Object[] parameters)
        {
            SqlConnection connection = getConnection();

            try
            {
                SqlCommand command = new SqlCommand(sql, connection);
                setParameters(ref command, ref sql, parameters);
                int affectedRows = command.ExecuteNonQuery();
                return affectedRows;
            }

            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                connection.Close();
            }
        }
   
    }
}
