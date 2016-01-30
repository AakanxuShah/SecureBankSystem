using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mnemonics;

namespace Data
{
    public static class TxnmD
    {

        public static Txnm Read(string connectionString, string code, Dber dberr)
        {
            try
            {
                var transactionTypeMasterObject = new Txnm();

                var query = string.Format("select * from txnm where tran_code = '{0}'", code);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                if (data.Tables[0].Rows.Count > 0)
                {
                    transactionTypeMasterObject.tran_desc = data.Tables[0].Rows[0]["tran_desc"] != null ? data.Tables[0].Rows[0]["tran_desc"].ToString() : "";
                    transactionTypeMasterObject.tran_code = data.Tables[0].Rows[0]["tran_code"] != null ? data.Tables[0].Rows[0]["tran_code"].ToString() : "";
                    transactionTypeMasterObject.tran_fin_type = data.Tables[0].Rows[0]["tran_fin_type"] != null ? data.Tables[0].Rows[0]["tran_fin_type"].ToString() : "";
                    transactionTypeMasterObject.tran_id = data.Tables[0].Rows[0]["tran_id"].ToString();
                    transactionTypeMasterObject.tran_pvga = Convert.ToInt16(data.Tables[0].Rows[0]["tran_pvga"].ToString());
                    transactionTypeMasterObject.tran_pvgb = Convert.ToInt16(data.Tables[0].Rows[0]["tran_pvgb"].ToString());

                    return transactionTypeMasterObject;
                }

                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_TXNM_NOFIND);
                    return null;
                }
            }
            catch //(Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_TXNM_NOFIND);
                return null;
            }
        }

        public static DataSet ReadAll(string connectionString, Dber dberr)
        {
            try
            {
                var query = string.Format("select * from txnm");
                return DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
            }
            catch //(Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_TXNM_READALL);
                return null;
            }
        }

        public static int Create(string connectionString, Txnm dataObject, Dber dberr)
        {
            try
            {
                var query = string.Format(@"INSERT INTO [TXNM] ([TRAN_DESC], [TRAN_PVGA], [TRAN_PVGB], [TRAN_FIN_TYPE]) OUTPUT INSERTED.TRAN_ID VALUES ('{0}',{1},{2},'{3}')",
                                        dataObject.tran_desc, dataObject.tran_pvga, dataObject.tran_pvgb, dataObject.tran_fin_type);

                return (int) DbAccess.ExecuteScalar(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_TXNM_CREATE);
                return -1;
            }
        }

        public static bool Delete(string connectionString, string id, Dber dberr)
        {
            try
            {
                var query = string.Format("delete from txnm where tran_id = {0}", id);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;

            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_TXNM_DELETE);
                return false;
            }
        }

        public static bool Update(Txnm txnmObject, Dber dberr)
        {
            throw new NotImplementedException();
            try
            {
                var query = "";

            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
        }
        public static string GetTransactionIdFromCode(String connectionString, String transactioncode)
        {
           // transactioncode = "vevfe";
            string p = (string.Format("select TRAN_ID FROM TXNM WHERE TRAN_CODE = '{0}'", transactioncode));
            var output = DbAccess.ExecuteScalar(connectionString, CommandType.Text, p);
            return output.ToString();
        }
    }
}
