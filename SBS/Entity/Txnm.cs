using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Txnm
    {
        public string tran_id { get; set; }
        public string tran_desc { get; set; }
        public int tran_pvga { get; set; }
        public int tran_pvgb { get; set; }
        public string tran_fin_type { get; set; }
        public string tran_code { get; set; }
    }
}
