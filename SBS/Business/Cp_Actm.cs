using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Data;

namespace Business
{
    public class Cp_Actm
    {
        Entity.Actm actm;
        Decimal newBal;
        String result;

        public String resultP
        {
            get { return result; }
            set { result = value; }
        }

        public Entity.Actm actmP 
        { 
            get
            {
                return actm;
            }
        }
        //private Decimal changeAmount;
        String[] actmParts;
        //actm = new Entity.Actm();
        public Cp_Actm()
        { }
        //[CS_NO1],[CS_NO2],[AC_TYPE],[AC_BAL],[AC_HOLD],[AC_PVG],[AC_DR_FLAG],[AC_CR_FLAG],[AC_OPEN_DT],[AC_ACTIV]
        public Cp_Actm(String connectionString, String cs1, String cs2, String acType, Decimal bal, Decimal hold,
            Int32 pvg, String drFlag, String crFlag, String openDate, Boolean activeFlag)
        {
            actm = new Entity.Actm(cs1, cs2, acType, bal, hold, pvg, drFlag, crFlag, openDate, activeFlag);
        }
        public Cp_Actm(string connectionString, String acno, Data.Dber dberr)
        {
            // fetch all details for ac_no = acno.
            actm = Data.ActmD.Read(connectionString, acno, dberr);
        }
        public DataSet fetchAccountsFromCusNo(string connectionString, String cusno, int pvg, Data.Dber dberr)
        {
            DataSet dbQuery = new DataSet();
            dbQuery = Data.ActmD.GetUserAccountBalance(connectionString, cusno, pvg, dberr);
            return dbQuery;
        }
        public Boolean getCreditAllowed()
        {
            if (this.actmP.ac_cr_flag.Equals("Y"))
                return true;
            else
                return false;
        }
        public Boolean getDebitAllowed()
        {
            if(this.actmP.ac_dr_flag.Equals("Y"))
                return true;
            else
                return false;
        }
        public void addBalance(string connectionString, Decimal changeAmount, Data.Dber dberr)
        {
            try
            {
                if (this.getCreditAllowed())
                {
                    this.newBal = this.actmP.ac_bal + changeAmount;
                    this.actmP.ac_bal = this.newBal;
                    //resultP = this.newBal.ToString();
                    // Check if newBal is at most as much as the maximum balance allowed for the account through ACPRM table.

                    // Update newBal in Actm.
                    //Boolean dbCode = Data.ActmD.UpdateAccountBalance(connectionString, this.actmP.ac_no, this.actmP.ac_bal, dberr);
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.TXERR_NO_CREDIT);
                    resultP = dberr.getErrorDesc(connectionString);
                }
            }
            catch(Exception e)
            {
                dberr.setError(Mnemonics.DbErrorCodes.TXERR_NO_DEBIT);
                resultP = dberr.getErrorDesc(connectionString);
            }
        }
        public void updateBalance(String connectionString, Data.Dber dberr)
        {
            try
            {
                Boolean dbCode = Data.ActmD.UpdateAccountBalance(connectionString, this.actmP.ac_no, this.actmP.ac_bal, dberr);
            }
            catch(Exception ex)
            {
                dberr.setError(Mnemonics.DbErrorCodes.TXERR_NO_DEBIT);
                resultP = dberr.getErrorDesc(connectionString);
            }
        }
        public void subtractBalance(string connectionString, Decimal changeAmount, Data.Dber dberr)
        {
            try
            {
                if (this.getDebitAllowed())
                {
                    this.newBal = this.actmP.ac_bal - changeAmount;
                    if (this.newBal < 0)
                    {
                        dberr.setError(Mnemonics.DbErrorCodes.TXERR_INSUFFICIENT_BALANCE);
                        resultP = dberr.getErrorDesc(connectionString);
                    }
                    else
                    {
                        this.actmP.ac_bal = this.newBal;
                        resultP = this.newBal.ToString();
                        // need to implement minimum balance check through new account type parameter table ACPRM

                        // Update newBal in Actm.
                        //Boolean dbCode = Data.ActmD.UpdateAccountBalance(connectionString, this.actmP.ac_no, this.actmP.ac_bal ,dberr);
                    }
                }
                else 
                {
                    dberr.setError(Mnemonics.DbErrorCodes.TXERR_NO_DEBIT);
                    resultP = dberr.getErrorDesc(connectionString);
                }
            }
            catch (Exception e)
            {
                //do something, or remove later
            }
        }
    }
}
