using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class DebitForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserId"] == null || Session["Access"] == null)
                    Response.Redirect("UserLogin.aspx");
                if (Session["Access"].ToString() == "5")
                    Response.Redirect("AdminHome.aspx");

                if (!IsPostBack)
                {
                    if (Global.IsPageAccessible(Page.Title))
                    {
                        if (Session["Access"].ToString() == "1" || Session["Access"].ToString() == "2")
                        {
                            FromCustomerDiv.Visible = false;
                            LoadAccounts(Session["UserId"].ToString());
                        }
                        else
                        {
                            FromCustomerDiv.Visible = true;
                            LoadCustomers(Session["UserId"].ToString());
                        }
                    }
                    else
                    {
                        Response.Redirect("Error.aspx?error=NoAccess");
                    }

                }
            }
            catch { }
        }

        private void LoadCustomers(string internalUserId)
        {
            var xSwitchObject = new Business.XSwitch();

            try
            {
                var output = xSwitchObject.getEmployeeAccessibleCustomerData(Global.ConnectionString, Session["UserId"].ToString());
                if ((output == null) || (output.Tables[0].Rows.Count != 0))
                {
                    CustomerDropDown.DataSource = output.Tables[0];
                    CustomerDropDown.DataTextField = "cs_uname";
                    CustomerDropDown.DataValueField = "cs_no";
                    CustomerDropDown.DataBind();
                    //AccountList.InnerHtml = GetAccountListHtml(output.resultSet);
                    LoadAccounts(CustomerDropDown.SelectedValue, byPass: true);
                }
                else
                {
                    CustomerDropDown.Items.Add(new ListItem { Text = "You have access to no customers", Value = "0" });
                }
            }
            catch { }
        }

        private void LoadAccounts(string externalUserId, bool byPass = false)
        {
            try
            {
                if (Session["Access"].ToString() == "1" || Session["Access"].ToString() == "2" || byPass)
                {
                    var output = new Business.XSwitch(Global.ConnectionString, Session["Username"].ToString(), string.Format("009|{0}", externalUserId));
                    if (output == null)
                        Response.Redirect("Error.aspx");

                    if (output != null && output.resultSet != null && output.resultSet.Tables.Count > 0 && output.resultSet.Tables.Count > 0)
                    {
                        if (output.resultSet.Tables[0].Rows.Count != 0)
                        {
                            FromDropdown.DataSource = output.resultSet.Tables[0];
                            FromDropdown.DataTextField = "ac_no";
                            FromDropdown.DataValueField = "ac_no";
                            FromDropdown.DataBind();
                            //AccountList.InnerHtml = GetAccountListHtml(output.resultSet);
                        }
                        else
                        {
                            FromDropdown.Items.Add(new ListItem { Text = "No Accounts Found", Value = "0" });
                        }
                    }
                    else
                    {
                        FromDropdown.Items.Clear();
                        FromDropdown.Items.Add(new ListItem { Text = "No Accounts Found", Value = "0" });
                    }

                }
            }
            catch { }
        }

        protected void DebitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Access"].ToString() == "1" || Session["Access"].ToString() == "2")
                {
                    if (FromDropdown.SelectedValue == "0")
                    {
                        Master.ErrorMessage = "Error: Select the Account from which an amount has to be Debited";

                    }
                    else if (Amount.Text == "" || !UI.Validate.isAmountValid(Amount.Text))
                    {
                        Master.ErrorMessage = "Error: Amount cannot be empty, and amount accepts only decimal values.";
                    }
                    else
                    {
                        var amount = Convert.ToDecimal(Amount.Text);

                        if (amount > 1000)
                        {
                            _otpService = new OTPService(Session["UserId"].ToString() + Session["UserName"].ToString());
                            _otpService.GenerateOTP(Session["UserName"].ToString(), email: Session["UserEmail"].ToString());
                            //show otp 
                            DebitButton.Visible = false;
                            OTPDiv.Visible = true;
                            VirtualCheckBoxArea.Style.Remove("display");
                            VirtualCheckBoxArea.Style.Add("display", "block");
                        }
                        else
                        {
                            ProcessTransaction(amount);
                        }
                    }
                }

                else
                {
                    var amount = Convert.ToDecimal(Amount.Text);
                    ProcessTransaction(amount);
                }
            }
            catch { }

        }

        private static OTPService _otpService;
        protected void ResendOTPLink_Click(object sender, EventArgs e)
        {
            try
            {
                _otpService.GenerateOTP(Session["UserName"].ToString(), email: Session["UserEmail"].ToString());
            }
            catch { }
        }

        protected void VerifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_otpService.VerifyOTP(OTPTextBox.Text.Trim()))
                {
                    ProcessTransaction(Convert.ToDecimal(Amount.Text));
                    ResetPage();
                }

                else
                {
                    Master.ErrorMessage = "Error: Could not verify the OTP that you entered.";
                }
            }
            catch {
                Master.ErrorMessage = "Error: Could not verify the OTP that you entered.";
            }
        }

        private void ProcessTransaction(decimal amount)
        {
            try
            {
                var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(), string.Format("011|{0}| |{1}|{2}| ", FromDropdown.SelectedValue, amount, Session["Access"]));
                Master.ErrorMessage = string.Format(output.resultP);
                ResetPage();
            }
            catch
            {
                Master.ErrorMessage = "Error: transaction failed.";
            }
        }

        private void ResetPage()
        {
            Amount.Text = string.Empty;
            FromDropdown.SelectedIndex = 0;
            OTPDiv.Visible = false;
            VirtualCheckBoxArea.Style.Remove("display");
            VirtualCheckBoxArea.Style.Add("display", "none");
            DebitButton.Visible = true;
            OTPTextBox.Text = string.Empty;
        }

        protected void CustomerDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccounts(CustomerDropDown.SelectedValue, byPass: true);
        }
    }
}