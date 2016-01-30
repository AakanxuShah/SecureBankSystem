using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Access"] == null)
                Response.Redirect("UserLogin.aspx");
            if (Session["Access"].ToString() == "3" || Session["Access"].ToString() == "4")
                Response.Redirect("EmployeeHome.aspx");
            if (Session["Access"].ToString() == "5")
                Response.Redirect("AdminHome.aspx");

            if (!IsPostBack)
                Request.UrlReferrer.ToString();
        }

        protected void AccountCreate_click(object sender, EventArgs e)
        {
            try { 
                string[] arglist = new String[5];
                int argIndex = 0;

                arglist[argIndex++] = Mnemonics.TxnCodes.TX_CREATE_ACCOUNT;
                arglist[argIndex++] = AccountTypeDropDownList.Text;
                arglist[argIndex++] = Session["UserId"].ToString();
                arglist[argIndex++] = "0";
                arglist[argIndex++] = "0";

                var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(), string.Format("{0}|{1}|{2}|{3}|{4}", arglist));
                Master.ErrorMessage = "Account request created.  Email will be sent when administrator reviews.";
            }
            catch { }

            if (Session["Access"].ToString() == "1")
            {
                Response.Redirect("Home.aspx");
            }
            else if (Session["Access"].ToString() == "2")
            {
                Response.Redirect("MerchantHome.aspx");
            }

        }
    }
}