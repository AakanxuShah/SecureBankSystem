using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace UI
{
    public partial class MerchantDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
                Response.Redirect("UserLogin.aspx");

            if (Session["UserId"] == null || Session["Access"] == null)
                Response.Redirect("UserLogin.aspx");
            if (Session["Access"].ToString() == "3" || Session["Access"].ToString() == "4")
                Response.Redirect("EmployeeHome.aspx");
            if (Session["Access"].ToString() == "1")
                Response.Redirect("Home.aspx");

            if (Global.IsPageAccessible(Page.Title))
            {
                LoadAccounts();
            }
        }
        private void LoadAccounts()
        {
            var output = new Business.XSwitch(Global.ConnectionString, Session["Username"].ToString(), string.Format("009|{0}", Session["UserId"].ToString()));
            if (output == null)
                Response.Redirect("UserLogin.aspx");

            if ((output.resultSet != null ) && (output.resultSet.Tables[0].Rows.Count != 0))
            {
                MerchantAccountlist.InnerHtml = GetAccountListHtml(output.resultSet);
            }
            else
            {
                MerchantAccountlist.InnerHtml = "<li class='list-group-item'>You have no accounts. <a href='CreateAccount.aspx'> Request for one?</a> </li>";
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

        

    }
}