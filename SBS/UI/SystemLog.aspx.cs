using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class SystemLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Access"] == null)
                Response.Redirect("UserLogin.aspx");
            if (Session["Access"].ToString() == "1")
                Response.Redirect("Home.aspx");
            else if (Session["Access"].ToString() == "2")
                Response.Redirect("MerchantHome.aspx");
            else if (Session["Access"].ToString() == "3" || Session["Access"].ToString() == "4")
                Response.Redirect("EmployeeHome.aspx");
            if (Global.IsPageAccessible(Page.Title))
            {
               LoadSystemLog();
            }
        }
         private void LoadSystemLog()
          {
           var xSwitch = new Business.XSwitch();
           NonFinHistoryGridView.DataSource = xSwitch.getNonFinHistory(Global.ConnectionString,"1");
           NonFinHistoryGridView.DataBind();
        }
    }
}
