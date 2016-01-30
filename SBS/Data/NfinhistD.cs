using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace Data
{
    public static class NfinhistD
    {
        public static Nfinhist Read(string connectionString, string ref_no, Dber dberr)
        {
            try
            {
                var NfinhistObject = new Nfinhist();

                var query = string.Format("select * from Nfinhist where ref_no = {0}", ref_no);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to Error master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    NfinhistObject.ac_no = data.Tables[0].Rows[0]["ac_no"].ToString();
                    NfinhistObject.apprv_empid = data.Tables[0].Rows[0]["apprv_empid"].ToString();
                    NfinhistObject.init_empid = data.Tables[0].Rows[0]["init_empid"].ToString();
                    NfinhistObject.ref_no = data.Tables[0].Rows[0]["ref_no"].ToString();
                    NfinhistObject.tran_date = data.Tables[0].Rows[0]["tran_date"].ToString();
                    NfinhistObject.tran_desc = data.Tables[0].Rows[0]["tran_desc"].ToString();
                    NfinhistObject.tran_timestamp = data.Tables[0].Rows[0]["tran_timestamp"].ToString();
                    NfinhistObject.init_csno = data.Tables[0].Rows[0]["init_csno"].ToString();
                    // NfinhistObject.apprv_empid = data.Tables[0].Rows[0]["ref_no"].ToString();

                    return NfinhistObject;

                }

                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_NFINHIST_READ);
                    return null;
                }
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_NFINHIST_READ);
                return null;
            }
        }
        public static DataSet ReadAll(string connectionString, Dber dberr)
        {
            try
            {
                var query = string.Format("select * from Nfinhist");
                return DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
            }
            catch(Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_NFINHIST_READ);
                return null;
            }
        }
        public static int Create(string connectionString, Nfinhist dataObject, Dber dberr)
        {
            try
            {

                var query = string.Format(@"INSERT INTO [SBS].[dbo].[NFINHIST]
           ([TRAN_DATE]
           ,[AC_NO]
           ,[TRAN_TIMESTAMP]
           ,[TRAN_DESC]
           ,[INIT_EMPID]
           ,[APPRV_EMPID]
           ,[INIT_CSNO])
                    OUTPUT INSERTED.REF_NO          
                    VALUES
                    ('{0}'  ,{1},'{2}'  ,'{3}'  ,{4}  ,{5}  ,{6})",
                dataObject.tran_date, dataObject.ac_no == "0" ? "null" : dataObject.ac_no, dataObject.tran_timestamp, dataObject.tran_desc,
                dataObject.init_empid == "0" ? "null" : dataObject.init_empid,
                dataObject.apprv_empid == "0" ? "null" : dataObject.apprv_empid,
                dataObject.init_csno == "0" ? "null": dataObject.init_csno);
                return (int)DbAccess.ExecuteScalar(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_NFINHIST_CREATE);
                return -1;
            }
        }

        public static bool Update(string connectionString, Nfinhist dataObject, Dber dberr)
        {
            throw new NotImplementedException();
        }
        public static bool Delete(string connectionString, string id, Dber dberr)
        {
           try
            {
                var query = string.Format("delete from nfinhist where ref_no = {0}", id);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;

            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_NFINHIST_DELETE);
                return false;
            }
        }

        public static DataSet GetAccountStatement(string connectionString, string cs_no, Dber dberr)
        {
            try
            {
                var query = string.Format(string.Format(@"select 
                            TRAN_TIMESTAMP [Timestamp],
                            TRAN_DESC [Transaction],
                            INIT_CSNO [Customer Number],
                            INIT_EMPID [Employee Id],
                            APPRV_EMPID [Approver Id],
                            AC_NO [Account Number]
                            from NFINHIST
                            
                            order by TRAN_TIMESTAMP desc", cs_no));
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
                if (data != null)
                {
                    return data;
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_NFINHIST_READ);
                    return null;
                }
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_NFINHIST_READ);
                return null; 
            }
        }
    }
}