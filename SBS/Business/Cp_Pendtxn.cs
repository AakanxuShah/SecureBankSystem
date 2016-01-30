using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Business
{
    class Cp_Pendtxn
    {
        DataSet pending;
        Entity.Pendtxn pn;
        public DataSet pendingP
        {
            get
            {
                return this.pending;
            }
            set
            {
                this.pending = value;
            }
        }
        public Cp_Pendtxn(String connectionString, String pvg, Boolean isAdmin, Data.Dber dberr)
        {
            pendingP = Data.PendtxnD.GetAccessiblePendingTransactions(connectionString, pvg, dberr, isAdmin);
        }
        public Cp_Pendtxn(String connectionString, String ac1, String ac2, String pvgb, String csNo, 
            String initEmpid, Decimal dr, Decimal cr, String tranDesc, String txid, String inData, Data.Dber dberr)
        {
            Entity.Pendtxn pending = new Entity.Pendtxn("0", ac1, ac2, pvgb, csNo, initEmpid, dr, cr, tranDesc, txid, inData);
            Data.PendtxnD.Create(connectionString, pending, dberr);
        }
    }
}
