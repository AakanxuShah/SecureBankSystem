using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace UI
{
    public partial class InternalTransfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Access"] == null)
                Response.Redirect("UserLogin.aspx");
            if(Session["Access"].ToString() == "3" || Session["Access"].ToString() == "4")
                Response.Redirect("EmployeeHome.aspx");
            if (Session["Access"].ToString() == "5")
                Response.Redirect("AdminHome.aspx");

            if (!IsPostBack)
            {
                if (Global.IsPageAccessible(Page.Title))
                {
                    LoadAccounts();
                    LoadRecepientAccounts();
                }
                else
                {
                    Response.Redirect("Error.aspx?error=NoAccess");
                }
            }
        }

        protected void Transfer_Click(object sender, EventArgs e)
        {
            //Send the Message of successful or failure(reason for failure)
            if (FromDropDown.SelectedValue == null || FromDropDown.SelectedValue == "0")
            {
                Master.ErrorMessage = "Error: Select the sender Account.";
            }
            else if (ToDropDown.SelectedValue == null || ToDropDown.SelectedValue == "0")
            {
                Master.ErrorMessage = "Error: Select the recepient Account.";
            }
            else if (AmountTransfer.Text == "" || !UI.Validate.isAmountValid(AmountTransfer.Text))
            {
                Master.ErrorMessage = "Error: Amount cannot be empty, and amount accepts only decimal values.";
            }
            else if (ConfirmAmount.Text == "" || !UI.Validate.isAmountValid(ConfirmAmount.Text))
            {
                Master.ErrorMessage = "Error: Confirmation Amount cannot be empty, and Confirmation Amount accepts only decimal values.";
            }
            else if (ConfirmAmount.Text != AmountTransfer.Text)
            {
                Master.ErrorMessage = "Error: Amount and Confirmation Amount should be same.";
            }
            else
            {
                var transferAmount = Convert.ToDecimal(ConfirmAmount.Text);
                var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(), string.Format("014|{0}|{1}|{2}|{3}| ",FromDropDown.SelectedValue, ToDropDown.SelectedValue, transferAmount, Session["Access"]));

                Master.ErrorMessage = output.resultP;
                ResetPage();
            }
        }

        private void LoadAccounts()
        {
            var output = new Business.XSwitch(Global.ConnectionString, Session["Username"].ToString(), string.Format("009|{0}", Session["UserId"].ToString()));
            if (output == null)
                Response.Redirect("Error.aspx");


            if (output != null && output.resultSet != null && output.resultSet.Tables.Count > 0 && output.resultSet.Tables[0].Rows.Count != 0)
            {
                FromDropDown.DataSource = output.resultSet.Tables[0];
                FromDropDown.DataTextField = "ac_no";
                FromDropDown.DataValueField = "ac_no";
                FromDropDown.DataBind();
                //AccountList.InnerHtml = GetAccountListHtml(output.resultSet);
            }
            else
            {
                FromDropDown.Items.Add(new ListItem { Text = "No Accounts Found", Value = "0" });
            }
        }

        protected void FromDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRecepientAccounts();
        }

        private void LoadRecepientAccounts()
        {
            var output = new Business.XSwitch(Global.ConnectionString, Session["Username"].ToString(), string.Format("009|{0}", Session["UserId"].ToString()));
            if (output == null)
                Response.Redirect("Error.aspx");


            if (output != null && output.resultSet != null && output.resultSet.Tables.Count > 0 && output.resultSet.Tables[0].Rows.Count != 0)
            {
                ToDropDown.DataSource = output.resultSet.Tables[0];
                ToDropDown.DataTextField = "ac_no";
                ToDropDown.DataValueField = "ac_no";
                ToDropDown.DataBind();

                ToDropDown.Items.Remove(FromDropDown.SelectedItem);
                //AccountList.InnerHtml = GetAccountListHtml(output.resultSet);
            }
            else
            {
                ToDropDown.Items.Add(new ListItem {Text= "Internal Transfer not allowed." , Value= "0"});
            }
        }

        private void ResetPage()
        {
            AmountTransfer.Text = string.Empty;
            ConfirmAmount.Text = string.Empty;
        }

    }
}