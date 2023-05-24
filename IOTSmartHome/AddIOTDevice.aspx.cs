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
    public partial class AddIOTDevice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            string result = obj.AddIOTDevice(txtDeviceId.Text, txtName.Text, txtDescription.Text);
            if (result == "1")
            {
                txtDeviceId.Text = txtName.Text = txtDescription.Text = "";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "IOT Device Added Successfully";
            }
            else if (result == "2")
            {
                txtDeviceId.Text = txtName.Text = txtDescription.Text = "";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "IOT Device Added Already";
            }
        }
    }
}