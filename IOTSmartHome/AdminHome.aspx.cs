using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IOTSmartHome
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            if (txtOldPassword.Text == Session["Password"].ToString())
            {

                string Result = obj.ChangePassword(Session["UserId"].ToString(), txtNewPassword.Text, Session["UserType"].ToString());
                if (Result != "0")
                {
                    Session["Password"] = txtNewPassword.Text;
                    txtNewPassword.Text = txtConfirmPassword.Text = txtOldPassword.Text = "";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Password Reset Successfully";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Password Reset Error";
                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Invalid Old Password";
            }
        }
    }
}