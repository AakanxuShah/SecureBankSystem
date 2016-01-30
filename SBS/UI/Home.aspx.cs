using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Access"] == null)
                Response.Redirect("UserLogin.aspx");

            if (Session["Access"].ToString() == "2")
                Response.Redirect("MerchantHome.aspx");
            if (Session["Access"].ToString() == "3" || Session["Access"].ToString() == "4")
                Response.Redirect("EmployeeHome.aspx");
            if (Session["Access"].ToString() == "5")
                Response.Redirect("AdminHome.aspx");

            LoadAccounts();
        }

        private void LoadAccounts()
        {
            var output = new Business.XSwitch(Global.ConnectionString, Session["Username"].ToString(), string.Format("009|{0}", Session["UserId"].ToString()));
            if (output == null)
                Response.Redirect("UserLogin.aspx");

            if ((output.resultSet != null) && (output.resultSet.Tables[0].Rows.Count != 0))
            {
                AccountList.InnerHtml = GetAccountListHtml(output.resultSet);
            }
            else
            {
                AccountList.InnerHtml = "<li class='list-group-item'>You have no accounts. <a href='CreateAccount.aspx'> Request for one?</a> </li>";
            }
        }

        private string GetAccountListHtml(DataSet data)
        {
            var sb = new StringBuilder();
            foreach (DataRow row in data.Tables[0].Rows)
            {
                sb.Append(string.Format("<li class='list-group-item'> <span class='custombadge badge'>${1}</span> {0} </li>", row["ac_type"].ToString() + " (" + row["ac_no"].ToString() + ")", row["ac_bal"].ToString()));
            }
            return sb.ToString();
        }

        private string GetAccountListHtml()
        {
            //get list of accounts for logged in user from business !
            //then loop through all accounts and build a html in the following format
            //<li class='list-group-item'> <span class='badge'>$14</span> Sample format </li>

            var sb = new StringBuilder();

            sb.Append(string.Format("<li class='list-group-item'> <span class='custombadge badge'>{1}</span> {0} </li>", "Savings Account", "$450.00"));
            sb.Append(string.Format("<li class='list-group-item'> <span class='custombadge badge'>{1}</span> {0} </li>", "Checkings Account", "$50.00"));

            return sb.ToString();
        }

        [WebMethod]
        public static string GetKey()
        {
            return Global.ReadCustomerPrivateKey();
        }

        [WebMethod]
        public static string GetPublicKey()
        {
            return Global.ReadBankPublicKey();
        }
    }
}