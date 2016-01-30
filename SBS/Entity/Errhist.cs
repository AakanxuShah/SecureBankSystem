using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Errhist
    {
        public String ac_no { get; set; }
        public String ref_no { get; set; }
        public String tran_date { get; set; }
        public String tran_timestamp { get; set; }
        public String tran_desc { get; set; }
        public String err_desc { get; set; }
        public String init_empid { get; set; }
        public String apprv_empid { get; set; }
    }
}
