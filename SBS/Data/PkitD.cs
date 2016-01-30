using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace Data
{
    public static class PkitD
    {
        public static Pkit Read(string connectionString, string id, Dber dberr)
        {
            try
            {
                var PkitMasterObject = new Pkit();

                var query = string.Format("select * from Pkit where id = {0}", id);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to Error master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    PkitMasterObject.id = data.Tables[0].Rows[0]["id"].ToString();
                    PkitMasterObject.public_key = data.Tables[0].Rows[0]["public_key"].ToString();
                    PkitMasterObject.private_key = data.Tables[0].Rows[0]["private_key"].ToString();
                    PkitMasterObject.cs_no = data.Tables[0].Rows[0]["cs_no"].ToString();



                    return PkitMasterObject;
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_PKIT_ERROR);
                    return null;
                }
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_PKIT_ERROR);
                return null;
            }
        }

        public static int Create(string connectionString, Pkit dataObject, Dber dberr)
        {
            try
            {

                var query = string.Format(@"INSERT INTO [SBS].[dbo].[PKIT]
           ([PUBLIC_KEY]
           ,[PRIVATE_KEY]
           ,[CS_NO])
                    OUTPUT INSERTED.id        
                    VALUES
                    ('{0}'  ,'{1}','{2}' )",
               dataObject.public_key, dataObject.private_key, dataObject.cs_no);
                return (int)DbAccess.ExecuteScalar(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_PKIT_ERROR);
                return -1;
            }
        }

        public static bool Update(string connectionString, Pkit dataObject, Dber dberr)
        {
            try
            {
                var query = string.Format(@"UPDATE [SBS].[dbo].[PKIT]
                                       SET 
                                           [PUBLIC_KEY] =       '{0}'
                                          ,[PRIVATE_KEY] =       '{1}'
                                          
                                          
                                          
                                     WHERE CS_NO = {2}", dataObject.public_key, dataObject.private_key, dataObject.cs_no);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;
            }
            catch(Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_PKIT_ERROR);
                return false;
            }
        }

        public static bool Delete(string connectionString, string cs_no, Dber dberr)
        {
            try
            {
                var query = string.Format("delete from pkit where cs_no = {0}", cs_no);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;

            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_PKIT_ERROR);
                return false;
            }
        }

        public static string GetBankPrivateKey(String connectionString)
        {
            try
            {
                string p = (string.Format("select private_key FROM Pkit WHERE id = '{0}'", '1'));
                var output = DbAccess.ExecuteScalar(connectionString, CommandType.Text, p);
                return output.ToString();
            }
            catch(Exception ex)
            {
                //dberr.setError(Mnemonics.DbErrorCodes.DBERR_PKIT_ERROR);
                throw ex;
            }
        }
        public static string GetBankPublicKey(String connectionString)
        {
            try
            {
                string p = (string.Format("select public_key FROM Pkit WHERE id = '{0}'", '1'));
                var output = DbAccess.ExecuteScalar(connectionString, CommandType.Text, p);
                return output.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static string GetCustomerPublicKey(String connectionString, string cs_no)
        {
            try
            {
                string p = (string.Format("select public_key FROM Pkit WHERE cs_no = '{0}'", cs_no));
                var output = DbAccess.ExecuteScalar(connectionString, CommandType.Text, p);
                return output == null ? null : output.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetCustomerPrivateKey(String connectionString, string cs_no)
        {
            try
            {
                string p = (string.Format("select private_key FROM Pkit WHERE cs_no = '{0}'", cs_no));
                var output = DbAccess.ExecuteScalar(connectionString, CommandType.Text, p);
                return output.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}