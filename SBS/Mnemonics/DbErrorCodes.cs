using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mnemonics
{
    public static class DbErrorCodes
    {
        public static String DBERR_TXNM_NOFIND = "999";
        public static String DBERR_ERRM_NOFIND = "998";
        public static String DBERR_ACTM_NOFIND = "997";
        public static String DBERR_EMPM_NOFIND = "995";
        public static String DBERR_ACTM_CUSNO_FETCH = "996";
        public static String DBERR_PENDTXN_NOWRITE = "995";
        public static String DBERR_PENDTXN_NOFETCH = "994";
        public static String DBERR_FAIL_UPDATE_PWD = "993";
        public static String DBERR_TXNM_READALL = "992";
        public static String DBERR_TXNM_CREATE = "991";
        public static String DBERR_TXNM_DELETE = "990";
        public static String DBERR_PENDTXN_DELETE = "989";
        public static String DBERR_PENDTXN_READ = "988";
        public static String DBERR_ACTM_CREATE = "987";
        public static String DBERR_CSTM_NOFIND = "986";
        public static String DBERR_CSTM_CREATE = "985";
        public static String DBERR_ACTM_DELETE = "984";
        public static String DBERR_EMPM_UPDATE = "983";
        public static String DBERR_FINHIST_READ = "982";
        public static String DBERR_FINHIST_CREATE = "981";
        public static String DBERR_FINHIST_DELETE = "980";
        public static String DBERR_NFINHIST_READ = "979";
        public static String DBERR_NFINHIST_CREATE = "978";
        public static String DBERR_NFINHIST_DELETE = "977";
        public static String DBERR_PKIT_ERROR = "976";
        public static String DBERR_EMP_CUS_DELETE = "975";
        public static String DBERR_INVALID_INPUT_STRING = "974";

        public static String TXERR_INIT_PVG = "500";
        public static String TXERR_NO_DEBIT = "499";
        public static String TXERR_NO_CREDIT = "498";
        public static String TXERR_NEGATIVE_TRANSFER = "497";
        public static String TXERR_FMT_CUSFNAME = "496";
        public static String TXERR_FMT_CUSMNAME = "495";
        public static String TXERR_FMT_CUSLNAME = "494";
        public static String TXERR_FMT_CUSADDR1 = "493";
        public static String TXERR_FMT_CUSADDR2 = "492";
        public static String TXERR_FMT_CUSCITY = "491";
        public static String TXERR_FMT_CUSSTATE = "490";
        public static String TXERR_FMT_CUSZIP = "489";
        public static String TXERR_FMT_CUSBRNCH = "488";
        public static String TXERR_FMT_CUSPHN = "487";
        public static String TXERR_FMT_CUSEMAIL = "486";
        public static String TXERR_FMT_CUSUID = "485";
        public static String TXERR_FMT_CUSSECQ1 = "484";
        public static String TXERR_FMT_CUSANS1 = "483";
        public static String TXERR_FMT_CUSSECQ2 = "482";
        public static String TXERR_FMT_CUSANS2 = "481";
        public static String TXERR_FMT_CUSSECQ3 = "480";
        public static String TXERR_FMT_CUSANS3 = "479";
        public static String TXERR_FMT_CUSNO = "478";
        public static String TXERR_FMT_CUSTYPE = "477";
        public static String TXERR_EXISTING_USER = "476";
        public static String TXERR_INSUFFICIENT_BALANCE = "475";
        public static String TXERR_MISMATCH_CUSTOMER = "474";
        public static String TXERR_MAIL_NOSEND = "473";
        public static String TXERR_PWD_NOUPDATE = "472";
        public static String TXERR_INACTIVE_CUSTOMER = "471";
        public static String TXERR_NO_USER = "000";
        //----
        public static String TXERR_FROM_TO_AC_SAME = "470"; // Both From and To accounts in a Transfer cannot be the same
        public static String TXERR_INTERNAL_TFR_TO_DIFF_CUS = "469"; // To Account belongs to a different user
        public static String TXERR_INTERNAL_TFR_FROM_DIFF_CUS = "468"; // From Account belongs to a different user
        public static String TXERR_INTERNAL_TFR_EMP_FROM_TO_ACC_DIFF_CUS = "467"; // From and To accounts do not belong to the same customer
        public static String TXERR_EXTERNAL_TFR_EMP_TO_ACC_SAME_CUS = "466"; // To account cannot belong to the same customer
        public static String TXERR_ADMIN_PWD_NOCHANGE = "465"; // Admin password cannot be changed online

        public static String MSG_SENT_FOR_AUTH = "The Transaction is pending Authorization!";
    }
}
