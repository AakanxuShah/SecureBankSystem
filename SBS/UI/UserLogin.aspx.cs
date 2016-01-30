using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

           if(!IsPostBack)
            {
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
            }
        }
                
        protected void Forgotpassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            var userName = UserNameTextBox.Text.ToString();
            try
            {
                if (UserNameTextBox.Text == string.Empty || hashPasswordHiddenField.Value == string.Empty)
                {
                    MessageLabel.Text = "Error: Invalid login credentials.";
                }
                else
                {
                    var password = hashPasswordHiddenField.Value;
                    if (UI.Validate.isUserNameValid(userName))
                    { 

                        //if (Global.LoggedInUsers.Contains(userName) || Global.LoggedInUsers.Count>50)
                        //{
                        //    MessageLabel.Text = "Error: User is already logged in.";
                        //    return;
                        //}
                        var xSwitch = new Business.XSwitch();
                        //var encryptedConnectionString = Security.PKIService.EncryptData(Global.ConnectionString, xSwitch.getBankPublicKey(Global.ConnectionString));
                        var encryptedUserName = Security.PKIService.EncryptData(userName, xSwitch.getBankPublicKey(Global.ConnectionString));
                        var encryptedData = Security.PKIService.EncryptData(string.Format("{0}|{1}", userName, password), xSwitch.getBankPublicKey(Global.ConnectionString));

                        Session["Username"] = userName.Trim();
                        //var xSwitchObject = new Business.XSwitch(Global.ConnectionString, userName, string.Format("001|{0}|{1}", userName, password));
                        var xSwitchObject = new Business.XSwitch(Global.ConnectionString, encryptedUserName, "001|" + encryptedData);
                        
                        var encrytedOutput = xSwitchObject.resultP;
                        var output = (string)Security.PKIService.DecryptData(encrytedOutput, xSwitchObject.getCustomerPrivateKey(Global.ConnectionString, userName.ToString()));
                        if (output.Contains("|"))
                        {
                            //Global.LoggedInUsers.Add(userName);
                            var dataRecieved = output.Split('|');
                            Session["UserId"] = dataRecieved[0];
                            Session["UserName"] = dataRecieved[1].Trim() + " " + dataRecieved[2].Trim();
                            Session["Access"] = dataRecieved[3];
                            Session["UserEmail"] = dataRecieved[4];
                            MessageLabel.Text = "";
                            switch (dataRecieved[3])
                            {
                                case "1":
                                    Response.Redirect("Home.aspx", false);
                                    break;
                                case "2":
                                    Response.Redirect("MerchantHome.aspx", false);
                                    break;
                                case "3":
                                case "4":
                                    Response.Redirect("EmployeeHome.aspx", false);
                                    break;
                                case "5":
                                    Response.Redirect("AdminHome.aspx", false);
                                    break;
                                default:
                                    MessageLabel.Text = "Error: Invalid login credentials.";
                                    //Global.LoggedInUsers.Remove(userName);

                                    break;
                            }
                        }
                        else
                        {
                            MessageLabel.Text = "Error: Invalid login credentials.";
                        }
                    }
                    else
                    {
                        MessageLabel.Text = "Error: Invalid login credentials.";
                    }
                }
            }
            catch (Exception ex)
            {
                //Global.LoggedInUsers.Remove(userName);
                MessageLabel.Text = "Error: Invalid login credentials.";
            }
        }

        protected void ForgotPasswordLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}