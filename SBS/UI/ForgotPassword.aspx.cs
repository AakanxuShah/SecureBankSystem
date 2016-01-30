using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Security;

namespace UI
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        private static OTPService _otpService;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //private static String userId = "1234";

        protected void SendOTPBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] arglist = new String[2];

                Business.XSwitch xsw = new Business.XSwitch();
                if (!UI.Validate.isUserNameValid(UserNameTextBox.Text))
                {
                    MessageLabel.Text = "Error: The User Name that was entered was not found.";
                    return;
                }
                var employeeOutput = new Entity.Empm();
                var output = xsw.getExternalUserDataFromUserName(Global.ConnectionString, UserNameTextBox.Text);
                if (output == null)
                {
                    employeeOutput = xsw.getInternalUserDataFromUserName(Global.ConnectionString, UserNameTextBox.Text);

                    if (employeeOutput == null)
                    {
                        MessageLabel.Text = "Error: The User Name that was entered was not found.";
                        return;
                    }
                    
                }

                if (output != null)
                {
                    Session["TempUserId"] = output.cs_no;
                    String userName = output.cs_fname + " " + output.cs_lname;

                    _otpService = new OTPService(output.cs_uid + userName);
                    _otpService.GenerateOTP(userName, email: output.cs_email);
                }
                else if (employeeOutput != null)
                {
                    Session["TempUserId"] =  employeeOutput.emp_no;
                    String userName = employeeOutput.emp_fname + " " + employeeOutput.emp_lname;

                    _otpService = new OTPService(employeeOutput.emp_no + userName);
                    _otpService.GenerateOTP(userName, email: employeeOutput.emp_email);
                }
            }
            catch { }
        }

        protected void ChangePwdBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_otpService.VerifyOTP(OTPTextBox.Text.Trim()))
                {
                    MessageLabel.Text = "Error: Could not verify the OTP that you entered.";
                    return;
                }

                if (!UI.Validate.isPasswordValid(pwdTextBox.Text) ||
                    hashPwdHiddenField.Value.Equals("0") ||
                    !hashPwdHiddenField.Value.Equals(hashCpwdHiddenField.Value))
                {
                    MessageLabel.Text = "Error: Invalid Password Entered, or passwords do not match.";
                    return;
                }

                string[] arglist = new String[3];
                int argIndex = 0;

                arglist[argIndex++] = Mnemonics.TxnCodes.TX_FORGET_PASSWORD;
                arglist[argIndex++] = Session["TempUserId"].ToString();
                arglist[argIndex++] = hashPwdHiddenField.Value;

                var output = new Business.XSwitch(Global.ConnectionString, Session["TempUserId"].ToString(), string.Format("{0}|{1}|{2}", arglist));

                MessageLabel.Text = "Password changed successfully.";
                _otpService = null;
                System.Threading.Thread.Sleep(2000);
            }
            catch { }
            MessageLabel.Text = "";
            Response.Redirect("UserLogin.aspx");
        }
    }
}