using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    static class Validation
    {
        
        public static int validateCustomerSelfAccount(String connectionString, String loginAc, String ac)
        {
            Data.Dber dberr = new Data.Dber();
            Cp_Cstm cpCstm = new Cp_Cstm(connectionString, loginAc, dberr);
            if(dberr.ifError())
            {
                return -1;
            }
            Cp_Actm cpActm = new Cp_Actm(connectionString, ac, dberr);
            if(!cpCstm.cstmP.cs_no.Equals(cpActm.actmP.cs_no1))
            {
                return -1;
            }
            return 0;
        }
        public static int validateFromToAccSame(String ac1, String ac2)
        {
            //Returns 0 if From account and To account are the same (as in transfer transactions)
            if(ac1.Equals(ac2))
            {
                return -1;
            }
            return 0;
        }
        public static int employeeInitiatedTxn(String connectionString, String empno)
        {
            Data.Dber dberr = new Data.Dber();
            Cp_Empm cpEmpm = new Cp_Empm(connectionString, empno, dberr);
            if(dberr.ifError())
            {
                return -1;
            }
            return 0;
        }
        public static int accountsBelongToSameCus(String connectionString, String ac1, String ac2)
        {
            Data.Dber dberr = new Data.Dber();
            Cp_Actm cpActm1 = new Cp_Actm(connectionString, ac1, dberr);
            if (dberr.ifError())
            {
                return -1;
            }
            Cp_Actm cpActm2 = new Cp_Actm(connectionString, ac2, dberr);
            if (dberr.ifError())
            {
                return -1;
            }
            if (!cpActm1.actmP.cs_no1.Equals(cpActm2.actmP.cs_no1))
            {
                return -1;
            }
            return 0;
        }
        public static Boolean isActiveCustomer(String connectinString, String cusno)
        {
            Data.Dber dberr = new Data.Dber();
            Cp_Cstm cpCstm = new Cp_Cstm(connectinString, cusno, dberr);
            if(dberr.ifError())
            {
                return false;
            }
            if(cpCstm.cstmP.cs_type.Equals("0"))
            {
                dberr.setError(Mnemonics.DbErrorCodes.TXERR_INACTIVE_CUSTOMER);
                return false;
            }
            return true;
        }
        public static Boolean isActiveCustomerUsingAcc(String connectionString, String ac)
        {
            Data.Dber dberr = new Data.Dber();
            Cp_Actm cpActm = new Cp_Actm(connectionString, ac, dberr);
            if (dberr.ifError())
            {
                return false;
            }
            Cp_Cstm cpCstm = new Cp_Cstm(connectionString, cpActm.actmP.cs_no1, dberr);
            if (dberr.ifError())
            {
                return false;
            }
            if (cpCstm.cstmP.cs_type.Equals("0"))
            {
                dberr.setError(Mnemonics.DbErrorCodes.TXERR_INACTIVE_CUSTOMER);
                return false;
            }
            return true;
        }
        public static int validateCustomerNotSelfAccount(String connectionString, String loginAc, String ac)
        {
            Data.Dber dberr = new Data.Dber();
            Cp_Cstm cpCstm = new Cp_Cstm(connectionString, loginAc, dberr);
            if (dberr.ifError())
            {
                return -1;
            }
            Cp_Actm cpActm = new Cp_Actm(connectionString, ac, dberr);
            if (!cpCstm.cstmP.cs_no.Equals(cpActm.actmP.cs_no1))
            {
                return -1;
            }
            return 0;
        }
        public static Boolean isMerchant(String connectionString, String loginAc)
        {
            Data.Dber dberr = new Data.Dber();
            Cp_Cstm cpCstm = new Cp_Cstm(connectionString, loginAc, dberr);
            if (dberr.ifError())
            {
                return false;
            }
            if(cpCstm.cstmP.cs_type.Equals("2"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
