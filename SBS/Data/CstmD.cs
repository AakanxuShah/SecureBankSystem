using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class CstmD
    {
        public static Cstm Read(string connectionString, string id, Dber dberr)
        {
            try
            {
                var customerMasterObject = new Cstm();
                var query = string.Format("select * from cstm where cs_no = {0}", id);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to customer master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    return GetCstmObject(data.Tables[0].Rows[0]);
                    //customerMasterObject.cs_no = data.Tables[0].Rows[0]["cs_no"].ToString();
                    //customerMasterObject.cs_type = data.Tables[0].Rows[0]["cs_type"].ToString();
                    //customerMasterObject.cs_fname = data.Tables[0].Rows[0]["cs_fname"].ToString();
                    //customerMasterObject.cs_mname = data.Tables[0].Rows[0]["cs_mname"].ToString();
                    //customerMasterObject.cs_lname = data.Tables[0].Rows[0]["cs_lname"].ToString();
                    //customerMasterObject.cs_access = data.Tables[0].Rows[0]["cs_access"].ToString();
                    //customerMasterObject.cs_addr1 = data.Tables[0].Rows[0]["cs_addr1"].ToString();
                    //customerMasterObject.cs_addr2 = data.Tables[0].Rows[0]["cs_addr2"].ToString();
                    //customerMasterObject.cs_branch = data.Tables[0].Rows[0]["cs_branch"].ToString();
                    //customerMasterObject.cs_city = data.Tables[0].Rows[0]["cs_city"].ToString();
                    //customerMasterObject.cs_email = data.Tables[0].Rows[0]["cs_email"].ToString();
                    //customerMasterObject.cs_phn = data.Tables[0].Rows[0]["cs_phn"].ToString();
                    //customerMasterObject.cs_zip = data.Tables[0].Rows[0]["cs_zip"].ToString();
                    //customerMasterObject.cs_uname = data.Tables[0].Rows[0]["cs_uname"].ToString();
                    //customerMasterObject.cs_pass = data.Tables[0].Rows[0]["cs_pass"].ToString();
                    //customerMasterObject.cs_secq1 = data.Tables[0].Rows[0]["cs_sec_qs1"].ToString();
                    //customerMasterObject.cs_secq2 = data.Tables[0].Rows[0]["cs_sec_qs2"].ToString();
                    //customerMasterObject.cs_secq3 = data.Tables[0].Rows[0]["cs_sec_qs3"].ToString();
                    //customerMasterObject.cs_state = data.Tables[0].Rows[0]["cs_state"].ToString();
                    //customerMasterObject.cs_uid = data.Tables[0].Rows[0]["cs_uid"].ToString();
                    //customerMasterObject.cs_ans1 = data.Tables[0].Rows[0]["cs_sec_ans1"].ToString();
                    //customerMasterObject.cs_ans2 = data.Tables[0].Rows[0]["cs_sec_ans2"].ToString();
                    //customerMasterObject.cs_ans3 = data.Tables[0].Rows[0]["cs_sec_ans3"].ToString();
                    //return customerMasterObject;
                }

                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_CSTM_NOFIND);
                    return null;
                }
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_CSTM_NOFIND);
                return null;
            }
        }

        public static Cstm GetCustomerObjectFromUserName(string connectionString, string userName, Dber dberr)
        {
            try
            {
                var customerMasterObject = new Cstm();
                var query = string.Format("select * from cstm where cs_uname = '{0}'", userName);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to customer master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    return GetCstmObject(data.Tables[0].Rows[0]);
                }

                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_CSTM_NOFIND);
                    return null;
                }
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_CSTM_NOFIND);
                return null;
            }
        }

        public static Cstm Read(string connectionString, string userName, string password, Dber dberr)
        {
            try
            {
                var customerMasterObject = new Cstm();
                var query = string.Format("select * from cstm where cs_uname = '{0}' and cs_pass= '{1}'", userName, password);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to customer master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    return GetCstmObject(data.Tables[0].Rows[0]);
                }

                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_CSTM_NOFIND);
                    return null;
                }
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_CSTM_NOFIND);
                return null;
            }
        }

        public static DataSet ReadAll(string connectionString, Dber dberr)
        {
            var query = string.Format("select * from cstm");
            return  DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
        }

        public static int Create(string connectionString, Cstm dataObject, Dber dberr)
        {
            try
            {

                var s = Utility.ValidData(dataObject);

                var query = string.Format(@"INSERT INTO [SBS].[dbo].[CSTM]
                    ([CS_TYPE],[CS_FNAME],[CS_MNAME],[CS_LNAME],[CS_ADDR1],[CS_ADDR2],[CS_ZIP],[CS_CITY]
                    ,[CS_STATE],[CS_PHN],[CS_EMAIL],[CS_UID],[CS_BRANCH],[CS_SEC_QS1],[CS_SEC_ANS1],[CS_SEC_QS2],[CS_SEC_ANS2]
                    ,[CS_SEC_QS3],[CS_SEC_ANS3],[CS_ACCESS],[CS_UNAME],[CS_PASS])
                    OUTPUT INSERTED.CS_NO            
                    VALUES
                    ('{0}'  ,'{1}','{2}'  ,'{3}'  ,'{4}'  ,'{5}'  ,'{6}'  ,'{7}' ,'{8}'  ,'{9}'  ,'{10}' ,'{11}',
                     '{12}' ,'{13}' ,'{14}' ,'{15}' ,'{16}' ,'{17}' ,'{18}' ,'{19}' ,'{20}' ,'{21}')",
                dataObject.cs_type, dataObject.cs_fname, dataObject.cs_mname, dataObject.cs_lname,
                dataObject.cs_addr1, dataObject.cs_addr2, dataObject.cs_zip, dataObject.cs_city, dataObject.cs_state,
                dataObject.cs_phn, dataObject.cs_email, dataObject.cs_uid, dataObject.cs_branch, dataObject.cs_secq1,
                dataObject.cs_ans1, dataObject.cs_secq2, dataObject.cs_ans2, dataObject.cs_secq3, dataObject.cs_ans3,
                dataObject.cs_access, dataObject.cs_uname, dataObject.cs_pass);
                var customerId = (int)DbAccess.ExecuteScalar(connectionString, CommandType.Text, query);
                UpdateUserId(connectionString, customerId, dberr);
                UpdatePKIInformation(connectionString, customerId.ToString(), dberr);
                return customerId;
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_CSTM_CREATE);
                return -1;
            }
        }

        public static bool Update(string connectionString, Cstm dataObject, Dber dberr)
        {
            try
            {
                var query = string.Format(@"UPDATE [SBS].[dbo].[CSTM]
                                       SET 
                                           [CS_FNAME] =       '{0}'
                                          ,[CS_MNAME] =       '{1}'
                                          ,[CS_LNAME] =       '{2}'
                                          ,[CS_ADDR1] =       '{3}'
                                          ,[CS_ADDR2] =       '{4}'
                                          ,[CS_ZIP] =         '{5}'
                                          ,[CS_CITY] =        '{6}'
                                          ,[CS_STATE] =       '{7}'
                                          ,[CS_PHN] =         '{8}'
                                          ,[CS_EMAIL] =       '{9}'
                                         
                                          ,[CS_SEC_QS1] =     '{10}'
                                          ,[CS_SEC_ANS1] =    '{11}'
                                          ,[CS_SEC_QS2] =     '{12}'
                                          ,[CS_SEC_ANS2] =    '{13}'
                                          ,[CS_SEC_QS3] =     '{14}'
                                          ,[CS_SEC_ANS3] =    '{15}'
                                          
                                     WHERE CS_NO = {16}", dataObject.cs_fname, dataObject.cs_mname, dataObject.cs_lname,
                                         dataObject.cs_addr1, dataObject.cs_addr2, dataObject.cs_zip, dataObject.cs_city, dataObject.cs_state, dataObject.cs_phn,
                                         dataObject.cs_email, dataObject.cs_secq1, dataObject.cs_ans1, dataObject.cs_secq2,
                                         dataObject.cs_ans2, dataObject.cs_secq3, dataObject.cs_ans3, dataObject.cs_no);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;
            }
            catch(Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_CSTM_NOFIND);
                return false;
            }
        }
        public static bool deactivateCustomer(string connectionString, String cusNo, String deacType, Dber dberr)
        {
            try
            {
                var query = string.Format(@"UPDATE [SBS].[dbo].[CSTM]
                                               SET [CS_TYPE] = {0} WHERE CS_NO = {1}", deacType, cusNo);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;
            }
            catch(Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_EMP_CUS_DELETE);
                return false;
            }
        }
        private static bool UpdateUserId(string connectionString, int customerId, Dber dberr)
        {
            try
            {
                var query = string.Format(@"UPDATE [SBS].[dbo].[CSTM]
                                               SET 
                                                   [CS_UNAME] = '{0}'
                                             WHERE CS_NO = {0}", customerId);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_FAIL_UPDATE_PWD);
                return false;
            }
        }

        private static void UpdatePKIInformation(string connectionString, string customerNumber,Dber dberr)
        {
            var pkiServiceObject = new Security.PKIService();
            var pkiObject = new Pkit
            {
                cs_no = customerNumber,
                private_key = pkiServiceObject.PrivateKey,
                public_key = pkiServiceObject.PublicKey
            };
            PkitD.Create(connectionString, pkiObject, dberr);
        }

        public static bool UpdatePassword (string connectionString, string userId, string password, Dber dberr)
        {
            try
            {
                var query = string.Format("update cstm set cs_pass = '{0}' where cs_no = {1}", password, userId);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_FAIL_UPDATE_PWD);
                return false;
            }
        }

        public static bool Delete(string connectionString, string id, Dber dberr)
        {
            try
            {
                var query = string.Format("delete from cstm where cs_no = {0}", id);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;

            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_FAIL_UPDATE_PWD);
                return false;
            }
        }

        private static Cstm GetCstmObject(DataRow row)
        {
            try
            {
                var customerMasterObject = new Cstm();
                customerMasterObject.cs_no = row["cs_no"].ToString();
                customerMasterObject.cs_type = row["cs_type"].ToString();
                customerMasterObject.cs_fname = row["cs_fname"].ToString();
                customerMasterObject.cs_mname = row["cs_mname"].ToString();
                customerMasterObject.cs_lname = row["cs_lname"].ToString();
                customerMasterObject.cs_access = row["cs_access"].ToString();
                customerMasterObject.cs_addr1 = row["cs_addr1"].ToString();
                customerMasterObject.cs_addr2 = row["cs_addr2"].ToString();
                customerMasterObject.cs_branch = row["cs_branch"].ToString();
                customerMasterObject.cs_city = row["cs_city"].ToString();
                customerMasterObject.cs_email = row["cs_email"].ToString();
                customerMasterObject.cs_phn = row["cs_phn"].ToString();
                customerMasterObject.cs_zip = row["cs_zip"].ToString();
                customerMasterObject.cs_uname = row["cs_uname"].ToString();
                customerMasterObject.cs_pass = row["cs_pass"].ToString();
                customerMasterObject.cs_secq1 = row["cs_sec_qs1"].ToString();
                customerMasterObject.cs_secq2 = row["cs_sec_qs2"].ToString();
                customerMasterObject.cs_secq3 = row["cs_sec_qs3"].ToString();
                customerMasterObject.cs_state = row["cs_state"].ToString();
                customerMasterObject.cs_uid = row["cs_uid"].ToString();
                customerMasterObject.cs_ans1 = row["cs_sec_ans1"].ToString();
                customerMasterObject.cs_ans2 = row["cs_sec_ans2"].ToString();
                customerMasterObject.cs_ans3 = row["cs_sec_ans3"].ToString();
                return customerMasterObject;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static DataSet GetEmployeeAccessibleCustomerData(string connectionString, string employeeId, Dber dberr)
        {
            try
            {
                var query = string.Format("select * from cstm where [CS_TYPE] <> '0'");
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
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_FAIL_UPDATE_PWD);
                return null;
            }
        }

        public static DataSet GetMerchantAccessibleCustomerData(string connectionString, string employeeId, Dber dberr)
        {
            try
            {
                var query = string.Format("select * from cstm where cs_type > 0");
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
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_FAIL_UPDATE_PWD);
                return null;
            }
        }
    }
}
