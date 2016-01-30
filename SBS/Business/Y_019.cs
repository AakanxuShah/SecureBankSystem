using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Y_019
    {
        Cp_Txnm tx;
        Cp_Cstm cs;
        Data.Dber dberr;
        String result;
        String TXID;
        String cusNo;
        Privilege pvg;
        public String resultP
        {
            get
            {
                return this.result;
            }
            set
            {
                this.result = value;
            }
        }
        public Y_019(String txid, String connectionString, String cusno)
        {
            this.TXID = txid;
            dberr = new Data.Dber();
            this.cusNo = cusno;
            int retCode = processTransaction(connectionString, this.cusNo);
        }
        private int processTransaction(String connectionString, String cusno)
        {
            this.tx = new Cp_Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "019" is successful. Return if error encountered
            if (dberr.ifError())
            {
                resultP = dberr.getErrorDesc(connectionString);
                return -1;
            }
            cs = new Cp_Cstm(connectionString, cusno, dberr);
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            /*
            if (tx.txnmP.tran_fin_type.Equals("Y"))
            {
                // Write to FINHIST table
                Entity.Finhist fhist = new Entity.Finhist(cs.cstmP.cs_no, "0", this.tx.txnmP.tran_desc,
                    0, 0, "0", "0", "0", "0");
                Data.FinhistD.Create(connectionString, fhist, dberr);
            }
            else
            {
                // Write to NFINHIST table
                Entity.Nfinhist nFhist = new Entity.Nfinhist(cs.cstmP.cs_no, "0", this.tx.txnmP.tran_desc, "0", "0", "0");
                Data.NfinhistD.Create(connectionString, nFhist, dberr);
            }*/
            resultP = cs.cstmP.cs_no + "|" + cs.cstmP.cs_type + "|" + cs.cstmP.cs_fname + "|" + cs.cstmP.cs_mname + "|" + cs.cstmP.cs_lname
                 + "|" + cs.cstmP.cs_addr1 + "|" + cs.cstmP.cs_addr2 + "|" + cs.cstmP.cs_city + "|" + cs.cstmP.cs_state + "|" + cs.cstmP.cs_zip
                  + "|" + cs.cstmP.cs_branch + "|" + cs.cstmP.cs_phn + "|" + cs.cstmP.cs_email + "|" + cs.cstmP.cs_uid
                  + "|" + cs.cstmP.cs_secq1 + "|" + cs.cstmP.cs_ans1 + "|" + cs.cstmP.cs_secq2 + "|" + cs.cstmP.cs_ans2 + "|"
                  + cs.cstmP.cs_secq3 + "|" + cs.cstmP.cs_ans3 + "|" + cs.cstmP.cs_access+"|"+cs.cstmP.cs_uname+"|"+cs.cstmP.cs_pass;
            return 0;
        }
    }
}
