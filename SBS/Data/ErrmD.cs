using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace Data
{
    public static class ErrmD
    {
        public static Errm Read(string connectionString, string err_id)
        {
            try
            {
                var ErrorMasterObject = new Errm();

                var query = string.Format("select * from Errm where err_code = '{0}'", err_id);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to Error master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    ErrorMasterObject.err_id = data.Tables[0].Rows[0]["err_id"].ToString();
                    ErrorMasterObject.err_desc = data.Tables[0].Rows[0]["err_desc"].ToString();
                    ErrorMasterObject.err_code = data.Tables[0].Rows[0]["err_code"].ToString();

                    return ErrorMasterObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet ReadAll(string connectionString)
        {
            var query = string.Format("select * from Errm");
            return DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
        }
        public static int Create(string connectionString, Errm dataObject)
        {
            throw new NotImplementedException();
        }
        public static bool Update(string connectionString, Errm dataObject)
        {
            throw new NotImplementedException();
        }

        public static bool Delete(string connectionString, string id)
        {
            throw new NotImplementedException();
        }
    }
}
