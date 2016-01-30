using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Entity
{
    public class Actm
    {
        
        public String ac_no { get; set; }
        public String cs_no1 { get; set; }
        public String cs_no2 { get; set; }
        public String ac_type { get; set; }
        public Decimal ac_bal { get; set; }
        public Decimal ac_hold { get; set; }
        public Int32 ac_pvg { get; set; }
        public String ac_dr_flag { get; set; }
        public String ac_cr_flag { get; set; }
        public String ac_open_dt { get; set; }
        public bool ac_activ { get; set; }
        public Actm()
        { }
        public Actm(String cs1, String cs2, String acType, Decimal bal, Decimal hold,
            Int32 pvg, String drFlag, String crFlag, String openDate, Boolean activeFlag)
        {
            this.cs_no1 = cs1;
            this.cs_no2 = cs2;
            this.ac_type = acType;
            this.ac_bal = bal;
            this.ac_hold = hold;
            this.ac_pvg = pvg;
            this.ac_dr_flag = drFlag;
            this.ac_cr_flag = crFlag;
            this.ac_open_dt = openDate;
            this.ac_activ = activeFlag;
        }
    }
}
