using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace Data
{
    public static class PendtxnD
    {
        public static Pendtxn Read(string connectionString, string ref_no, Dber dberr)
        {
            try
            {
                var PendingTxnMasterObject = new Pendtxn();

                var query = string.Format("select * from Pendtxn where ref_no = {0}", ref_no);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to Error master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    PendingTxnMasterObject.init_empid = data.Tables[0].Rows[0]["init_empid"].ToString();
                    PendingTxnMasterObject.init_csno = data.Tables[0].Rows[0]["init_csno"].ToString();
                    PendingTxnMasterObject.ref_no = data.Tables[0].Rows[0]["ref_no"].ToString();
                    PendingTxnMasterObject.tran_date = data.Tables[0].Rows[0]["tran_date"].ToString();
                    PendingTxnMasterObject.tran_desc = data.Tables[0].Rows[0]["tran_desc"].ToString();
                    PendingTxnMasterObject.tran_pvgb = data.Tables[0].Rows[0]["tran_pvgb"].ToString();
                    PendingTxnMasterObject.ac_no = data.Tables[0].Rows[0]["ac_no"].ToString();
                    PendingTxnMasterObject.cr_amt = Convert.ToDecimal(data.Tables[0].Rows[0]["cr_amt"]);
                    PendingTxnMasterObject.dr_amt = Convert.ToDecimal(data.Tables[0].Rows[0]["dr_amt"]);
                    PendingTxnMasterObject.tran_data = data.Tables[0].Rows[0]["tran_data"].ToString();

                    return PendingTxnMasterObject;
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_PENDTXN_READ);
                    return null;
                }
            }
            catch
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_PENDTXN_READ);
                return null;
            }
        }

        public static DataSet GetPendingTransactionsForAccount(string connectionString, string ac_no, Dber dberr)
        {
            try
            {
                var query = string.Format(string.Format("select * from Pendtxn where ac_no = '{0}'", ac_no));
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
                if(data!=null)
                {
                    return data;
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_PENDTXN_NOFETCH);
                    return null;
                }
            }
            catch
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_PENDTXN_NOFETCH);
                return null;
            }
        }

        public static DataSet GetAccessiblePendingTransactions(string connectionString, string pvgb, Dber dberr, bool isAdmin)
        {
            try
            {
                var condition = "<=";
                var accountColumn = string.Empty;
                if (!isAdmin) accountColumn = @" case 
                                                when DR_AMT = 0 and CR_AMT = 0  then ''
                                                when CR_AMT = 0 then '-' + CONVERT(varchar (max), DR_AMT)
                                                else CONVERT(varchar (max), CR_AMT)
                                                end Amount, ";
                if (isAdmin) condition = "=";
                var query = string.Format(string.Format(@"select 
                                                        [REF_NO] as [Reference Number],
                                                        [TRAN_DATE] as [Transaction Date],
                                                        [AC_NO] as [Account Number],
                                                        [INIT_CSNO] as [Customer Number],
                                                        [TRAN_DESC] as [Transaction Details], 
                                                        {2} 
                                                        '' as Command
                                                        from PENDTXN  where tran_pvgb {0} {1}", condition, pvgb, accountColumn));
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
                if (data != null)
                {
                    return data; 
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_PENDTXN_NOFETCH);
                    return null;
                }
            }
            catch
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_PENDTXN_NOFETCH);
                return null;
            }
        }

        public static DataSet ReadAll(string connectionString, Dber dberr)
        {
            var query = string.Format("select * from Pendtxn");
            return DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
        }
        public static int Create(string connectionString, Pendtxn dataObject, Data.Dber dberr)
        {
            try
            {

                var query = string.Format(@"INSERT INTO [SBS].[dbo].[PENDTXN]
               (
                [TRAN_DATE]
                ,[AC_NO]
                , [AC_NO2]
               ,[TRAN_PVGB]
               ,[INIT_EMPID]
               ,[INIT_CSNO]
               ,[DR_AMT]
               ,[CR_AMT]
               , [TRAN_ID]
                , [TRAN_DESC]
                , [TRAN_DATA])
                    OUTPUT INSERTED.REF_NO          
                    VALUES
                    ('{0}'  ,{1}, {2}, '{3}'  , {4} , {5}  ,'{6}', '{7}', {8}, '{9}', '{10}')",
                dataObject.tran_date,
                dataObject.ac_no == "0" ? "null" : dataObject.ac_no,
                dataObject.ac_no2 == "0" ? "null" : dataObject.ac_no2,
                dataObject.tran_pvgb,
                dataObject.init_empid == "0" ? "null" : dataObject.init_empid,
                dataObject.init_csno == "0" ? "null" : dataObject.init_csno,
                dataObject.dr_amt,
                dataObject.cr_amt,
                dataObject.tran_id ,
                dataObject.tran_desc,
                dataObject.tran_data);
                return (int)DbAccess.ExecuteScalar(connectionString, CommandType.Text, query);
            }
            catch
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_PENDTXN_NOWRITE);
                return -1;
            }
        }
        public static bool Update(string connectionString, Pendtxn dataObject)
        {
            throw new NotImplementedException();
        }

        public static bool Delete(string connectionString, string id)
        {
            try
            {
                var query = string.Format("delete from pendtxn where ref_no = {0}", id);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;

            }
            catch
            {
                return false;
            }
        }


        public static string GetTranDataFromRefNumber(string connectionString, string ref_no, Dber dberr)
        {
            try
            {
                var query = string.Format(string.Format(@"select tran_data from PENDTXN where ref_no = {0}", ref_no));
                var data = DbAccess.ExecuteScalar(connectionString, CommandType.Text, query);
                if (data != null)
                {
                    return data.ToString();
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_ACTM_NOFIND);
                    return null;
                }
            }
            catch
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_PENDTXN_NOFETCH);
                return "Transaction Error: " + Mnemonics.DbErrorCodes.DBERR_PENDTXN_NOFETCH;
            }
        }
    }
}
