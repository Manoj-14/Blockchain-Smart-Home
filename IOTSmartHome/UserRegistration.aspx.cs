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
    public partial class UserRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string GetMacAddress()
        {
            string MacAddress = string.Empty;
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            MacAddress = Convert.ToString(nics[0].GetPhysicalAddress());

            return MacAddress;
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            Random rnd = new Random();
            string MacAddress = GetMacAddress();
            string hostName = Dns.GetHostName(); 
            string IpAddress = Dns.GetHostByName(hostName).AddressList[0].ToString();
            string UserId = (rnd.Next(100000, 999999) + DateTime.Now.Second).ToString();
            string Password = (rnd.Next(1000, 9999) + DateTime.Now.Second).ToString();
            string result = obj.UserRegister(UserId,txtUserName.Text,Password,txtMobileNo.Text,txtEmailId.Text,txtAddress.Text,IpAddress,MacAddress);
            if (result == "1")
            {
                string Message = "Login Credentials User Id:" + UserId + " & Password:" + Password;
                SendEmail.Send(txtEmailId.Text, Message);
                txtUserName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "User Register Successfully & Credentials Mailed";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (result == "2")
            {
                txtUserName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Ip Address & MAC Address Already Register!!!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (result == "0")
            {
                txtUserName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "User Registration Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}