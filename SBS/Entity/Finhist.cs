using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Finhist
    {
        private static String DATE_FORMAT = "en-US"; 
        public String ac_no { get; set; }
        public String ref_no { get; set; }
        public String tran_date { get; set; }
        public String tran_timestamp { get; set; }
        public String tran_desc { get; set; }
        public Decimal dr_amt { get; set; }
        public Decimal cr_amt { get; set; }
        public String rem_bal { get; set; }
        public String init_empid { get; set; }
        public String apprv_empid { get; set; }
        public String init_csno { get; set; }
        public Finhist()
        { }
        public Finhist(String acno, String refno, String trandesc, Decimal dramt,
            Decimal cramt, String rembal, String initempid, String apprvempid,String initcsno)
        {
            DateTime dt = DateTime.Now;
            this.ac_no = acno;
            this.ref_no = refno;
            this.tran_date = dt.ToString();
            this.tran_timestamp = dt.ToString();
            this.tran_desc = trandesc;
            this.dr_amt = dramt;
            this.cr_amt = cramt;
            this.rem_bal = rembal;
            this.init_empid = initempid;
            this.apprv_empid = apprvempid;
            this.init_csno = initcsno;
        }
    }
}
