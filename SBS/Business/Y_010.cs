using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Data;
using Mnemonics;

namespace Business
{
    // Code for BALANE INQUIRY transaction
    class Y_010
    {
        String TXID;
        String error;
        Cp_Actm acct;
        Cp_Txnm tx;
        Privilege pvg;
        Sequence seq;
        Data.Dber dberr;
        String result;
        public String resultGet
        {
            get
            {
                return this.result;
            }
        }
        Boolean errorBool;
        public Boolean errorBoolP
        {
            get
            {
                return errorBool;
            }
            set
            {
                errorBool = value;
            }
        }
        DataSet resultSet;
        public DataSet resultSetP
        {
            get
            {
                return this.resultSet;
            }
            set
            {
                this.resultSet = value;
            }
        }
        public String resultP { get; set; }
        public Y_010(String connectionString, String txid)
        {
            dberr = new Dber();
            this.TXID = txid;
            tx = new Cp_Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                errorBoolP = true;
                resultSetP = null;
            }
        }
        public Y_010(String txid, String connectionString, String acc_no)
        {
            try
            {
                this.TXID = txid;
                dberr = new Data.Dber(); // change to Data.Dber
                processTransaction(connectionString, acc_no, dberr);
                // seq will generate and store transaction reference no.
                seq = new Sequence(TXID);
            }
            catch(Exception e)
            {
                error = e.ToString();
            }
        }
        private int processTransaction(string connectionString, String acc_no, Data.Dber dberr)
        {
            tx = new Cp_Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            acct = new Cp_Actm(connectionString, acc_no, dberr);
            // Check if ACTM fetch for account number acc_no is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            // Verify if account has the privilege to execute the transaction
            pvg = new Privilege(tx.txnmP.tran_pvga, tx.txnmP.tran_pvgb, acct.actmP.ac_pvg);
            if(!pvg.verifyInitPrivilege(dberr))
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            if (!pvg.verifyApprovePrivilege())
            {
                String inData = this.TXID + "|" + acct.actmP.ac_no;
                if (pvg.writeToPendingTxns(connectionString, acct.actmP.ac_no, "0", acct.actmP.cs_no1, tx.txnmP.tran_pvgb.ToString(),
                    tx.txnmP.tran_desc, "0", 0, 0, tx.txnmP.tran_id, inData, dberr) != 0)
                {
                    resultP = dberr.getErrorDesc(connectionString);
                    return -1;
                }
                resultP = Mnemonics.DbErrorCodes.MSG_SENT_FOR_AUTH;
                return 0;
            }
            // Store transaction in hisory table. Determine which history table to store in based on tx.txnmP.tran_fin_type
            if (tx.txnmP.tran_fin_type.Equals("Y"))
            {
                // Write to FINHIST table
                Entity.Finhist fhist = new Entity.Finhist(this.acct.actmP.ac_no, "0", this.tx.txnmP.tran_desc,
                    0, 0, Convert.ToString(this.acct.actmP.ac_bal), "0", "0","0");
                Data.FinhistD.Create(connectionString, fhist, dberr);
            }
            else
            {
                // Write to NFINHIST table
                Entity.Nfinhist nFhist = new Entity.Nfinhist(this.acct.actmP.ac_no, "0", this.tx.txnmP.tran_desc, "0", "0","0");
                Data.NfinhistD.Create(connectionString, nFhist, dberr);
            }
            resultP = Convert.ToString(acct.actmP.ac_bal - acct.actmP.ac_hold);
            return 0;
        }
        public DataSet fetchMultipleAccounts(String connectionString, String cusno)
        {
            Cp_Actm ac = new Cp_Actm();
            this.resultSet = ac.fetchAccountsFromCusNo(connectionString, cusno, this.tx.txnmP.tran_pvga, dberr);
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                errorBoolP = true;
                return (new DataSet(result));
            }
            if (this.resultSet == null)
            {
                dberr.setError(Mnemonics.DbErrorCodes.TXERR_NO_USER);
                result = dberr.getErrorDesc(connectionString);
                errorBoolP = true;
                return (new DataSet(result));
            }
            return resultSet;
        }
        private Boolean updateTransactedData()
        {
            return true;
        }
        public String getOutput()
        {
            return result;
            /*if(dberr.ifError())
            {
                return dberr.getErrorDesc();
            }
            else
            {
                return Convert.ToString(acct.getBalance());
            }*/
        }
    }
}
