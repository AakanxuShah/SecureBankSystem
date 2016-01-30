using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal static class DbAccess
    {
        //private static string ConnectionString = ConfigurationManager.ConnectionStrings["ProductionString"].ToString();
        //private static string ConnectionString = "Data Source=group2.mobicloud.asu.edu, 1433;Initial Catalog=SBS;User ID=sbsAdmin;Password=sbsAdmin;";
        //private static const string CONNECTION_STRING = "Server=group2.mobicloud.asu.edu:1433;Database=SBS;User Id=sbsAdmin; password=sbsAdmin;encrypt=true";
        //private const string CONNECTION_STRING = "Server=(local);Initial Catalog=SBS;Integrated Security=True";
        private const int TIME_OUT = 1024;//Int32.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);

        #region ExecuteNonQuery

        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            var returnValue = 0;
            try
            {
                Utility.PrepareCommand(command, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
                returnValue = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                command = null;
            }
            return returnValue;
        }


        #endregion ExecuteNonQuery

        #region ExecuteQuery

        public static DataSet ExecuteQuery(string connectionString, string procedureName, params object[] parameterValues)
        {
            SqlParameter[] commandParameters;
            try
            {
                if ((parameterValues != null) && (parameterValues.Length > 0))
                {
                    commandParameters = Utility.GetProcedureParameterSet(connectionString, procedureName);
                    Utility.AssignParameterValues(commandParameters, parameterValues);
                    return ExecuteQuery(connectionString, CommandType.StoredProcedure, procedureName, commandParameters);
                }
                else
                {
                    return ExecuteQuery(connectionString, CommandType.StoredProcedure, procedureName);
                }
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                commandParameters = null;
            }
        }

        public static DataSet ExecuteQuery(string connectionString, CommandType commandType, string commandText)
        {
            try
            {
                return ExecuteQuery(connectionString, commandType, commandText, (SqlParameter[])null);
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataSet ExecuteQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            DataSet dataSet;
            SqlDataAdapter dataAdapter;
            try
            {
                command.CommandTimeout = TIME_OUT;
                Utility.PrepareCommand(command, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
                dataAdapter = new SqlDataAdapter(command);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                command.Parameters.Clear();
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                dataAdapter = null;
            }
            return dataSet;
        }

        #endregion ExecuteQuery

        #region ExecuteScalar

        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
        {
            try
            {
                return ExecuteScalar(connectionString, commandType, commandText, (SqlParameter[])null);
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object ExecuteScalar(string connectionString, string procedureName, params object[] parameterValues)
        {
            SqlParameter[] commandParameters;
            try
            {
                if ((parameterValues != null) && (parameterValues.Length > 0))
                {
                    commandParameters = Utility.GetProcedureParameterSet(connectionString, procedureName);
                    Utility.AssignParameterValues(commandParameters, parameterValues);
                    return ExecuteScalar(connectionString, CommandType.StoredProcedure, procedureName, commandParameters);
                }
                else
                {
                    return ExecuteScalar(connectionString, CommandType.StoredProcedure, procedureName);
                }
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { }
        }

        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            object returnValue;
            try
            {
                Utility.PrepareCommand(command, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
                returnValue = command.ExecuteScalar();
                command.Parameters.Clear();
                return returnValue;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                command = null;
            }
        }

        #endregion ExecuteScalar
    }
}