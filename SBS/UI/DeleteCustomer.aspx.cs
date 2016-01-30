using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class DeleteCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Access"] == null)
                Response.Redirect("UserLogin.aspx");
            if (Session["Access"].ToString() == "3")
                Response.Redirect("EmployeeHome.aspx");
            if (Session["Access"].ToString() == "1")
                Response.Redirect("Home.aspx");
            if (Session["Access"].ToString() == "2")
                Response.Redirect("MerchantHome.aspx");

            if (!IsPostBack)
            {
                if (Global.IsPageAccessible(Page.Title))
                {
                    LoadCustomers(Session["UserId"].ToString());
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

            try
            {
                var output = xSwitchObject.getMerchantAccessibleCustomerData(Global.ConnectionString, Session["UserId"].ToString());
                if ((output == null) || (output.Tables[0].Rows.Count != 0))
                {
                    CustomerDropDown.DataSource = output.Tables[0];
                    CustomerDropDown.DataTextField = "cs_uname";
                    CustomerDropDown.DataValueField = "cs_no";
                    CustomerDropDown.DataBind();
                }
                else
                {
                    CustomerDropDown.Items.Add(new ListItem { Text = "No customers found.", Value = "0" });
                }
            }
            catch { }
        }

        protected void DeleteCustomer_Click(object sender, EventArgs e)
        {
            try { 
                string[] arglist = new String[24];
                int argIndex = 0;

                arglist[argIndex++] = Mnemonics.TxnCodes.TX_DELETE_USER_EMPLOYEE;
                arglist[argIndex++] = CustomerDropDown.SelectedValue;


                var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(),
                    string.Format("{0}|{1}", arglist));

                Master.ErrorMessage = "Customer Account Disabled.";
            }
            catch { }
            Response.Redirect("EmployeeHome.aspx");
        }
    }
}