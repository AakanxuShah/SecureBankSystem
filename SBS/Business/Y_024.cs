using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Y_024
    {
        Cp_Txnm tx;
        Data.Dber dberr;
        String result;
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
        String TXID;
        String cusNo;
        Boolean error = false;
        public Y_024(String txid, String connectionString, String cus_no, String pwd)
        {
            dberr = new Data.Dber();
            this.TXID = txid;
            processTransaction(connectionString, cus_no, pwd, dberr);

        }
        private int processTransaction(String connectionString, String cus_no, String pwd, Data.Dber dberr)
        {
            Cp_Txnm tx = new Cp_Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            if(Validation.employeeInitiatedTxn(connectionString, cus_no) == 0)
            {
                Cp_Empm cpEmpm = new Cp_Empm(connectionString, cus_no, dberr);
                if(dberr.ifError())
                {
                    resultP = dberr.getErrorDesc(connectionString);
                    return -1;
                }
                if(cpEmpm.empmP.emp_pvg == 5)
                {
                    dberr.setError(Mnemonics.DbErrorCodes.TXERR_ADMIN_PWD_NOCHANGE);
                    resultP = dberr.getErrorDesc(connectionString);
                    return -1;
                }
                if(!Data.EmpmD.UpdatePassword(connectionString, cus_no, pwd, dberr))
                {
                    resultP = dberr.getErrorDesc(connectionString);
                    return -1;
                }
                resultP = "Password Changed successfully!";
                return 0;
            }
            Cp_Cstm cstm = new Cp_Cstm(connectionString, cus_no, dberr);
            if (cstm.cstmP != null)
                cstm.updatePassword(connectionString, cus_no, pwd, dberr);
            if (dberr.ifError())
            {
                dberr = new Data.Dber();
                if(!Data.EmpmD.UpdatePassword(connectionString, cus_no, pwd, dberr))
                {
                    dberr.setError(Mnemonics.DbErrorCodes.TXERR_PWD_NOUPDATE);
                    resultP = dberr.getErrorDesc(connectionString);
                    return -1;
                }
            }
            //------------------------------
            //Entity.Cstm cstm = Data.CstmD.Read(connectionString, acct.actmP.cs_no1, dberr);
            String mailResponse = "";
            if (!Security.OTPUtility.SendMail("SBS", "group2csefall2015@gmail.com",
                cstm.cstmP.cs_fname + cstm.cstmP.cs_mname + cstm.cstmP.cs_lname, cstm.cstmP.cs_email,
                "Update from SBS", "Password updated via transaction: "+ tx.txnmP.tran_desc))
            {
                mailResponse = "Mail sent.";
            }
            //-------------------------------
            resultP = "Password Changed successfully!" + mailResponse;
            //resultP = "Password Updated Successfully!";
            return 0;
        }
    }
}
