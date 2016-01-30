using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * USER REGISTRATION for Online Banking
 */
namespace Business
{
    class Y_015
    {
        Entity.Cstm cstm = new Entity.Cstm();
        Int32 txnPvga = 1;
        Int32 txnPvgb = 5;
        Entity.Pendtxn pendTxn;
        Entity.Empm empm;
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
        Boolean employee = false; 
        Privilege pvg;
        Boolean error = false;

        public Y_015(String txid, String connectionString, String a1, String a2, String a3, String a4, String a5, String a6,
            String a7, String a8, String a9, String a10, String a11, String a12, String a13, String a14, String a15, String a16,
            String a17, String a18, String a19, String a20, String a21, String a22, String a23, String dummyAc, String dummyRef, String loginAc)
        {
            this.TXID = txid;
            dberr = new Data.Dber();
            //this.cusNo = loginAc;
            
            if (processTransaction(connectionString, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16,
                a17, a18, a19, a20, a21, a22, a23, dummyAc, dummyRef, loginAc) != 0)
            {
                this.error = true;
            }
            //processTransaction(connectionString);
        }
        private int processTransaction(String connectionString, String a1, String a2, String a3, String a4, String a5, String a6,
            String a7, String a8, String a9, String a10, String a11, String a12, String a13, String a14, String a15, String a16,
            String a17, String a18, String a19, String a20, String a21, String a22, String a23, String dummyAc, String dummyRef, String loginAc)
        {
            int cusPvg = 0;
            this.tx = new Cp_Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            cstm.cs_no = a1;
            cstm.cs_type = a2;
            cstm.cs_fname = a3;
            cstm.cs_mname = a4;
            cstm.cs_lname = a5;
            cstm.cs_addr1 = a6;
            cstm.cs_addr2 = a7;
            cstm.cs_zip = a8;
            cstm.cs_city = a9;
            cstm.cs_state = a10;
            cstm.cs_phn = a11;
            cstm.cs_email = a12;
            cstm.cs_uid = a13;
            cstm.cs_branch = a14;
            cstm.cs_secq1 = a15;
            cstm.cs_ans1 = a16;
            cstm.cs_secq2 = a17;
            cstm.cs_ans2 = a18;
            cstm.cs_secq3 = a19;
            cstm.cs_ans3 = a20;
            cstm.cs_access = a21;
            cstm.cs_uname = a22;
            cstm.cs_pass = a23;
            cstm.cs_merch = " ";
            // Fetch data from CSTM. if CS_ACCESS = 'N', registration can be done, else fail txn
            //Entity.Cstm cstm = Data.CstmD.Read(connectionString, this.cusNo, dberr);
            //if (dberr.ifError())
            //{
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!cstm.cs_access.Equals("N"))
            //{
            //    dberr.setError(Mnemonics.DbErrorCodes.TXERR_EXISTING_USER);
            //    return -1;
            //}
            empm = Data.EmpmD.Read(connectionString, loginAc, dberr);
            if (!dberr.ifError())
            {
                employee = true;
                dberr = new Data.Dber();
            }
            else
            {
                dberr = new Data.Dber();
                if (cstm.cs_type.Equals("A") || cstm.cs_type.Equals("1") || cstm.cs_type.Equals(" "))
                {
                    cusPvg = 1;
                }
                if (cstm.cs_type.Equals("B") || cstm.cs_type.Equals("2"))
                {
                    cusPvg = 2;
                }
            }
            if(employee)
            {
                pvg = new Privilege(this.txnPvga, this.txnPvgb, empm.emp_pvg);
            }
            else
            {
                pvg = new Privilege(this.txnPvga, this.txnPvgb, cusPvg);
            }
            if (!pvg.verifyInitPrivilege(dberr))
            {
                    result = dberr.getErrorDesc(connectionString);
                    return -1;
            }
            if (!pvg.verifyApprovePrivilege())
            {
                    String inData = this.TXID + "|" + a1 + "|" + a2 + "|" + a3 + "|" + a4 + "|" + a5 + "|" + a6 +
                        "|" + a7 + "|" + a8 + "|" + a9 + "|" + a10 + "|" + a11 + "|" + a12 + "|" + a13 + "|" + a14 + "|" + a15 +
                        "|" + a16 + "|" + a17 + "|" + a18 + "|" + a19 + "|" + a20 + "|" + a21 + "|" + a22 + "|" + a23 ;
                    if (pvg.writeToPendingTxns(
                        connectionString,               /* connection string */
                        "0",                            /* account 1 */
                        "0",                            /* account 2 */
                        "0",                            /* customer number */
                        tx.txnmP.tran_pvgb.ToString(),  /* transaction approve privilege */
                        tx.txnmP.tran_desc,             /* transaction description */
                        "0",                            /* initiating employee number */
                        0,                              /* debit amount */
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
            //else
            //{
            //int cstmId = Data.CstmD.Create(connectionString, cstm, dberr);

                // Insert new row in Customer table
            int data = Data.CstmD.Create(connectionString, cstm, dberr);
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
              // Write into history table
            
            //if (tx.txnmP.tran_fin_type.Equals("Y"))
            //{
            //        // Write to FINHIST table
            //     Entity.Finhist fhist = new Entity.Finhist(
            //       "0",                        /* Account Number */
            //        w,                          /* Reference Number */
            //        this.tx.txnmP.tran_desc,    /* Transaction Description */
            //        0,                          /* Debit Amount */
            //        0,                          /* Credit Amount */
            //        "0",                        /* Remaining Balance */
            //        "0",                        /* Initiating Employee Id */
            //         loginAc,                    /* Approve Employee Id */
            //        cstmId.ToString()                  /* Initiating Customer Number */
            //        );
            //     Data.FinhistD.Create(connectionString, fhist, dberr);
            //}
            //else
            //{
            //        // Write to NFINHIST table
            //    Entity.Nfinhist nFhist = new Entity.Nfinhist(
            //            "0",                        /* Account Number */
            //            w,                        /* Reference Number */
            //            this.tx.txnmP.tran_desc,    /* Transaction Description */
            //            "0",                        /* Initiating Employee Id */
            //            loginAc,                    /* Approve Employee Id */
            //            cstmId.ToString()           /* Initiating Customer Number */
            //            );
            //    Data.NfinhistD.Create(connectionString, nFhist, dberr);
            //}
            //if (dberr.ifError())
            //{
            //        result = dberr.getErrorDesc(connectionString);
            //        return -1;
            //}
                // Delete the Pending transaction
            if(!Data.PendtxnD.Delete(connectionString, dummyRef))
            {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_PENDTXN_DELETE);
                    result = dberr.getErrorDesc(connectionString);
                    return -1;
            }
            //}
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            //------------------------------
            //Entity.Cstm cstm = Data.CstmD.Read(connectionString, acct.actmP.cs_no1, dberr);
            String mailResponse = "";
            if (!Security.OTPUtility.SendMail("SBS", "group2csefall2015@gmail.com", cstm.cs_fname + cstm.cs_mname + cstm.cs_lname,
                cstm.cs_email, "Update from SBS", "your new User Id with us is: "+data.ToString()))
            {
                mailResponse = "Mail sent.";
            }
            //-------------------------------
            resultP = "Successful!" + mailResponse;
            return 0;
        }
    }
}
