using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace Data
{
    public static class FinhistD
    {
        public static Finhist Read(string connectionString, string ref_no, Dber dberr)
        {
            try
            {
                var FinHistMasterObject = new Finhist();

                var query = string.Format("select * from FinHist where ref_no = {0}", ref_no);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to ErrorHistry master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    FinHistMasterObject.ref_no = data.Tables[0].Rows[0]["ref_no"].ToString();
                    FinHistMasterObject.init_empid = data.Tables[0].Rows[0]["init_empid"].ToString();
                    FinHistMasterObject.tran_date = data.Tables[0].Rows[0]["tran_date"].ToString();
                    FinHistMasterObject.tran_desc = data.Tables[0].Rows[0]["tran_desc"].ToString();
                    FinHistMasterObject.tran_timestamp = data.Tables[0].Rows[0]["tran_timestamp"].ToString();
                    FinHistMasterObject.rem_bal = data.Tables[0].Rows[0]["rem_bal"].ToString();
                    FinHistMasterObject.cr_amt = Convert.ToDecimal(data.Tables[0].Rows[0]["cr_amt"]);
                    FinHistMasterObject.dr_amt = Convert.ToDecimal(data.Tables[0].Rows[0]["dr_amt"]);
                    FinHistMasterObject.ac_no = data.Tables[0].Rows[0]["ac_no"].ToString();
                    FinHistMasterObject.apprv_empid = data.Tables[0].Rows[0]["apprv_empid"].ToString();
                    FinHistMasterObject.init_csno = data.Tables[0].Rows[0]["init_csno"].ToString();


                    return FinHistMasterObject;
                }

                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_FINHIST_READ);
                    return null;
                }
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_FINHIST_READ);
                return null;
            }
        }
        public static DataSet ReadAll(string connectionString, Dber dberr)
        {
            try
            {
                var query = string.Format("select * from FinHist");
                return DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
            }
            catch(Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_FINHIST_READ);
                return null;
            }

        }
        public static int Create(string connectionString, Finhist dataObject, Dber dberr)
        {
            try
            {

                var query = string.Format(@"INSERT INTO [SBS].[dbo].[FINHIST]
           ([TRAN_DATE]
           ,[AC_NO]
           ,[TRAN_TIMESTAMP]
           ,[TRAN_DESC]
           ,[REM_BAL]
           ,[INIT_CSNO]
           ,[INIT_EMPID]
           ,[APPRV_EMPID]
           ,[DR_AMT]
           ,[CR_AMT])
                    OUTPUT INSERTED.REF_NO          
                    VALUES
                    ('{0}'  ,'{1}','{2}'  ,'{3}'  ,'{4}'  ,{5}  ,{6}  ,{7} ,'{8}'  ,'{9}')",
               dataObject.tran_date,dataObject.ac_no,dataObject.tran_timestamp,dataObject.tran_desc,dataObject.rem_bal,
               dataObject.init_csno == "0" ? "null" : dataObject.init_csno, 
               dataObject.init_empid == "0" ? "null" : dataObject.init_empid,
               dataObject.apprv_empid == "0" ? "null" : dataObject.apprv_empid,
               dataObject.dr_amt,dataObject.cr_amt);
                return (int)DbAccess.ExecuteScalar(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_FINHIST_CREATE);
                return -1;
            }
        }
        public static bool Update(string connectionString, Finhist dataObject, Dber dberr)
        {
            throw new NotImplementedException();
        }

        public static bool Delete(string connectionString, string id, Dber dberr)
        {
            try
            {
                var query = string.Format("delete from Finhist where ref_no = {0}", id);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;

            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_FINHIST_DELETE);
                return false;
            }
        }

        public static DataSet GetAccountStatement(string connectionString, string cs_no, Dber dberr)
        {
            try
            {
                var query = string.Format(string.Format(@"select 
                            AC_NO [Account Number],
                            TRAN_TIMESTAMP [Timestamp],
                            TRAN_DESC [Transaction],
                            DR_AMT as [Amount],
                            REM_BAL [Balance]
                            from FINHIST
                            where ac_no in (select AC_NO from ACTM where CS_NO1 = '{0}')
                            order by AC_NO, TRAN_TIMESTAMP desc", cs_no));
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
                if (data != null)
                {
                    return data;
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_FINHIST_READ);
                    return null;
                }
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_FINHIST_READ);
                return null;
            }
        }
    }
}
