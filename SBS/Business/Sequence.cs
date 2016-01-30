using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Sequence
    {
        private String seq_no;
        public Sequence(String call_code)
        {
            // Return newly generated sequence no. from database
        }
        public String getSequence()
        {
            return this.seq_no;
        }
    }
}
