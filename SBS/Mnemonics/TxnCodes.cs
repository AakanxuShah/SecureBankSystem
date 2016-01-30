using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mnemonics
{
    public static class TxnCodes
    {
        public const String TX_LOGIN = "001";
        public const String TX_EMP_PENDING = "008";
        public const String TX_BALINQ_BULK = "009";
        public const String TX_BALINQ = "010";
        public const String TX_DEBIT = "011";
        public const String TX_CREDIT = "012";
        public const String TX_HIGHVAL_CREDIT = "013";
        public const String TX_INT_TRANSFER = "014";
        public const String TX_TRANSFER_DEBIT = "015";
        public const String TX_TRANSFER_CREDIT = "016";
        public const String TX_UPDATE_PROFILE = "017";
        public const String TX_REGISTER_CUSTOMER = "018";
        public const String TX_FETCH_CUSTOMER = "019";
        public const String TX_TRANSFER = "020";
        public const String TX_EXT_TRANSFER = "021";
        public const String TX_REGISTER_USER = "022";
        public const String TX_SENT_TO_APPROVER = "023";
        public const String TX_FORGET_PASSWORD = "024";
        public const String TX_CREATE_ACCOUNT = "025";
        public const String TX_CREATE_EMPLOYEE = "026";
        public const String TX_DELETE_USER_EMPLOYEE = "027";
        public const String TX_DEBIT_AUTH = "028";
        public const String TX_EXT_HIVAL_TRANSFER = "029";
        public const String TX_EXT_TFR_MERCHANT = "030";
    }
}
