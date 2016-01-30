using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace Data
{
    public static class ErrhistD
    {
        public static Errhist Read(string connectionString, string ref_no)
        {
            try
            {
                var ErrorHistryMasterObject = new Errhist();

                var query = string.Format("select * from Errhist where ref_no = {0}", ref_no);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to ErrorHistry master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    ErrorHistryMasterObject.ref_no = data.Tables[0].Rows[0]["ref_no"].ToString(); 
                    ErrorHistryMasterObject.tran_date = data.Tables[0].Rows[0]["tran_date"].ToString(); 
                    ErrorHistryMasterObject.ac_no = data.Tables[0].Rows[0]["ac_no"].ToString(); 
                    ErrorHistryMasterObject.apprv_empid = data.Tables[0].Rows[0]["apprv_empid"].ToString(); 
                    ErrorHistryMasterObject.err_desc = data.Tables[0].Rows[0]["err_desc"].ToString(); 
                    ErrorHistryMasterObject.init_empid = data.Tables[0].Rows[0]["init_empid"].ToString(); 
                    ErrorHistryMasterObject.tran_desc = data.Tables[0].Rows[0]["tran_desc"].ToString(); 
                    ErrorHistryMasterObject.tran_timestamp = data.Tables[0].Rows[0]["tran_timestamp"].ToString(); 

                    return ErrorHistryMasterObject;
                }

                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet ReadAll(string connectionString)
        {
            var query = string.Format("select * from ");
            return  DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
        }
        public static int Create(string connectionString, Errhist dataObject)
        {
            throw new NotImplementedException();
        }
        public static bool Update(string connectionString, Errhist dataObject)
        {
            throw new NotImplementedException();
        }

        public static bool Delete(string connectionString, string id)
        {
            throw new NotImplementedException();
        }
    }
}
