using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Cp_Finhist
    {
        String ac_no;
        String ref_no;
        String tran_date;
        String tran_timestamp;
        String tran_desc;
        Decimal dr_amt;
        Decimal cr_amt;
        String rem_bal;
        String init_empid;
        String apprv_empid;
        public Boolean insertIntoFinhist()
        {
            return true; // remove later
        }
    }
}
