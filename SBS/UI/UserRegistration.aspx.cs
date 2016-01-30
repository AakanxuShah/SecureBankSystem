using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            FirstNameTextBox.BorderColor = System.Drawing.Color.Black;
            MiddleNameTextBox.BorderColor = System.Drawing.Color.Black;
            LastNameTextBox.BorderColor = System.Drawing.Color.Black;
            Addrs1TextBox.BorderColor = System.Drawing.Color.Black;
            Addrs2TextBox.BorderColor = System.Drawing.Color.Black;
            CityTextBox.BorderColor = System.Drawing.Color.Black;
            StateTextBox.BorderColor = System.Drawing.Color.Black;
            ZipTextBox.BorderColor = System.Drawing.Color.Black;
            PhNumTextBox.BorderColor = System.Drawing.Color.Black;
            EmailTextBox.BorderColor = System.Drawing.Color.Black;
            pwdTextBox.BorderColor = System.Drawing.Color.Black;
            cpwdTextBox.BorderColor = System.Drawing.Color.Black;
        }

        protected void CustCreate_Click(object sender, EventArgs e)
        {
            try
            {
                bool errorFound = false;

                if (!(UI.Validate.isUserNameValid(FirstNameTextBox.Text)))
                {
                    errorFound = true;
                    FirstNameTextBox.BorderColor = System.Drawing.Color.Red;
                }
                else FirstNameTextBox.BorderColor = System.Drawing.Color.Black;
                if (!(UI.Validate.isUserNameValid(MiddleNameTextBox.Text)))
                {
                    errorFound = true;
                    MiddleNameTextBox.BorderColor = System.Drawing.Color.Red;
                }
                else MiddleNameTextBox.BorderColor = System.Drawing.Color.Black;
                if (!(UI.Validate.isUserNameValid(LastNameTextBox.Text)))
                {
                    errorFound = true;
                    LastNameTextBox.BorderColor = System.Drawing.Color.Red;
                }
                else LastNameTextBox.BorderColor = System.Drawing.Color.Black;
                if (!(UI.Validate.isAddressValid(Addrs1TextBox.Text)))
                {
                    errorFound = true;
                    Addrs1TextBox.BorderColor = System.Drawing.Color.Red;
                }
                else Addrs1TextBox.BorderColor = System.Drawing.Color.Black;
                if (!(UI.Validate.isAddressValid(Addrs2TextBox.Text)))
                {
                    errorFound = true;
                    Addrs2TextBox.BorderColor = System.Drawing.Color.Red;
                }
                else Addrs2TextBox.BorderColor = System.Drawing.Color.Black;
                if (!(UI.Validate.isCityValid(CityTextBox.Text)))
                {
                    errorFound = true;
                    CityTextBox.BorderColor = System.Drawing.Color.Red;
                }
                else CityTextBox.BorderColor = System.Drawing.Color.Black;
                if (!(UI.Validate.isStateValid(StateTextBox.Text)))
                {
                    errorFound = true;
                    StateTextBox.BorderColor = System.Drawing.Color.Red;
                }
                else StateTextBox.BorderColor = System.Drawing.Color.Black;
                if (!(UI.Validate.isZipCodeValid(ZipTextBox.Text)))
                {
                    errorFound = true;
                    ZipTextBox.BorderColor = System.Drawing.Color.Red;
                }
                else ZipTextBox.BorderColor = System.Drawing.Color.Black;
                if (!(UI.Validate.isPhoneNumberValid(PhNumTextBox.Text)))
                {
                    errorFound = true;
                    PhNumTextBox.BorderColor = System.Drawing.Color.Red;
                }
                else PhNumTextBox.BorderColor = System.Drawing.Color.Black;
                if (!(UI.Validate.isEmailAddressValid(EmailTextBox.Text)))
                {
                    errorFound = true;
                    EmailTextBox.BorderColor = System.Drawing.Color.Red;
                }
                else EmailTextBox.BorderColor = System.Drawing.Color.Black;

                if (!UI.Validate.isPasswordValid(pwdTextBox.Text) ||
                    hashPwdHiddenField.Value.Equals("0") ||
                    !hashPwdHiddenField.Value.Equals(hashCpwdHiddenField.Value))
                {
                    errorFound = true;
                    pwdTextBox.BorderColor = System.Drawing.Color.Red;
                    cpwdTextBox.BorderColor = System.Drawing.Color.Red;
                }
                else
                {
                    pwdTextBox.BorderColor = System.Drawing.Color.Black;
                    cpwdTextBox.BorderColor = System.Drawing.Color.Black;
                }

                if (!UI.Validate.isSecurityQuestionValid(Question1TextBox.Text))
                {
                    errorFound = true;
                    Question1TextBox.BorderColor = System.Drawing.Color.Red;
                }
                else Question1TextBox.BorderColor = System.Drawing.Color.Black;
                if (!UI.Validate.isSecurityAnswerValid(Answer1TextBox.Text))
                {
                    errorFound = true;
                    Answer1TextBox.BorderColor = System.Drawing.Color.Red;
                }
                else Answer1TextBox.BorderColor = System.Drawing.Color.Black;

                if (!UI.Validate.isSecurityQuestionValid(Question2TextBox.Text))
                {
                    errorFound = true;
                    Question2TextBox.BorderColor = System.Drawing.Color.Red;
                }
                else Question2TextBox.BorderColor = System.Drawing.Color.Black;
                if (!UI.Validate.isSecurityAnswerValid(Answer2TextBox.Text))
                {
                    errorFound = true;
                    Answer2TextBox.BorderColor = System.Drawing.Color.Red;
                }
                else Answer2TextBox.BorderColor = System.Drawing.Color.Black;

                if (!UI.Validate.isSecurityQuestionValid(Question3TextBox.Text))
                {
                    errorFound = true;
                    Question3TextBox.BorderColor = System.Drawing.Color.Red;
                }
                else Question3TextBox.BorderColor = System.Drawing.Color.Black;
                if (!UI.Validate.isSecurityAnswerValid(Answer3TextBox.Text))
                {
                    errorFound = true;
                    Answer3TextBox.BorderColor = System.Drawing.Color.Red;
                }
                else Answer3TextBox.BorderColor = System.Drawing.Color.Black;

                if (errorFound)
                {
                    MessageLabel.Text = "Invalid data entered!  Please correct and resubmit.";
                    return;
                }

                string[] arglist = new String[26];
                int argIndex = 0;

                arglist[argIndex++] = Mnemonics.TxnCodes.TX_REGISTER_CUSTOMER;
                arglist[argIndex++] = " ";
                arglist[argIndex++] = MerchantCheckBox.Checked ? "2" : "1";
                arglist[argIndex++] = FirstNameTextBox.Text;
                arglist[argIndex++] = MiddleNameTextBox.Text;
                arglist[argIndex++] = LastNameTextBox.Text;
                arglist[argIndex++] = Addrs1TextBox.Text;
                arglist[argIndex++] = Addrs2TextBox.Text;
                arglist[argIndex++] = ZipTextBox.Text;
                arglist[argIndex++] = CityTextBox.Text;
                arglist[argIndex++] = StateTextBox.Text;
                arglist[argIndex++] = PhNumTextBox.Text;
                arglist[argIndex++] = EmailTextBox.Text;
                arglist[argIndex++] = " ";
                arglist[argIndex++] = " ";
                arglist[argIndex++] = Question1TextBox.Text;
                arglist[argIndex++] = Answer1TextBox.Text;
                arglist[argIndex++] = Question2TextBox.Text;
                arglist[argIndex++] = Answer2TextBox.Text;
                arglist[argIndex++] = Question3TextBox.Text;
                arglist[argIndex++] = Answer3TextBox.Text;
                arglist[argIndex++] = " ";
                arglist[argIndex++] = " ";
                arglist[argIndex++] = UI.Global.hashCode(pwdTextBox.Text).ToString();
                arglist[argIndex++] = " ";
                arglist[argIndex++] = " ";

                var output = new Business.XSwitch(Global.ConnectionString, "0", string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}", arglist));
                if (output.resultP.ToLower().Contains("invalid data !"))
                {
                    MessageLabel.Text = output.resultP;
                }
                else
                {
                    MessageLabel.Text = "Request for new user login created.  Email will be sent when administrator reviews.";
                    System.Threading.Thread.Sleep(6000);
                    Response.Redirect("Home.aspx");
                    MessageLabel.Text = "";
                }
            }
            catch { }
            //MessageLabel.Text = "";
            //Response.Redirect("Home.aspx");
        }
    }
}