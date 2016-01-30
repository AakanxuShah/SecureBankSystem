using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Nfinhist
    {
        private static String DATE_FORMAT = "en-US";
        public String ac_no { get; set; }
        public String ref_no { get; set; }
        public String tran_date { get; set; }
        public String tran_timestamp { get; set; }
        public String tran_desc { get; set; }
        public String init_empid { get; set; }
        public String apprv_empid { get; set; }
        public String init_csno { get; set; }
        public Nfinhist()
        { }
        public Nfinhist(String acno, String refno, String trandesc, String initempid, String apprvempid,String initcsno)
        {
            DateTime dt = DateTime.Now;
            this.ac_no = acno;
            this.ref_no = refno;
            this.tran_date = dt.ToString();
            this.tran_timestamp = dt.ToString();
            this.tran_desc = trandesc;
            this.init_empid = initempid;
            this.apprv_empid = apprvempid;
            this.init_csno = initcsno;
        }
    }
}
