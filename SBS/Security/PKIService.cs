using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Security
{
    public class PKIService
    {
        private const int KEY_SIZE = 1024;

        public string PrivateKey { get; set; } 
        public string PublicKey { get; set; } 

        public PKIService()
        {
            GeneratePublicAndPrivateKey();
        }

        private string GeneratePublicAndPrivateKey()
        {
            var provider = new RSACryptoServiceProvider(KEY_SIZE);
            var keyXml = provider.ToXmlString(true);
            PrivateKey = provider.ToXmlString(true);
            PublicKey = provider.ToXmlString(false);

            /*Example of keyXml  var keyXml = new XDocument(provider.ToXmlString(true));
             <RSAKeyValue>
	            <Modulus>j0LR700piG/Ln4qAj1SjGNa+5KSsYPVtEORhEEV/YfyzR0gN8Gcj87jSxm7GW3Q86xSLkwlAQGqKFnFa3npEsq65wOuybuyXhL+7lsPsSsYseYpYzZPi2YFPuKmCRddDf5vJpHUUaG16Ph/jXjPEJu0wc1fbVAwwqfUF6wb4Eqc=</Modulus>
	            <Exponent>AQAB</Exponent>
	            <P>x6/NbOJqCy+u9Q8qTZCouCNcyqC94M/liPJEajTikrYE7ubbZS9mGeK+HmExGw7QsIsBVd9Ale9CZzoP9kFW8w==</P>
	            <Q>t6lqciz6m2PE7j6Tlc63lmj9yxp6egilZS5/yDy+y+5CQcO9yUtwX/5C74bK3EyKeUVwTJpWj5KtjXC0PLBqfQ==</Q>
	            <DP>IrB2tliq5WCWOzo0Nh9QQBTclNLRyZE0JdM4cV7YkXYPa1Utfel7CjoqnupxdmrfdBvh0oIjHSjgV0Bt73CwYw==</DP>
	            <DQ>DzkDkaMYwnhqgjS9ltUjclwRbRwsuqCs1M4d2ULvrYd6Bmlq+Zw/HDW+5ouNlOTjNVoEDNVeB1ho+ig1SDJ3IQ==</DQ>
	            <InverseQ>aqU5iieeb8cWSOlKiOvTQAiRJjDQxVehb8n/Gs9lTTasBi5jDiqdhzcR9k2MkV9zeVfn31atx/wkRGMf9MCqyQ==</InverseQ>
	            <D>M5smdMWfCH79IuOJnBgpCHGTIloPnn3KZCNgs7PVRz74dd0G6Gq/ELSreL++xIMCzsv/21+hvZKjW6JJ0YrJ4+nlJHlg4fqGzGwbRdzd5jhhfcUwXujFRbjPWVDqtdSdxn0QGce82k6eDNnFbIXGWmBu3S6xnpKarnYiX8JQ5EE=</D>
             </RSAKeyValue>
             */

            /*  var keyXml = new XDocument(provider.ToXmlString(false));
             <BitStrength>1024</BitStrength>
             <RSAKeyValue>
	            <Modulus>j0LR700piG/Ln4qAj1SjGNa+5KSsYPVtEORhEEV/YfyzR0gN8Gcj87jSxm7GW3Q86xSLkwlAQGqKFnFa3npEsq65wOuybuyXhL+7lsPsSsYseYpYzZPi2YFPuKmCRddDf5vJpHUUaG16Ph/jXjPEJu0wc1fbVAwwqfUF6wb4Eqc=</Modulus>
	            <Exponent>AQAB</Exponent>
             </RSAKeyValue>
             */

            return keyXml;
        }

        private static byte[] ObjectToByteArray(Object obj)
        {
            var formatter = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private static Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }

        public static string EncryptData(Object dataObject, string keyXml)
        {
            try
            {
                var provider = new RSACryptoServiceProvider(KEY_SIZE);
                provider.FromXmlString(keyXml.ToString());

                int newKeySize = KEY_SIZE / 8;
                var bytes = ObjectToByteArray(dataObject);
                var maxLength = newKeySize - 42;
                var dataLength = bytes.Length;
                int iterations = dataLength / maxLength;
                var stringBuilder = new StringBuilder();
                for (int i = 0; i <= iterations; i++)
                {
                    var tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
                    Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length);
                    var encryptedBytes = provider.Encrypt(tempBytes, true);
                    stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
                }
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Object DecryptData(string encryptedData, string keyXml)
        {
            try
            {
                var provider = new RSACryptoServiceProvider(KEY_SIZE);
                provider.FromXmlString(keyXml.ToString());

                var base64BlockSize = ((KEY_SIZE / 8) % 3 != 0) ? (((KEY_SIZE / 8) / 3) * 4) + 4 : ((KEY_SIZE / 8) / 3) * 4;
                int iterations = encryptedData.Length / base64BlockSize;
                var arrayList = new ArrayList();
                for (var i = 0; i < iterations; i++)
                {
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedData.Substring(base64BlockSize * i, base64BlockSize));
                    arrayList.AddRange(provider.Decrypt(encryptedBytes, true));
                }
                return ByteArrayToObject(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static string EncryptData(string data, string keyXml)
        //{
        //    try
        //    {
        //        var provider = new RSACryptoServiceProvider(KEY_SIZE);
        //        provider.FromXmlString(keyXml.ToString());

        //        int newKeySize = KEY_SIZE / 8;
        //        var bytes = Encoding.UTF32.GetBytes(data);
        //        var maxLength = newKeySize - 42;
        //        var dataLength = bytes.Length;
        //        int iterations = dataLength / maxLength;
        //        var stringBuilder = new StringBuilder();
        //        for (int i = 0; i <= iterations; i++)
        //        {
        //            var tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
        //            Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length);
        //            var encryptedBytes = provider.Encrypt(tempBytes, true);
        //            stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
        //        }
        //        return stringBuilder.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static string DecryptData(string encryptedData, string keyXml)
        //{
        //    try
        //    {
        //        var provider = new RSACryptoServiceProvider(KEY_SIZE);
        //        provider.FromXmlString(keyXml.ToString());

        //        var base64BlockSize = ((KEY_SIZE / 8) % 3 != 0) ? (((KEY_SIZE / 8) / 3) * 4) + 4 : ((KEY_SIZE / 8) / 3) * 4;
        //        int iterations = encryptedData.Length / base64BlockSize;
        //        var arrayList = new ArrayList();
        //        for (var i = 0; i < iterations; i++)
        //        {
        //            byte[] encryptedBytes = Convert.FromBase64String(encryptedData.Substring(base64BlockSize * i, base64BlockSize));
        //            arrayList.AddRange(provider.Decrypt(encryptedBytes, true));
        //        }
        //        return Encoding.UTF32.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
