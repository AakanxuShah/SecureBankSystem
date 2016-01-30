using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Cp_Txnm
    {
        char[] delimiter = { '|' };
        //String SPROC = Mnemonics.SP_TXNM_ALL;
        String tran_desc;
        Int32 tran_pvga;
        Int32 tran_pvgb;
        String tran_fin_type;
        String[] txnmParts;
        private Entity.Txnm txnm;
        public Entity.Txnm txnmP 
        {
            get
            {
                return txnm;
            }
        }
        public Cp_Txnm(string connectionString, String tx_id, Data.Dber dberr)
        {
            // fetch data from Txnm tabke for tran_id = tx_id
            txnm = Data.TxnmD.Read(connectionString, tx_id, dberr);
        }
        public Int32 getInitPrivilegeLevel()
        {
            return this.tran_pvga;
        }
        public Int32 getApprovePrivilegeLevel()
        {
            return this.tran_pvgb;
        }
        public Boolean getTranFinType()
        {
            if (this.tran_fin_type.Equals('Y'))
            {
                return true;
            }
            else return false;
        }
    }
}
