using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
/*
 *  EDIT CUSTOMER INFO
 */

namespace Business
{
    class Y_014
    {
        Entity.Cstm cstm = new Entity.Cstm();
        Boolean newInitiator;
        Data.Dber dberr;
        String result;
        String TXID;
        Cp_Txnm tx;
        public Y_014(String txid, String connectionString, String a, String b, String c, String d, String e, String f, 
            String g, String j, String h, String i, String l, String m, String n, String k, String o, String p, String q, String r, 
            String s, String t, String u, String v, String w)
        {
            dberr = new Data.Dber();
            newInitiator = false;
            this.TXID = txid;
            cstm.cs_no = a;
            cstm.cs_type = b;
            cstm.cs_fname = c;
            cstm.cs_mname = d;
            cstm.cs_lname = e;
            cstm.cs_addr1 = f;
            cstm.cs_addr2 = g;
            cstm.cs_city = h;
            cstm.cs_state = i;
            cstm.cs_zip = j;
            cstm.cs_branch = k;
            cstm.cs_phn = l;
            cstm.cs_email = m;
            cstm.cs_uid = n;
            cstm.cs_secq1 = o;
            cstm.cs_ans1 = p;
            cstm.cs_secq2 = q;
            cstm.cs_ans2 = r;
            cstm.cs_secq3 = s;
            cstm.cs_ans3 = t;
            cstm.cs_access = u;
            processTransaction(connectionString, cstm);
        }
        /*
         * 1 = check for integer data
         * 2 = check for aphabetic data
         * 3 = check for special characters;
         */
        private Boolean verifyInputType(int type, String verificationData)
        {
            int countInt = 0, countAlpha = 0, countSpecial = 0;
            for (int i = 0; i < verificationData.Length; i++ )
            {
                if (Char.IsNumber(verificationData[i])) countInt++;
                else
                {
                    if (Char.IsLetter(verificationData[i])) countAlpha++;
                    else
                    {
                        countSpecial++;
                    }
                }
            }
            if (type == 1)
            {
                if (countInt > 0 && countAlpha == 0 && countSpecial == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (type == 2)
            {
                if (countInt == 0 && countAlpha > 0 && countSpecial == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (type == 3)
            {
                if (countInt > 0 || countAlpha > 0 || countSpecial > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        private int processTransaction(String connectionString, Entity.Cstm cstm)
        {
            tx = new Cp_Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            //if (!verifyInputType(1, cstm.cs_no))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSNO);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(2, cstm.cs_type))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSTYPE);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(2, cstm.cs_fname))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSFNAME);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(2, cstm.cs_mname))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSMNAME);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(2, cstm.cs_lname))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSLNAME);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(3, cstm.cs_addr1))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSADDR1);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(3, cstm.cs_addr2))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSADDR2);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(3, cstm.cs_city))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSCITY);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(2, cstm.cs_state))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSSTATE);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(1, cstm.cs_zip))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSZIP);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(1, cstm.cs_branch))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSBRNCH);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(1, cstm.cs_phn))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSPHN);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(3, cstm.cs_email))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSEMAIL);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(1, cstm.cs_uid))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSUID);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(3, cstm.cs_secq1))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSSECQ1);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(3, cstm.cs_ans1))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSANS1);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(3, cstm.cs_secq2))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSSECQ2);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(3, cstm.cs_ans2))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSANS2);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(3, cstm.cs_secq3))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSSECQ3);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!verifyInputType(3, cstm.cs_ans3))
            //{
            //    this.dberr.setError(Mnemonics.DbErrorCodes.TXERR_FMT_CUSANS3);
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            Data.CstmD.Update(connectionString, this.cstm, this.dberr);
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            if (tx.txnmP.tran_fin_type.Equals("Y"))
            {
                // Write to FINHIST table
                Entity.Finhist fhist = new Entity.Finhist(this.cstm.cs_no, "0", this.tx.txnmP.tran_desc,
                    0, 0, "0", "0", "0", "0");
                Data.FinhistD.Create(connectionString, fhist, dberr);
            }
            else
            {
                // Write to NFINHIST table
                Entity.Nfinhist nFhist = new Entity.Nfinhist(this.cstm.cs_no, "0", this.tx.txnmP.tran_desc, "0", "0", this.cstm.cs_no);
                Data.NfinhistD.Create(connectionString, nFhist, dberr);
            }
            //------------------------------
            //Entity.Cstm cstm = Data.CstmD.Read(connectionString, acct.actmP.cs_no1, dberr);
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            String mailResponse = "";
            if (!Security.OTPUtility.SendMail("SBS", "group2csefall2015@gmail.com", cstm.cs_fname + cstm.cs_mname + cstm.cs_lname,
                cstm.cs_email, "Update from SBS: you profile has been updated via trnasaction: ", tx.txnmP.tran_desc))
            {
                mailResponse = "Mail sent.";
            }
            //-------------------------------
            result = "Successful!" + mailResponse;
            return 0;
        }
        public String getOutput()
        {
            return this.result;
        }
    }
}
