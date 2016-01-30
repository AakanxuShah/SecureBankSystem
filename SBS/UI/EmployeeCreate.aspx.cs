using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class EmployeeCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Access"] == null)
                Response.Redirect("UserLogin.aspx");
            if (Session["Access"].ToString() == "3" || Session["Access"].ToString() == "4")
                Response.Redirect("EmployeeHome.aspx");
            if (Session["Access"].ToString() == "1")
                Response.Redirect("Home.aspx");
            if (Session["Access"].ToString() == "2")
                Response.Redirect("MerchantHome.aspx");

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
            BranchTextBox.BorderColor = System.Drawing.Color.Black;
        }

        protected void CreateBtn_Click(object sender, EventArgs e)
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

                if (!(UI.Validate.isBranchValid(BranchTextBox.Text)))
                {
                    errorFound = true;
                    BranchTextBox.BorderColor = System.Drawing.Color.Red;
                }
                else BranchTextBox.BorderColor = System.Drawing.Color.Black;

                if (!UI.Validate.isPasswordValid(pwdTextBox.Text) ||
                    UI.Global.hashCode(pwdTextBox.Text) != UI.Global.hashCode(cpwdTextBox.Text))
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


                if (errorFound)
                {
                    Master.ErrorMessage = "Error: Invalid data entered!  Please correct and resubmit.";
                    return;
                }

                string[] arglist = new String[21];
                int argIndex = 0;
                arglist[argIndex++] = Mnemonics.TxnCodes.TX_CREATE_EMPLOYEE;
                arglist[argIndex++] = " ";
                arglist[argIndex++] = FirstNameTextBox.Text;
                arglist[argIndex++] = MiddleNameTextBox.Text;
                arglist[argIndex++] = LastNameTextBox.Text;
                arglist[argIndex++] = Addrs1TextBox.Text;
                arglist[argIndex++] = Addrs2TextBox.Text;
                arglist[argIndex++] = ZipTextBox.Text;
                arglist[argIndex++] = CityTextBox.Text;
                arglist[argIndex++] = StateTextBox.Text;
                arglist[argIndex++] = BranchTextBox.Text;
                arglist[argIndex++] = PhNumTextBox.Text;
                arglist[argIndex++] = EmailTextBox.Text;
                arglist[argIndex++] = EmpTypeDropList.SelectedValue.Equals("4") ? "Y" : "N";
                arglist[argIndex++] = EmpTypeDropList.SelectedValue;
                arglist[argIndex++] = Question1TextBox.Text;
                arglist[argIndex++] = Answer1TextBox.Text;
                arglist[argIndex++] = Question2TextBox.Text;
                arglist[argIndex++] = Answer2TextBox.Text;
                arglist[argIndex++] = " ";
                arglist[argIndex++] = UI.Global.hashCode(pwdTextBox.Text).ToString();

                var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(),
                    string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}", arglist));

                Master.ErrorMessage ="New employee created";
            }
            catch { }
            Response.Redirect("AdminHome.aspx");
        }
    }
}
