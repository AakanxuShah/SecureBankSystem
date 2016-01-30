using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Cp_Cstm
    {
        Entity.Cstm cstm;
        public Entity.Cstm cstmP
        {
            get
            {
                return this.cstm;
            }
            set
            {
                this.cstm = value;
            }
        }
        public Cp_Cstm(string connectionString, String usr, String pwd, Data.Dber dberr)
        {
            // fetch all details for ac_no = acno.
            cstmP = Data.CstmD.Read(connectionString, usr, pwd, dberr);
        }
        public Cp_Cstm(string connectionString, String cusno, Data.Dber dberr)
        {
            // fetch all details for ac_no = acno.
            cstmP = Data.CstmD.Read(connectionString, cusno, dberr);
        }
        public Cp_Cstm(String a, String b, String c, String d, String e, String f, String g, String h, String i, 
            String j, String k, String l, String m, String n, String o, String p, String q, String r, String s, String t, String u)
        {
            cstmP = new Entity.Cstm(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u);
        }
        public Boolean updatePassword(String connectionString, String cus_no, String pwd, Data.Dber dberr)
        {
            return Data.CstmD.UpdatePassword(connectionString, this.cstmP.cs_no, pwd, dberr);
        }
    }
}
