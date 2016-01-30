using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTester
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=(local);Initial Catalog=SBS;Integrated Security=True";
        static void Main(string[] args)
        {
            var error = new Data.Dber();
            var s = CstmD.Read(CONNECTION_STRING,"10001", error);

            var c = CstmD.Create(CONNECTION_STRING,s,error);

            var d = CstmD.Delete(CONNECTION_STRING, c.ToString(),null);
            // TestSecurity();

            Console.ReadLine();
        }

        private static void TestSecurity()
        {
            //Console.WriteLine("--------------- Generated Keys ---------------");
            //var keyXml = Security.PKIService.GeneratePublicAndPrivateKey().ToString();
            //Console.WriteLine(keyXml);

            //Console.WriteLine("--------------- Data ---------------");
            //var data = "testing encryption";
            //Console.WriteLine("Data: {0}", data);

            //Console.WriteLine("--------------- Encrypted Data ---------------");
            //var encryptedData = Security.PKIService.EncryptData("testing encryption", keyXml).ToString();
            //Console.WriteLine(encryptedData);


            //Console.WriteLine("--------------- Decrypted Data ---------------");
            //Console.WriteLine(Security.PKIService.DecryptData(encryptedData, keyXml).ToString());
            
            //// Jon was here.
            //Console.ReadLine();
        }
    }
}
