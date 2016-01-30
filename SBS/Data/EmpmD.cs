using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace Data
{
    public static class EmpmD
    {
        public static Empm Read(string connectionString, string emp_id, Dber dberr)
        {
            try
            {
                var employeeMasterObject = new Empm();

                var query = string.Format("select * from empm where emp_id = {0}", emp_id);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to employee master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    employeeMasterObject.emp_no = data.Tables[0].Rows[0]["emp_id"].ToString();
                    employeeMasterObject.emp_fname = data.Tables[0].Rows[0]["emp_fname"].ToString();
                    employeeMasterObject.emp_mname = data.Tables[0].Rows[0]["emp_mname"].ToString();
                    employeeMasterObject.emp_lname = data.Tables[0].Rows[0]["emp_lname"].ToString();
                    employeeMasterObject.emp_phn = data.Tables[0].Rows[0]["emp_phn"].ToString();
                    employeeMasterObject.emp_addr1 = data.Tables[0].Rows[0]["emp_addr1"].ToString();
                    employeeMasterObject.emp_addr2 = data.Tables[0].Rows[0]["emp_addr2"].ToString();
                    employeeMasterObject.emp_city = data.Tables[0].Rows[0]["emp_city"].ToString();
                    employeeMasterObject.emp_state = data.Tables[0].Rows[0]["emp_state"].ToString();
                    employeeMasterObject.emp_zip = data.Tables[0].Rows[0]["emp_zip"].ToString();
                    employeeMasterObject.emp_uname = data.Tables[0].Rows[0]["emp_uname"].ToString();
                    employeeMasterObject.emp_pass = data.Tables[0].Rows[0]["emp_pass"].ToString();
                    employeeMasterObject.emp_pvg = Convert.ToInt32(data.Tables[0].Rows[0]["emp_pvg"]);
                    employeeMasterObject.emp_mngr = data.Tables[0].Rows[0]["emp_mngr"].ToString();
                    employeeMasterObject.emp_brnch = data.Tables[0].Rows[0]["emp_brnch"].ToString();
                    employeeMasterObject.emp_secq1 = data.Tables[0].Rows[0]["emp_secq1"].ToString();
                    employeeMasterObject.emp_ans1 = data.Tables[0].Rows[0]["emp_ans1"].ToString();
                    employeeMasterObject.emp_secq2 = data.Tables[0].Rows[0]["emp_secq2"].ToString();
                    employeeMasterObject.emp_ans2 = data.Tables[0].Rows[0]["emp_ans2"].ToString();
                    employeeMasterObject.emp_ans2 = data.Tables[0].Rows[0]["emp_ans2"].ToString();
                    employeeMasterObject.emp_email = data.Tables[0].Rows[0]["emp_email"].ToString();
                    return employeeMasterObject;
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_EMPM_NOFIND);
                    return null;
                }
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_EMPM_NOFIND);
                return null;
            }
        }

        public static Empm Read(string connectionString, string userName, string password, Dber dberr)
        {
            try
            {
                var employeeMasterObject = new Empm();

                var query = string.Format("select * from empm where emp_uname = '{0}' and emp_pass= '{1}' ", userName, password);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to employee master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    employeeMasterObject.emp_no = data.Tables[0].Rows[0]["emp_id"].ToString();
                    employeeMasterObject.emp_fname = data.Tables[0].Rows[0]["emp_fname"].ToString();
                    employeeMasterObject.emp_mname = data.Tables[0].Rows[0]["emp_mname"].ToString();
                    employeeMasterObject.emp_lname = data.Tables[0].Rows[0]["emp_lname"].ToString();
                    employeeMasterObject.emp_phn = data.Tables[0].Rows[0]["emp_phn"].ToString();
                    employeeMasterObject.emp_addr1 = data.Tables[0].Rows[0]["emp_addr1"].ToString();
                    employeeMasterObject.emp_addr2 = data.Tables[0].Rows[0]["emp_addr2"].ToString();
                    employeeMasterObject.emp_city = data.Tables[0].Rows[0]["emp_city"].ToString();
                    employeeMasterObject.emp_state = data.Tables[0].Rows[0]["emp_state"].ToString();
                    employeeMasterObject.emp_zip = data.Tables[0].Rows[0]["emp_zip"].ToString();
                    employeeMasterObject.emp_uname = data.Tables[0].Rows[0]["emp_uname"].ToString();
                    employeeMasterObject.emp_pass = data.Tables[0].Rows[0]["emp_pass"].ToString();
                    employeeMasterObject.emp_pvg = Convert.ToInt32(data.Tables[0].Rows[0]["emp_pvg"]);
                    employeeMasterObject.emp_mngr = data.Tables[0].Rows[0]["emp_mngr"].ToString();
                    employeeMasterObject.emp_brnch = data.Tables[0].Rows[0]["emp_brnch"].ToString();
                    employeeMasterObject.emp_secq1 = data.Tables[0].Rows[0]["emp_secq1"].ToString();
                    employeeMasterObject.emp_ans1 = data.Tables[0].Rows[0]["emp_ans1"].ToString();
                    employeeMasterObject.emp_secq2 = data.Tables[0].Rows[0]["emp_secq2"].ToString();
                    employeeMasterObject.emp_ans2 = data.Tables[0].Rows[0]["emp_ans2"].ToString();
                    employeeMasterObject.emp_ans2 = data.Tables[0].Rows[0]["emp_ans2"].ToString();
                    employeeMasterObject.emp_email = data.Tables[0].Rows[0]["emp_email"].ToString();
                    return employeeMasterObject;
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_EMPM_NOFIND);
                    return null;
                }
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_EMPM_NOFIND);
                return null;
            }
        }
        public static bool deactivateEmployee(string connectionString, String empNo, String deacType, Dber dberr)
        {
            try
            {
                var query = string.Format(@"UPDATE [SBS].[dbo].[EMPM]
                                               SET [EMP_PVG] = {0} WHERE [EMP_ID] = {1}", deacType, empNo);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_EMP_CUS_DELETE);
                return false;
            }
        }
        public static String getEmpNumberFromEmpId(string connectionString, string emp_id, Dber dberr)
        {
            try
            {
                // put query here, and return employee number
                return "1234";
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_EMPM_NOFIND);
                return " ";
            }
        }


        public static Empm GetEmployeeObjectFromUserName(string connectionString, string userName, Dber dberr)
        {
            try
            {
                var customerMasterObject = new Cstm();
                var query = string.Format("select * from empm where emp_uname = '{0}'", userName);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to customer master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    return GetEmpmObject(data.Tables[0].Rows[0]);
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
            var query = string.Format("select * from Empm");
            return DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

        }

        public static DataSet GetInternalUserList(string connectionString, Dber dberr)
        {
            var query = string.Format("select * from Empm where emp_pvg < 5 and emp_pvg > 2");
            return DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
        }

        public static int Create(string connectionString, Empm dataObject, Dber dberr)
        {
            try
            {
                var query = string.Format(@"INSERT INTO [SBS].[dbo].[EMPM]
                    ([EMP_FNAME],[EMP_MNAME],[EMP_LNAME],[EMP_ADDR1],[EMP_ADDR2]
                    ,[EMP_ZIP],[EMP_CITY],[EMP_STATE],[EMP_BRNCH],[EMP_PHN],[EMP_EMAIL]
                    ,[EMP_MNGR],[EMP_PVG],[EMP_SECQ1],[EMP_ANS1],[EMP_SECQ2],[EMP_ANS2]
                    ,[EMP_UNAME],[EMP_PASS])
                    OUTPUT INSERTED.EMP_ID
                    VALUES
                    ('{0}' ,'{1}' ,'{2}' ,'{3}','{4}'  ,'{5}','{6}' ,'{7}' ,'{8}' ,'{9}' ,'{10}' ,'{11}' ,'{12}' ,'{13}' 
                    ,'{14}' ,'{15}' ,'{16}' ,'{17}', '{18}')",
                    dataObject.emp_fname, dataObject.emp_mname, dataObject.emp_lname, dataObject.emp_addr1, dataObject.emp_addr2,
                    dataObject.emp_zip, dataObject.emp_city, dataObject.emp_state, dataObject.emp_brnch, dataObject.emp_phn,
                    dataObject.emp_email, dataObject.emp_mngr, dataObject.emp_pvg, dataObject.emp_secq1, dataObject.emp_ans1,
                    dataObject.emp_secq2, dataObject.emp_ans2, dataObject.emp_uname, dataObject.emp_pass);
                var employeeId =  (int)DbAccess.ExecuteScalar(connectionString, CommandType.Text, query);
                UpdateUserId(connectionString, employeeId, dberr);
                UpdatePKIInformation(connectionString, employeeId.ToString(), dberr);
                return employeeId;
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_ACTM_NOFIND);
                return -1;
            }
        }
        public static bool Update(string connectionString, Empm dataObject, Dber dberr)
        {
            throw new NotImplementedException();
        }

        public static bool UpdatePassword(string connectionString, string userId, string password, Dber dberr)
        {
            try
            {
                var query = string.Format("update empm set emp_pass = '{0}' where emp_id = {1}", password, userId);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_FAIL_UPDATE_PWD);
                return false;
            }
        }

        private static void UpdatePKIInformation(string connectionString, string employeeNumber, Dber dberr)
        {
            var pkiServiceObject = new Security.PKIService();
            var pkiObject = new Pkit
            {
                cs_no = employeeNumber,
                private_key = pkiServiceObject.PrivateKey,
                public_key = pkiServiceObject.PublicKey
            };
            PkitD.Create(connectionString, pkiObject, dberr);
        }

        private static bool UpdateUserId(string connectionString, int employeeId, Dber dberr)
        {
            try
            {
                var query = string.Format(@"UPDATE [SBS].[dbo].[EMPM]
                                               SET 
                                                   [EMP_UNAME] = '{0}'
                                             WHERE EMP_ID = {0}", employeeId);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_EMPM_UPDATE); 
                return false;
            }
        }
        public static bool Delete(string connectionString, string id, Dber dberr)
        {
            try
            {
                var query = string.Format("delete from empm where emp_id = {0}", id);
                return DbAccess.ExecuteNonQuery(connectionString, CommandType.Text, query) == 1;
            }
            catch (Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_EMPM_NOFIND);
                return false;
            }
        }

        private static Empm GetEmpmObject(DataRow row)
        {
            try
            {
                var employeeMasterObject = new Empm();
                employeeMasterObject.emp_no =    row["emp_id"].ToString();
                employeeMasterObject.emp_fname = row["emp_fname"].ToString();
                employeeMasterObject.emp_mname = row["emp_mname"].ToString();
                employeeMasterObject.emp_lname = row["emp_lname"].ToString();
                employeeMasterObject.emp_phn =   row["emp_phn"].ToString();
                employeeMasterObject.emp_addr1 = row["emp_addr1"].ToString();
                employeeMasterObject.emp_addr2 = row["emp_addr2"].ToString();
                employeeMasterObject.emp_city =  row["emp_city"].ToString();
                employeeMasterObject.emp_state = row["emp_state"].ToString();
                employeeMasterObject.emp_zip =   row["emp_zip"].ToString();
                employeeMasterObject.emp_uname = row["emp_uname"].ToString();
                employeeMasterObject.emp_pass =  row["emp_pass"].ToString();
                employeeMasterObject.emp_pvg =  Convert.ToInt32(row["emp_pvg"]);
                employeeMasterObject.emp_mngr =  row["emp_mngr"].ToString();
                employeeMasterObject.emp_brnch = row["emp_brnch"].ToString();
                employeeMasterObject.emp_secq1 = row["emp_secq1"].ToString();
                employeeMasterObject.emp_ans1 =  row["emp_ans1"].ToString();
                employeeMasterObject.emp_secq2 = row["emp_secq2"].ToString();
                employeeMasterObject.emp_ans2 =  row["emp_ans2"].ToString();
                employeeMasterObject.emp_ans2 =  row["emp_ans2"].ToString();
                employeeMasterObject.emp_email = row["emp_email"].ToString();
                return employeeMasterObject;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
