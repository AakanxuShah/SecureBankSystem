using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class OTPService
    {
        private const int NB_OTP = 1;
        private const int SECRET_LENGTH = 20;
        private OTP _otp;


        public OTPService(string secret)
        {
            var unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            _otp = new OTP(secretKey: OTP.ToByteArray(TruncateLongString(unixTimestamp.ToString() + secret, 20)));
        }

        private string TruncateLongString(string str, int maxLength)
        {
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }

        public bool VerifyOTP(string userOtp)
        {
            var current = _otp.GetCurrentOTP();
            return _otp.GetCurrentOTP() == userOtp;
        }

        public string GenerateOTP(string customerFullName, string email ="", string cellPhone="", bool notifyByEmail = true, bool notifyByPhone = false)
        {
            var otpSecret =  _otp.GetNextOTP();
            if (notifyByEmail)
                OTPUtility.SendMail(customerFullName, email, otpSecret);
            if(notifyByPhone)
                OTPUtility.SendMessage(cellPhone, otpSecret);
            return otpSecret;
        }
    }
}
