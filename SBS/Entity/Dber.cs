using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Dber
    {
        //static const String sproc_code = "PS_000";
        Char errFlag;
        String errCode;
        String errDesc;
        public Dber()
        {
            errFlag = ' ';
        }
        /*public void setError(String errCode)
        {
            errFlag = 'Y';
            this.errCode = errCode;
            Errm err = new Errm(errCode);
            errDesc = err.getData();
        }*/
        public Boolean ifError()
        {
            if(errFlag.Equals('Y'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public String getErrorDesc()
        {
            return this.errDesc;
        }
    }
}
