using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mnemonics;

/*
 * INTERNAL TRANSFER
*/
namespace Business
{
    class Y_013
    {
        String TXID;
        String result;
        public String resultP{ get{return this.result;} set{this.result = value;}}
        Cp_Actm acct1, acct2, acct_init;
        Cp_Txnm tx;
        //Privilege pvg;
        Boolean error = false;
        Sequence seq;
        Data.Dber dberr;
        Decimal changeAmount;
        Privilege pvg;
        //String loginAcc;
        Boolean newInitiator = false;
        public Y_013(String txid, String connectionString, String ac1, String ac2, Decimal amount, String loginAc)
        {
            try
            {
                //this.error = "N";
                dberr = new Data.Dber();
                this.TXID = txid;
                // seq will generate and store transaction reference no.
                seq = new Sequence(TXID);
                this.changeAmount = amount;
                //processTransaction(connectionString, ac1, ac2, amount);
                /*if (!ac1.Equals(loginAc))
                {
                    newInitiator = true;
                }*/
                if (processTransaction(connectionString, ac1, ac2, amount, loginAc) != 0)
                {
                    this.error = true;
                }
            }
            catch(Exception e)
            {
                this.result = e.ToString();
                this.error = true;
            }
        }
        public Boolean basicValidationError()
        {
            return this.error;
        }
        private int processTransaction(string connectionString, String ac1, String ac2, Decimal amount, String loginAc)
        {
            tx = new Cp_Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            //Check if it is a Banker initiated transaction
            if(Validation.employeeInitiatedTxn(connectionString, loginAc)==0)
            {
                this.newInitiator = true;
            }
            //From account and To account cannot be the same
            if(Validation.validateFromToAccSame(ac1, ac2)!=0)
            {
                dberr.setError(Mnemonics.DbErrorCodes.TXERR_FROM_TO_AC_SAME);
                resultP = dberr.getErrorDesc(connectionString);
                return -1;
            }
            //Validations if Banker processes the txn
            if (this.newInitiator)
            {
                //From Account and To Account should belong to the same customer
                if (Validation.accountsBelongToSameCus(connectionString, ac1, ac2) != 0)
                {
                    dberr.setError(Mnemonics.DbErrorCodes.TXERR_INTERNAL_TFR_EMP_FROM_TO_ACC_DIFF_CUS);
                    resultP = dberr.getErrorDesc(connectionString);
                    return -1;
                }
                //Check if from Customer is Active (Enabled)
                if (!Validation.isActiveCustomerUsingAcc(connectionString, ac1))
                {
                    resultP = dberr.getErrorDesc(connectionString);
                    return -1;
                }
                //Check if to Customer is Active (Enabled)
                if (!Validation.isActiveCustomerUsingAcc(connectionString, ac2))
                {
                    resultP = dberr.getErrorDesc(connectionString);
                    return -1;
                }
            }
            //Validations if customer processes the transaction.
            else
            {
                //From account must belong the customer who has logged in
                if (Validation.validateCustomerSelfAccount(connectionString, loginAc, ac1) != 0)
                {
                    dberr.setError(Mnemonics.DbErrorCodes.TXERR_INTERNAL_TFR_FROM_DIFF_CUS);
                    resultP = dberr.getErrorDesc(connectionString);
                    return -1;
                }
                //To account must also belong to the logged in customer
                if (Validation.validateCustomerSelfAccount(connectionString, loginAc, ac2) != 0)
                {
                    dberr.setError(Mnemonics.DbErrorCodes.TXERR_INTERNAL_TFR_TO_DIFF_CUS);
                    resultP = dberr.getErrorDesc(connectionString);
                    return -1;
                }
            }
            /*this.acct1 = new Cp_Actm(connectionString, ac1, dberr);
            // Check if ACTM fetch for account number acc_no is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            this.acct2 = new Cp_Actm(connectionString, ac2, dberr);
            // Check if ACTM fetch for account number acc_no is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            if(!acct1.actmP.cs_no1.Equals(acct2.actmP.cs_no1))
            {
                dberr.setError(Mnemonics.DbErrorCodes.TXERR_MISMATCH_CUSTOMER);
                resultP = dberr.getErrorDesc(connectionString);
                return -1;
            }*/
            String initEmpNumber = "0";
            String initCustomer = "0";
            if (this.newInitiator)
            {
                initEmpNumber = loginAc;
                Cp_Empm cpEmpm = new Cp_Empm(connectionString, loginAc, dberr);
                pvg = new Privilege(tx.txnmP.tran_pvga, tx.txnmP.tran_pvgb, cpEmpm.empmP.emp_pvg);
                /*this.acct_init = new Cp_Actm(connectionString, loginAc, dberr);
                // Check if ACTM fetch for account number acc_no is successful. Return if error encountered
                if (dberr.ifError())
                {
                    Cp_Empm em = new Cp_Empm(connectionString, loginAc, " ", dberr);
                    if (dberr.ifError())
                    {
                        result = dberr.getErrorDesc(connectionString);
                        return -1;
                    }
                    initEmpNumber = em.empNoP;
                }
                else
                {
                    initCustomer = this.acct_init.actmP.cs_no1;
                }*/
            }
            else
            {
                //this.acct_init = this.acct1;
                initCustomer = loginAc; // this.acct_init.actmP.cs_no1;
                Cp_Actm cpActm = new Cp_Actm(connectionString, ac1, dberr);
                pvg = new Privilege(tx.txnmP.tran_pvga, tx.txnmP.tran_pvgb, cpActm.actmP.ac_pvg);
            }
            // Verify if account has the privilege to execute the transaction
            //pvg = new Privilege(tx.txnmP.tran_pvga, tx.txnmP.tran_pvgb, acct_init.actmP.ac_pvg);
            if (!pvg.verifyInitPrivilege(dberr))
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            if (!pvg.verifyApprovePrivilege())
            {
                String inData = this.TXID + "|" + acct1.actmP.ac_no + "|" + acct2.actmP.ac_no + "|" + this.changeAmount.ToString();
                if (pvg.writeToPendingTxns(
                    connectionString,               /* connection string */
                    acct1.actmP.ac_no,              /* account 1 */
                    acct2.actmP.ac_no,              /* account 2 */
                    initCustomer,                   /* initiating customer number */
                    tx.txnmP.tran_pvgb.ToString(),  /* transaction approve privilege */
                    tx.txnmP.tran_desc,             /* transaction description */
                    initEmpNumber,                  /* initiating employee number */
                    this.changeAmount,              /* debit amount */
                    0,                              /* credit amount */
                    tx.txnmP.tran_id,               /* transaction id (not tran code) */
                    inData,                         /* incoming transaction string in XSwitch */
                    dberr                           /* error tracking object */
                    ) != 0)
                {
                    resultP = dberr.getErrorDesc(connectionString);
                    return -1;
                }
                resultP = Mnemonics.DbErrorCodes.MSG_SENT_FOR_AUTH;
                return 0;
            }

                /*if (pvg.isPending)
                {
                    Entity.Pendtxn pending = new Entity.Pendtxn(0, seq.getSequence(), this.acct1.actmP.ac_no, acct2.actmP.ac_no,
                        Convert.ToString(this.tx.txnmP.tran_pvgb), this.acct1.actmP.cs_no1, "0", this.changeAmount, this.tx.txnmP.tran_desc, this.tx.txnmP.tran_id);
                    Data.PendtxnD.Create(connectionString, pending);
                    if (dberr.ifError())
                    {
                        result = dberr.getErrorDesc(connectionString);
                        return -1;
                    }
                    else
                    {
                        dberr.setError(Mnemonics.TxnCodes.TX_SENT_TO_APPROVER);
                        return -1;
                    }
                }
                else
                {
                    result = dberr.getErrorDesc(connectionString);
                    return -1;
                }
            }*/
            resultP = "Transaction Processed!";
            return 0; // remove later
        }
        public String getOutput()
        {
            return this.result;
            /*if (dberr.ifError())
            {
                return dberr.getErrorDesc(connectionString);
            }
            else
            {
                return Convert.ToString(acct.getBalance());
            }*/
        }
    }
}
