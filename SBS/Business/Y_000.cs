using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Data;
/*
 * ==========================
 *   USER LOGIN Transaction
 * ==========================
 */
namespace Business
{
    class Y_000
    {
        Cp_Cstm cstm;
        String TXID;
        String userid;
        String pwd;
        Data.Dber dberr;
        Cp_Txnm txnm;
        DataSet resultSet;
        public DataSet resultSetGet
        {
            get
            {
                return this.resultSet;
            }
        }
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
        Boolean error;
        public Boolean errorGet
        {
            get
            {
                return this.error;
            }
        }
        public Y_000(String txid, String connectionString, String usr, String pwd)
        {
            this.error = false;
            this.TXID = txid;
            this.userid = usr;
            this.pwd = pwd;
            this.dberr = new Data.Dber();
            this.result = " ";
            if(processTransaction(connectionString, usr, pwd) != 0)
            {
                this.error = true;
            }
        }
        private int processTransaction(String connectionString, String usr, String pwd)
        {
            /*
             * initiate select query on CSTM, to fetch cus_no for the usr and pwd combination
             * "select cus_no from CSTM where user = usr and pwd = pwd"
             * Using the retrieved cus_no, fetch all account numbers from cstm, and store the retrieved acc nos. 
             * as "|" delimited string in result. For errors, update error with "true"
            */
            /*Entity.Cstm cs = Data.CstmD.Read(connectionString, usr, pwd, dberr);
            if (dberr.ifError())
            {
                Cp_Empm empm = new Cp_Empm(connectionString, usr, pwd, dberr);
                if (dberr.ifError())
                {
                    result = dberr.getErrorDesc(connectionString);
                    return -1;
                }
            }
            else
            {
                Cp_Actm ac = new Cp_Actm();
                this.resultSet = ac.fetchAccountsFromCusNo(connectionString, cs.cs_no, dberr);
                if (dberr.ifError())
                {
                    result = dberr.getErrorDesc(connectionString);
                    return -1;
                }
                if(this.resultSet == null)
                {
                    dberr.setError(Mnemonics.DbErrorCodes.TXERR_NO_USER);
                    result = dberr.getErrorDesc(connectionString);
                    return -1;
                }
            }
            return 0;*/
            txnm = new Cp_Txnm(connectionString, this.TXID, dberr);
            if (dberr.ifError())
            {
                resultP = dberr.getErrorDesc(connectionString);
                return -1;
            }
            cstm = new Cp_Cstm(connectionString, usr, pwd, dberr);
            if (dberr.ifError())
            {
                dberr = new Dber();
                Cp_Empm empm = new Cp_Empm(connectionString, usr, pwd, dberr);
                if (dberr.ifError())
                {
                    result = dberr.getErrorDesc(connectionString);
                    return -1;
                }
                if (txnm.txnmP.tran_fin_type.Equals("Y"))
                {
                    // Write to FINHIST table
                    Entity.Finhist fhist = new Entity.Finhist("0", "0", this.txnm.txnmP.tran_desc,
                        0, 0, "0", empm.empmP.emp_no, "0", "0");
                    Data.FinhistD.Create(connectionString, fhist, dberr);
                }
                else
                {
                    // Write to NFINHIST table
                    Entity.Nfinhist nFhist = new Entity.Nfinhist("0", "0", 
                        this.txnm.txnmP.tran_desc, empm.empmP.emp_no, "0", "0");
                    Data.NfinhistD.Create(connectionString, nFhist, dberr);
                }
                String empNo = empm.empmP.emp_no;
                String pvgLevel = Convert.ToString(empm.empmP.emp_pvg);
                String empFname = empm.empmP.emp_fname;
                String empLname = empm.empmP.emp_lname;
                resultP = empNo + "|" + empFname + "|" + empLname + "|" + pvgLevel + "|" + empm.empmP.emp_email;
                return 0;
            }
            //-----------
            if (cstm.cstmP.cs_type.Equals("0"))
            {
                dberr.setError(Mnemonics.DbErrorCodes.TXERR_INACTIVE_CUSTOMER);
                resultP = dberr.getErrorDesc(connectionString);
                return -1;
            }
            //--------------
            if (txnm.txnmP.tran_fin_type.Equals("Y"))
            {
                // Write to FINHIST table
                Entity.Finhist fhist = new Entity.Finhist("0", "0", this.txnm.txnmP.tran_desc,
                    0, 0, "0", "0", "0", this.cstm.cstmP.cs_no);
                Data.FinhistD.Create(connectionString, fhist, dberr);
            }
            else
            {
                // Write to NFINHIST table
                Entity.Nfinhist nFhist = new Entity.Nfinhist("0", "0", this.txnm.txnmP.tran_desc, "0", "0", this.cstm.cstmP.cs_no);
                Data.NfinhistD.Create(connectionString, nFhist, dberr);
            }
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            String cusNo = cstm.cstmP.cs_no;
            String csPvgLevel = cstm.cstmP.cs_type;
            String csFname = cstm.cstmP.cs_fname;
            String csLname = cstm.cstmP.cs_lname;
            resultP = cusNo + "|" + csFname + "|" + csLname + "|" + csPvgLevel + "|" + cstm.cstmP.cs_email;
            return 0;
        }
        public String getOutput()
        {
            return this.result;
        }
    }
}
