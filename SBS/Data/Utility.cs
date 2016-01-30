using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal static class Utility
    {
        static string[] _blackList = {"--", ";", "/*", "*/", "@@", "@",
                  "char", "nchar", "varchar", "nvarchar",
                  "alter", "begin", "cast", "create", "cursor",
                  "declare", "delete", "drop", "end", "exec",
                  "execute", "fetch", "insert", "kill", "open",
                   "sys", "sysobjects", "syscolumns",
                  "table", "update"};

        internal static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            try
            {
                foreach (SqlParameter Parameter in commandParameters)
                {
                    //checking for derived output value with no value assigned
                    if (Parameter.Value != DBNull.Value)
                    {
                        if ((Parameter.Direction == ParameterDirection.InputOutput) && (Parameter.Value == null))
                        {
                            Parameter.Value = DBNull.Value;
                        }
                    }
                    //Replacing the single quotes 
                    if (Parameter.SqlDbType != SqlDbType.Binary)
                    {
                        if (Parameter.SqlDbType == SqlDbType.NChar || Parameter.SqlDbType == SqlDbType.NVarChar || Parameter.SqlDbType == SqlDbType.VarChar || Parameter.SqlDbType == SqlDbType.Char && Parameter.Value != DBNull.Value)
                        {
                            if (Parameter.Value != DBNull.Value)
                            {
                                //Replacing special characters
                                if (Parameter.Value.ToString().IndexOf("'") >= 0)
                                {
                                    Parameter.Value = Parameter.Value.ToString().Replace("'", "\'").Trim();
                                }
                                else
                                {
                                    Parameter.Value = Parameter.Value.ToString().Trim();
                                }
                            }
                        }
                    }
                    command.Parameters.Add(Parameter);
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
        }

        internal static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            try
            {
                if ((commandParameters == null) || (parameterValues == null))
                {
                    return;
                }

                if (commandParameters.Length != parameterValues.Length)
                {
                    throw new ArgumentException("Parameter count does not match Parameter Value count.");
                }

                for (int i = 0, j = commandParameters.Length; i < j; i++)
                {
                    commandParameters[i].Value = parameterValues[i];
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

        }

        internal static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                command.Connection = connection;
                command.CommandText = commandText;

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandType = commandType;
                if (commandParameters != null)
                {
                    AttachParameters(command, commandParameters);
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
            return;
        }

        internal static SqlParameter[] GetProcedureParameterSet(string connectionString, string procedureName)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(procedureName, connection);
            SqlParameter[] discoveredParameters;
            try
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(command);
                discoveredParameters = new SqlParameter[command.Parameters.Count];
                command.Parameters.CopyTo(discoveredParameters, 0);
                return discoveredParameters;
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
                command.Dispose();
                command = null;
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        internal static bool ValidData(string data)
        {
            var isValid = false;

            var dataArray = data.Split(' ');

            var found = false;
            for (var i = 0; i < dataArray.Count(); i++)
            {
                if (_blackList.Contains(dataArray[i].Trim().ToLower()))
                {
                    found = true;
                    break;
                }
            }
            if (!found) isValid = true;

            return isValid;
        }

        internal static bool ValidData(Object dataObject)
        {
            var isValid = false;
            Type type = dataObject.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                isValid = ValidData(property.GetValue(dataObject, null).ToString());
                if (!isValid) break;
            }

            return isValid;
        }
    }
}
