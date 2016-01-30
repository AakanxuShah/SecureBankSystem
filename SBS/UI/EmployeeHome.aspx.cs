using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class EmployeeHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Access"] == null)
                Response.Redirect("UserLogin.aspx");
            else if (Session["Access"].ToString() == "2" || Session["Access"].ToString() == "1")
                Response.Redirect("UserLogin.aspx");

            if (Global.IsPageAccessible(Page.Title))
            {
                LoadPendingTransactions();
            }
        }

        private void LoadPendingTransactions()
        {
            var output = new Business.XSwitch(Global.ConnectionString, Session["Username"].ToString(), string.Format("008|{0}", Session["Access"].ToString()));
            if (output == null)
                Response.Redirect("UserLogin.aspx");

            if (output.resultSet.Tables[0].Rows.Count != 0)
            {
                GetPendingTransactionTableHtml(output.resultSet);
            }
            else
            {
               //no data
            }
        }

        private void GetPendingTransactionTableHtml(DataSet data)
        {
            PendingTransactionGridView.DataSource = data;
            PendingTransactionGridView.DataBind();
        }
        
        protected void PendingTransactionGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                var mainPanel = new Panel { CssClass= "btn-group" };
                var approveButton = new Button
                {
                    CssClass = "btn btn-default",
                    CommandArgument = e.Row.Cells[0].Text,
                    CommandName = "Approve",
                    Text = "Approve"
                };
                var rejectButton = new Button
                {
                    CssClass = "btn btn-default",
                    CommandArgument = e.Row.Cells[0].Text,
                    CommandName = "Reject",
                    Text = "Reject",
                };
                var lastIndex = e.Row.Cells.Count == 0 ? 0 : e.Row.Cells.Count - 1;
                mainPanel.Controls.Add(approveButton);
                mainPanel.Controls.Add(rejectButton);
                e.Row.Cells[lastIndex].Controls.Add(mainPanel);
                e.Row.Cells[lastIndex].HorizontalAlign = HorizontalAlign.Right;
            }
        }

        protected void PendingTransactionGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var referenceNumber = e.CommandArgument.ToString();
            switch (e.CommandName.ToLower())
            {
                case "approve":
                    //approve request id
                    //var output = new Business.XSwitch(Global.ConnectionString, Session["Username"].ToString(), string.Format("<tran code>|<account number1>| | <"));
                    ProcessTransaction(referenceNumber, true);
                    break;
                case "reject":
                    //reject request id
                    ProcessTransaction(referenceNumber, false);
                    break;
                default:
                    break;
            }
        }

        public void ProcessTransaction(string referenceNumber, bool approved)
        {
            var xSwitchObject = new Business.XSwitch();
            if (approved)
            {
                var data = xSwitchObject.geTranDataFromRefNumber(Global.ConnectionString, referenceNumber);
                var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(), string.Format("{0}|{1}|{2}", data, Session["Access"].ToString(), referenceNumber));
                Master.ErrorMessage = "Transaction was processed.";
            }
            else
            {
                if (xSwitchObject.deletePendingTransaction(Global.ConnectionString, referenceNumber))
                {
                    Master.ErrorMessage = "Transaction was deleted.";
                }
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}
