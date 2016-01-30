using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mnemonics;

namespace Business
{
    class Privilege
    {
        Int32 tx_pvga;
        Int32 tx_apprv;
        Int32 ac_pvga;
        Boolean pendingFlag;
        public Boolean isPending
        {
            get
            {
                return this.pendingFlag;
            }
            set
            {
                this.pendingFlag = value;
            }
        }
        
        //private Cp_Pendtxn pending;
        public Privilege(Int32 a, Int32 b, Int32 c)
        {
            this.tx_pvga = a;
            this.tx_apprv = b;
            this.ac_pvga = c;
            //pending = new Cp_Pendtxn();
        }
        public Boolean verifyInitPrivilege(Data.Dber dberr)
        {
            if(tx_pvga > ac_pvga)
            {
                dberr.setError(Mnemonics.DbErrorCodes.TXERR_INIT_PVG);
                return false;
            }
            
            //Entity.Pendtxn pending = new Entity.Pendtxn();
            //Data.PendtxnD.Create(connectionString, pending);
            return true; // remove later
        }
        public Boolean verifyApprovePrivilege()
        {
            if (this.ac_pvga < this.tx_apprv)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int writeToPendingTxns(String connectionString, String ac1, String ac2, String csNo, String pvgb,
            String tranDesc, String initEmpid, Decimal dr, Decimal cr, String tranid, String inData, Data.Dber dberr)
        {
            Cp_Pendtxn cpPend = new Cp_Pendtxn(connectionString, ac1, ac2, pvgb, csNo, initEmpid, dr, cr, tranDesc, tranid, inData, dberr);
            if(dberr.ifError())
            {
                return -1;
            }
            return 0;
        }
    }
}
