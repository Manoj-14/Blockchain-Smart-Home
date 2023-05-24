using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using Amazon.S3;
using System.IO;
using Amazon.S3.Model;
using System.Xml.Linq;
using System.Text;
using Amazon.S3.IO;

namespace TamperApplication
{
    public partial class TamperIOT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        AmazonS3Client _s3ClientObj = null;
        XmlDocument ledger;
        XmlDocument doc;
        bool isflag = true;
        string bhcpath = "~/blockchainfile/";
        protected void btnTamper_Click(object sender, EventArgs e)
        {
            ////Amazon AWS 
            // _s3ClientObj = new AmazonS3Client("AKIA2PAQROQSWPFRCBEY", "tjrNzQwPc55MOxbAsyCfmqKeNjKqS+VJs4I7F+Ni", Amazon.RegionEndpoint.USEast1);
            _s3ClientObj = new AmazonS3Client("AKIA5PQGNSWUGXTJJQ2J", "aRvCFL5UPXhgaUWNIQ2mL5bDTxxIdHj3Od8CJkN6", Amazon.RegionEndpoint.USEast1);
            string fname = ddlIOT.SelectedItem.Value.ToString().ToLower() + ".xml";
            string fpath = bhcpath + fname;
            string bn = "iot-block-2023" + ddlIOT.SelectedItem.Value.ToString().ToLower();
            GetObjectResponse _responseObj = _s3ClientObj.GetObject(new GetObjectRequest() { BucketName = bn, Key = fname });
            _responseObj.WriteResponseStreamToFile(Server.MapPath(fpath));

            _s3ClientObj.DeleteObject(new Amazon.S3.Model.DeleteObjectRequest() { BucketName = bn, Key = fname });

            doc = new XmlDocument();
            doc.Load(Server.MapPath(fpath));

            XmlNodeList _xmlNL = doc.GetElementsByTagName("iotdevice");
            int _cnt = _xmlNL.Count;


            XmlElement root = doc.DocumentElement;
            foreach (XmlElement ele in root.ChildNodes)
            {
                if (ele["SlNo"].InnerText == (_cnt - 1).ToString())
                {
                    string logdate = DateTime.Now.ToString();
                    string hashvalue = SHAHashValue.ShaKeyGeneration(ele["DeviceId"].InnerText, "1", logdate);

                    ele["DataVal"].InnerText = hashvalue;
                    doc.Save(Server.MapPath(fpath));
                    break;
                }
            }

            PutObjectRequest _requestObj = new PutObjectRequest();
            _requestObj.BucketName = bn;
            _requestObj.FilePath = Server.MapPath(fpath);
            PutObjectResponse _responseObj1 = _s3ClientObj.PutObject(_requestObj);
            if (_responseObj1.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                File.Delete(Server.MapPath(fpath));
            }
        }
    }
}