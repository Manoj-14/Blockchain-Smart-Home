using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;
using System.Net;

namespace IOTSmartHome
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            int result = obj.LoginVerify(txtUserId.Text, txtPassword.Text, ddlUserType.SelectedItem.Text);
            if (result == 1)
            {
                Session["UserId"] = txtUserId.Text;
                Session["Password"] = txtPassword.Text;
                Session["UserType"] = ddlUserType.SelectedItem.Text;
                switch (ddlUserType.SelectedItem.Text)
                {
                    case "Admin":
                        Response.Redirect("AdminHome.aspx");
                        break;
                    case "User":
                        VerifyUser();
                        break;
                    
                }
            }
            else
            {
                lblMsg.Text = "Invalid UserId/Password";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void VerifyUser()
        {
            string MacAddress = GetMacAddress();
            string hostName = Dns.GetHostName();
            string IpAddress = Dns.GetHostByName(hostName).AddressList[0].ToString();
            MyConnection obj = new MyConnection();
            int result = obj.Userverify(int.Parse(txtUserId.Text), IpAddress, MacAddress);
            if (result == 1)
            {
                Session["MacAddress"] = MacAddress;
                Session["IpAddress"] = IpAddress;
                Response.Redirect("UserHome.aspx");
            }
            else
            {
                lblMsg.Attributes.Add("class", "text-center");
                lblMsg.Text = "Invalid IpAddress/MACAddress,Login with Registered System";
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        public string GetMacAddress()
        {
            string MacAddress = string.Empty;
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            MacAddress = Convert.ToString(nics[0].GetPhysicalAddress());

            return MacAddress;
        }
    }
}