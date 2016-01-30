using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class ActmD
    {
        public static Actm Read(string connectionString, string acc_no, Dber dberr)
        {
            try
            {
                var accountMasterObject = new Actm();

                var query = string.Format("select * from actm where ac_no = {0}", acc_no);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to account master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    accountMasterObject.ac_bal = Convert.ToDecimal(data.Tables[0].Rows[0]["ac_bal"]);
                    accountMasterObject.ac_cr_flag = data.Tables[0].Rows[0]["ac_cr_flag"].ToString();
                    accountMasterObject.ac_dr_flag = data.Tables[0].Rows[0]["ac_dr_flag"].ToString();
                    accountMasterObject.ac_hold = Convert.ToDecimal(data.Tables[0].Rows[0]["ac_hold"]);
                    accountMasterObject.ac_no = data.Tables[0].Rows[0]["ac_no"].ToString();
                    accountMasterObject.ac_open_dt = data.Tables[0].Rows[0]["ac_open_dt"].ToString();
                    accountMasterObject.ac_pvg = Convert.ToInt32(data.Tables[0].Rows[0]["ac_pvg"]);
                    accountMasterObject.ac_type = data.Tables[0].Rows[0]["ac_type"].ToString();
                    accountMasterObject.cs_no1 = data.Tables[0].Rows[0]["cs_no1"].ToString();
                    accountMasterObject.cs_no2 = data.Tables[0].Rows[0]["cs_no2"].ToString();
                    accountMasterObject.ac_activ = Convert.ToBoolean(data.Tables[0].Rows[0]["ac_activ"].ToString());

                    return accountMasterObject;
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_ACTM_NOFIND);
                    return null; 
                }
            }
            catch(Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_ACTM_NOFIND);
                return null;
            }
        }

        public static DataSet ReadAll(string connectionString, Dber dberr)
        {
            try
            {
                var query = string.Format("select * from actm");
                return DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_ACTM_NOFIND);
                return null;
            }
        }

        public static DataSet GetUserAccountBalance(string connectionString, string customerNumber, int privilege, Dber dberr)
        {
            try
            {
                var query = string.Format("select ac_no, ac_type, ac_bal from actm where CS_NO1 = {0} and AC_ACTIV = 'True' and ac_pvg >= {1}", customerNumber, privilege);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
                if (data.Tables[0].Rows.Count > 0)
                {
                    return data;
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_ACTM_NOFIND);
                    return null;
                }
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_ACTM_NOFIND);
                return null;
            }
        }
        public static int Create(string connectionString, Actm dataObject, Dber dberr)
        {
            try
            {
                if (dataObject.cs_no2.Trim() == string.Empty) dataObject.cs_no2 = null;
                var query = string.Format(@"INSERT INTO [SBS].[dbo].[ACTM]
                           ([CS_NO1],[CS_NO2],[AC_TYPE],[AC_BAL],[AC_HOLD],[AC_PVG],[AC_DR_FLAG],[AC_CR_FLAG],[AC_OPEN_DT],[AC_ACTIV])
                            OUTPUT INSERTED.AC_NO                            
                            VALUES
                           ({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                            dataObject.cs_no1, dataObject.cs_no2 == "0" ? "null" :dataObject.cs_no2, dataObject.ac_type, dataObject.ac_bal, dataObject.ac_hold,
                            dataObject.ac_pvg, dataObject.ac_dr_flag, dataObject.ac_cr_flag, dataObject.ac_open_dt, dataObject.ac_activ);
                return (int)DbAccess.ExecuteScalar(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_ACTM_CREATE);
                return -1;
            }
        }
        
        public static bool Delete (string connectionString, string acc_no, Dber dberr)
        {
            try
            {
                var query = string.Format("delete from actm where ac_no = {0}", acc_no);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;

            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_ACTM_DELETE);
                return false;
            }
        }

        public static bool Update(Actm actmObject, Dber dberr)
        {
            throw new NotImplementedException();
            try
            {
                var query = "";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateAccountBalance(string connectionString, string accountNumber, decimal amount, Dber dberr)
        {
            try
            {
                var query = string.Format("update actm set ac_bal = {0} where ac_no = '{1}'", amount, accountNumber);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_ACTM_NOFIND);
                return false;
            }
        }

    }
}
