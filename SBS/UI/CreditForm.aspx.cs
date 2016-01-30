using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class CreditForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
        
        private void LoadCustomers(string internalUserId)
        {
            var xSwitchObject = new Business.XSwitch();

            var output = xSwitchObject.getEmployeeAccessibleCustomerData(Global.ConnectionString, Session["UserId"].ToString());
            if (output.Tables[0].Rows.Count != 0)
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
                CustomerDropDown.Items.Add(new ListItem { Text= "You have access to no customers", Value="0"});
            }
        }

        private void LoadAccounts(string externalUserId, bool byPass = false)
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
                        ToDropdown.DataSource = output.resultSet.Tables[0];
                        ToDropdown.DataTextField = "ac_no";
                        ToDropdown.DataValueField = "ac_no";
                        ToDropdown.DataBind();
                        //AccountList.InnerHtml = GetAccountListHtml(output.resultSet);
                    }
                    else
                    {
                        ToDropdown.Items.Add(new ListItem { Text = "No Accounts Found", Value = "0" });
                    }
                }
                else
                {
                    ToDropdown.Items.Clear();
                    ToDropdown.Items.Add(new ListItem { Text = "No Accounts Found", Value = "0" });
                }
        }
        }

        protected void CreditButton_Click(object sender, EventArgs e)
        {
            if (Session["Access"].ToString() == "1" || Session["Access"].ToString() == "2")
            {
                if (ToDropdown.SelectedValue == "0")
                {
                    Master.ErrorMessage = "Error: Select the Account from which an amount has to be credited";
                }
                else if (Amount.Text == "" || !UI.Validate.isAmountValid(Amount.Text))
                {
                    Master.ErrorMessage = "Error: Amount cannot be empty, and amount accepts only decimal values.";
                }
                else
                {
                    var amount = Convert.ToDouble(Amount.Text);
                    var transactionCode = "012";
                    if (amount > 1000) transactionCode = "013";
                    var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(), string.Format("{3}|{0}| |{1}|{2}| ", ToDropdown.SelectedValue, amount, Session["Access"].ToString(), transactionCode));
                    Master.ErrorMessage = output.resultP;
                    ResetPage();
                }
            }
            else
            {
                var amount = Convert.ToDouble(Amount.Text);
                var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(), string.Format("012|{0}| |{1}|{2}| ", ToDropdown.SelectedValue, amount, Session["Access"].ToString()));
                Master.ErrorMessage = output.resultP;
                ResetPage();
            }
        }

        protected void CustomerDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccounts(CustomerDropDown.SelectedValue, byPass: true);
        }

        private void ResetPage()
        {
            Amount.Text = string.Empty;
        }
    }
}