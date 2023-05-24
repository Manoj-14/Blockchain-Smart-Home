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
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;
using Amazon.S3.IO;
using System.Threading;

namespace IOTSmartHome
{
    public partial class AccessIOTDevice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetIOTDevice();
                ddlIOTDevice.DataSource = tab;
                ddlIOTDevice.DataTextField = "DeviceName";
                ddlIOTDevice.DataValueField = "DeviceId";
                ddlIOTDevice.DataBind();
                ddlIOTDevice.Items.Insert(0, "--Select--");
            }
        }
        
        //XmlDocument doc;
        //static string filename;
        //AmazonS3Client _s3ClientObj = null;
        //XmlDocument ledger;
        


        MqttClient client = null, pubclient = null;
        string clientId, pubclientId;
        string mqttserverip = "broker.hivemq.com";
        

        protected void btnON_Click(object sender, EventArgs e)
        {
            bool _isflag = IOTLedger("1");
            if (_isflag)
            {
                pubclient = new MqttClient(mqttserverip);

                pubclientId = Guid.NewGuid().ToString();
                pubclient.Connect(pubclientId);
                if (ddlIOTDevice.SelectedItem.Text == "Buzzer")
                {
                    pubclient.Publish("blockchaind2", Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                }
                else if (ddlIOTDevice.SelectedItem.Text == "Room LED")
                {
                    pubclient.Publish("blockchaind1", Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                }
                else if (ddlIOTDevice.SelectedItem.Text == "Front Light")
                {
                    pubclient.Publish("blockchaind4", Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                }
                lblMsg.Text = "IOT Device Communicated Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void btnOff_Click(object sender, EventArgs e)
        {
            bool _isflag = IOTLedger("0");
            if (_isflag)
            {
                pubclient = new MqttClient(mqttserverip);

                pubclientId = Guid.NewGuid().ToString();
                pubclient.Connect(pubclientId);
                if (ddlIOTDevice.SelectedItem.Text == "Buzzer")
                {
                    pubclient.Publish("blockchaind2", Encoding.UTF8.GetBytes("0"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

                }
                else if (ddlIOTDevice.SelectedItem.Text == "Room Light")
                {
                    pubclient.Publish("blockchaind1", Encoding.UTF8.GetBytes("0"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                }
                else if (ddlIOTDevice.SelectedItem.Text == "Front Light")
                {
                    pubclient.Publish("blockchaind4", Encoding.UTF8.GetBytes("0"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                }
                lblMsg.Text = "IOT Device Communicated Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }
        AmazonS3Client _s3ClientObj = null;
        XmlDocument ledger;
        XmlDocument doc;
        bool isflag = true;
        string bhcpath = "~/blockchainfile/";
        public bool IOTLedger(string devicevalue)
        {
            ////Amazon AWS 
            
            _s3ClientObj = new AmazonS3Client("Secret key", "Access Key", Amazon.RegionEndpoint.USEast1);
            S3FileInfo file = new S3FileInfo(_s3ClientObj, "iot-block-2023" + ddlIOTDevice.SelectedItem.Value.ToString().ToLower(), ddlIOTDevice.SelectedItem.Value.ToString().ToLower() + ".xml");
            bool filechk = file.Exists;

            if (filechk == false)
            {
                ledger = new XmlDocument();
                XmlElement root = null;
                string fname = ddlIOTDevice.SelectedItem.Value.ToString().ToLower() + ".xml";
                string filepath = bhcpath + fname;

                root = ledger.CreateElement("blockheadInfo");
                ledger.AppendChild(root);
                ledger.Save(Server.MapPath(filepath));

                ledger.Load(Server.MapPath(filepath));



                PutBucketRequest p1 = new PutBucketRequest();
                p1.BucketName = "iot-block-2023" + ddlIOTDevice.SelectedItem.Value.ToString().ToLower();
                _s3ClientObj.PutBucket(p1);

                string DTime = DateTime.Now.ToString();
                string ddata = ddlIOTDevice.SelectedItem.Value.ToString().ToLower() + devicevalue + DTime;

                string dataval = SHAHashValue.ShaKeyGeneration(ddlIOTDevice.SelectedItem.Value.ToString().ToLower(), devicevalue, DTime);

                // Create the blockchain and add the genesis block
                List<Block> blockchain = new List<Block>();
                Block genesisBlock = createGenesisBlock(ddlIOTDevice.SelectedItem.Value.ToString(),Session["MACAddress"].ToString(), devicevalue, dataval);
                blockchain.Add(genesisBlock);

                foreach (var item in blockchain)
                {
                    XmlElement ledgernode = ledger.CreateElement("iotdevice");

                    XmlElement index = ledger.CreateElement("SlNo");
                    index.InnerText = item.index.ToString();

                    XmlElement ts = ledger.CreateElement("Timestamp");
                    ts.InnerText = item.timestamp.ToString();

                    XmlElement d_id = ledger.CreateElement("DeviceId");
                    d_id.InnerText = item.deviceid.ToString();

                    XmlElement s_id = ledger.CreateElement("SourceId");
                    s_id.InnerText = item.sourceid;

                    XmlElement ds = ledger.CreateElement("DeviceStatus");
                    ds.InnerText = item.devicestatus;

                    XmlElement cldataval = ledger.CreateElement("DataVal");
                    cldataval.InnerText = item.dataval;

                    XmlElement phv = ledger.CreateElement("PHV");
                    phv.InnerText = item.previous_hash;

                    XmlElement chv = ledger.CreateElement("CHV");
                    chv.InnerText = item.hash;

                    ledgernode.AppendChild(index);
                    ledgernode.AppendChild(ts);
                    ledgernode.AppendChild(d_id);
                    ledgernode.AppendChild(s_id);
                    ledgernode.AppendChild(ds);
                    ledgernode.AppendChild(cldataval);
                    ledgernode.AppendChild(phv);
                    ledgernode.AppendChild(chv);

                    ledger.DocumentElement.AppendChild(ledgernode);

                    ledger.Save((Server.MapPath(filepath)));
                }
                PutObjectRequest _requestObj = new PutObjectRequest();
                _requestObj.BucketName = "iot-block-2023" + ddlIOTDevice.SelectedItem.Value.ToString().ToLower();
                _requestObj.FilePath = Server.MapPath(filepath);
                PutObjectResponse _responseObj = _s3ClientObj.PutObject(_requestObj);
                if (_responseObj.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    File.Delete((Server.MapPath(filepath)));
                    MyConnection obj = new MyConnection();
                    DataTable tab = new DataTable();
                    tab = obj.GetIOTDevice(ddlIOTDevice.SelectedItem.Value.ToString());
                    if (tab.Rows.Count > 0)
                    {
                        for (int i = 0; i < tab.Rows.Count; i++)
                        {
                            ledger = new XmlDocument();
                            root = null;
                            fname = tab.Rows[i]["DeviceId"].ToString().ToLower() + ".xml";
                            filepath = bhcpath + fname;

                            root = ledger.CreateElement("blockheadInfo");
                            ledger.AppendChild(root);
                            ledger.Save(Server.MapPath(filepath));

                            ledger.Load(Server.MapPath(filepath));

                            ////Amazon AWS 
                            //_s3ClientObj = new AmazonS3Client("AKIA2PAQROQSWPFRCBEY", "tjrNzQwPc55MOxbAsyCfmqKeNjKqS+VJs4I7F+Ni", Amazon.RegionEndpoint.USEast1);
                            _s3ClientObj = new AmazonS3Client("Secret key", "Access Key", Amazon.RegionEndpoint.USEast1);
                            p1 = new PutBucketRequest();
                            p1.BucketName = "iot-block-2023" + tab.Rows[i]["DeviceId"].ToString().ToLower();
                            _s3ClientObj.PutBucket(p1);

                            //DTime = DateTime.Now.ToString();
                            ddata = ddlIOTDevice.SelectedItem.Value.ToString().ToLower() + devicevalue + DTime;

                            dataval = SHAHashValue.ShaKeyGeneration(ddlIOTDevice.SelectedItem.Value.ToString().ToLower(), devicevalue, DTime);

                            // Create the blockchain and add the genesis block
                            blockchain = new List<Block>();
                            genesisBlock = createGenesisBlock(ddlIOTDevice.SelectedItem.Value.ToString(),Session["MACAddress"].ToString(), devicevalue, dataval);
                            blockchain.Add(genesisBlock);

                            foreach (var item in blockchain)
                            {
                                XmlElement ledgernode = ledger.CreateElement("iotdevice");

                                XmlElement index = ledger.CreateElement("SlNo");
                                index.InnerText = item.index.ToString();

                                XmlElement ts = ledger.CreateElement("Timestamp");
                                ts.InnerText = item.timestamp.ToString();

                                XmlElement d_id = ledger.CreateElement("DeviceId");
                                d_id.InnerText = item.deviceid.ToString();

                                XmlElement s_id = ledger.CreateElement("SourceId");
                                s_id.InnerText = item.sourceid;

                                XmlElement ds = ledger.CreateElement("DeviceStatus");
                                ds.InnerText = item.devicestatus;

                                XmlElement cldataval = ledger.CreateElement("DataVal");
                                cldataval.InnerText = item.dataval;

                                XmlElement phv = ledger.CreateElement("PHV");
                                phv.InnerText = item.previous_hash;

                                XmlElement chv = ledger.CreateElement("CHV");
                                chv.InnerText = item.hash;

                                ledgernode.AppendChild(index);
                                ledgernode.AppendChild(ts);
                                ledgernode.AppendChild(d_id);
                                ledgernode.AppendChild(s_id);
                                ledgernode.AppendChild(ds);
                                ledgernode.AppendChild(cldataval);
                                ledgernode.AppendChild(phv);
                                ledgernode.AppendChild(chv);

                                ledger.DocumentElement.AppendChild(ledgernode);

                                ledger.Save(Server.MapPath(filepath));
                            }
                            _requestObj = new PutObjectRequest();
                            _requestObj.BucketName = "iot-block-2023" + tab.Rows[i]["DeviceId"].ToString().ToLower();
                            _requestObj.FilePath = Server.MapPath(filepath);
                            _responseObj = _s3ClientObj.PutObject(_requestObj);
                            if (_responseObj.HttpStatusCode == System.Net.HttpStatusCode.OK)
                            {
                                File.Delete(Server.MapPath(filepath));
                            }

                        }
                    }
                }


            }
            else
            {
                string fname =ddlIOTDevice.SelectedItem.Value.ToString().ToLower() + ".xml";
                string fpath = bhcpath + fname;
                string bn = "iot-block-2023" + ddlIOTDevice.SelectedItem.Value.ToString().ToLower();
                GetObjectResponse _responseObj = _s3ClientObj.GetObject(new GetObjectRequest() { BucketName = bn, Key = fname });
                _responseObj.WriteResponseStreamToFile(Server.MapPath(fpath));

               // _s3ClientObj.DeleteObject(new Amazon.S3.Model.DeleteObjectRequest() { BucketName = bn, Key = fname });

                ledger = new XmlDocument();
                ledger.Load(Server.MapPath(fpath));

                XmlNodeList xmlNL = ledger.GetElementsByTagName("iotdevice");
                int cnt = xmlNL.Count;

                MyConnection obj = new MyConnection();
                DataTable tabdevice = new DataTable();
                tabdevice = obj.GetIOTDevice(ddlIOTDevice.SelectedItem.Value.ToString());
                string _DTime = "";
                if (tabdevice.Rows.Count != 0)
                {
                    for (int i = 0; i < tabdevice.Rows.Count; i++)
                    {
                        string _fname = tabdevice.Rows[i]["DeviceId"].ToString().ToLower() + ".xml";
                        string _fpath = bhcpath + _fname;
                        string _bn = "iot-block-2023" + tabdevice.Rows[i]["DeviceId"].ToString().ToLower();

                        _responseObj = _s3ClientObj.GetObject(new GetObjectRequest() { BucketName = _bn, Key = _fname });
                        _responseObj.WriteResponseStreamToFile(Server.MapPath(_fpath));

                        //_s3ClientObj.DeleteObject(new Amazon.S3.Model.DeleteObjectRequest() { BucketName = _bn, Key = _fname });

                        doc = new XmlDocument();
                        doc.Load(Server.MapPath(_fpath));

                        XmlNodeList _xmlNL = doc.GetElementsByTagName("iotdevice");
                        int _cnt = _xmlNL.Count;
                        if (_cnt > 6)
                        {
                            _cnt = 4;
                        }
                        XElement _xelement = XElement.Load(Server.MapPath(_fpath));

                        XElement xelement = XElement.Load(Server.MapPath(fpath));

                        for (int k = _cnt - 1; k >= 0; k--)
                        {
                            var _val = from nm in _xelement.Elements("iotdevice")
                                       where (string)nm.Element("SlNo") == k.ToString()
                                       select nm;


                            var val = from nm in xelement.Elements("iotdevice")
                                      where (string)nm.Element("SlNo") == k.ToString()
                                      select nm;

                            if (isflag)
                            {
                                foreach (XElement _xEle in _val)
                                {
                                    foreach (XElement xEle in val)
                                    {
                                        if (_xEle.Element("DataVal").Value == xEle.Element("DataVal").Value)
                                        {
                                            //string data = _xEle.Element("DataVal").Value;
                                            //break;
                                            isflag = true;
                                        }
                                        else
                                        {
                                            isflag = false;
                                            lblMsg.Text = "Incorrect Transaction Found!!!...";
                                            lblMsg.ForeColor = System.Drawing.Color.Red;
                                            break;
                                        }
                                    }

                                }
                            }


                        }

                        if (isflag)
                        {
                            _DTime = DateTime.Now.ToString();
                            _BCLedger(_fpath, _fname, _bn, devicevalue, _DTime);
                        }
                    }
                    if (isflag)
                    {
                        _BCLedger(fpath, fname, bn, devicevalue, _DTime);
                    }
                }
            }
            return isflag;

        }

        static Block createGenesisBlock(string deviceid, string sourceid, string devicestatus, string dataval)
        {
            return new Block(0, DateTime.Now, deviceid, sourceid, devicestatus, dataval, "0");
        }
        private void _BCLedger(string filepath, string filename, string bn, string devicevalue, string _DTime)
        {
            doc = new XmlDocument();
            doc.Load(Server.MapPath(filepath));

            XmlElement root = doc.DocumentElement;
            List<Block> blockchain = new List<Block>();
            foreach (XmlElement ele in root.ChildNodes)
            {
                blockchain.Add(new Block(int.Parse(ele["SlNo"].InnerText), DateTime.Parse(ele["Timestamp"].InnerText), ele["DeviceId"].InnerText, ele["SourceId"].InnerText, ele["DeviceStatus"].InnerText, ele["DataVal"].InnerText, ele["PHV"].InnerText));
                break;
            }
            
            foreach (XmlElement ele in root.ChildNodes)
            {
                if (ele["SlNo"].InnerText != "0")
                {
                    Block previousBlock = blockchain[int.Parse(ele["SlNo"].InnerText) - 1];
                    Block blockToAdd = Block.nextBlock(previousBlock, ele["DeviceId"].InnerText, ele["SourceId"].InnerText, ele["DeviceStatus"].InnerText, ele["DataVal"].InnerText);//DataVal
                    blockchain.Add(blockToAdd);
                    //previousBlock = blockToAdd;
                }
            }
            string DTime = _DTime;
            string ddata = ddlIOTDevice.SelectedItem.Value.ToString().ToLower() + devicevalue + DTime;

            string dataval = SHAHashValue.ShaKeyGeneration(ddlIOTDevice.SelectedItem.Value.ToString().ToLower(), devicevalue, DTime);
            //string ddata = ddlIOTDevice.SelectedItem.Value + txtDeviceValue.Text;

            //string dataval = SHAHashValue.ShaKeyGeneration(ddlIOTDevice.SelectedItem.Value, txtDeviceValue.Text);

            Block PreviousBlock = blockchain[blockchain.Count - 1];
            Block BlockToAdd = Block.nextBlock(PreviousBlock, ddlIOTDevice.SelectedItem.Value.ToString(),Session["MACAddress"].ToString(), devicevalue, dataval);
            blockchain.Add(BlockToAdd);

            //string _filepath = "";


            ////Ledger 1
            //_filepath = "~/blockchainfile/" + filename;

            ledger = new XmlDocument();
            XmlElement ledger_root = null;

            if (File.Exists(Server.MapPath(filepath)))
            {
                File.Delete(Server.MapPath(filepath));
            }

            if (File.Exists(Server.MapPath(filepath)) == false)
            {
                ledger_root = ledger.CreateElement("blockheadInfo");
                ledger.AppendChild(ledger_root);
                ledger.Save(Server.MapPath(filepath));
            }
            ledger.Load(Server.MapPath(filepath));

            foreach (var item in blockchain)
            {
                XmlElement ledgernode = ledger.CreateElement("iotdevice");

                XmlElement index = ledger.CreateElement("SlNo");
                index.InnerText = item.index.ToString();

                XmlElement ts = ledger.CreateElement("Timestamp");
                ts.InnerText = item.timestamp.ToString();

                XmlElement d_id = ledger.CreateElement("DeviceId");
                d_id.InnerText = item.deviceid.ToString();

                XmlElement s_id = ledger.CreateElement("SourceId");
                s_id.InnerText = item.sourceid;

                XmlElement ds = ledger.CreateElement("DeviceStatus");
                ds.InnerText = item.devicestatus;

                XmlElement cldataval = ledger.CreateElement("DataVal");
                cldataval.InnerText = item.dataval;

                XmlElement phv = ledger.CreateElement("PHV");
                phv.InnerText = item.previous_hash;

                XmlElement chv = ledger.CreateElement("CHV");
                chv.InnerText = item.hash;

                ledgernode.AppendChild(index);
                ledgernode.AppendChild(ts);
                ledgernode.AppendChild(d_id);
                ledgernode.AppendChild(s_id);
                ledgernode.AppendChild(ds);
                ledgernode.AppendChild(cldataval);
                ledgernode.AppendChild(phv);
                ledgernode.AppendChild(chv);

                ledger.DocumentElement.AppendChild(ledgernode);

                ledger.Save(Server.MapPath(filepath));
            }
            _s3ClientObj.DeleteObject(new Amazon.S3.Model.DeleteObjectRequest() { BucketName = bn, Key = filename });

            PutObjectRequest _requestObj = new PutObjectRequest();
            _requestObj.BucketName = bn;
            _requestObj.FilePath = Server.MapPath(filepath);
            PutObjectResponse _responseObj1 = _s3ClientObj.PutObject(_requestObj);
            if (_responseObj1.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                File.Delete(Server.MapPath(filepath));
            }
        }

        protected void btnRecover_Click(object sender, EventArgs e)
        {
            ////Amazon AWS 
           // _s3ClientObj = new AmazonS3Client("AKIA2PAQROQSWPFRCBEY", "tjrNzQwPc55MOxbAsyCfmqKeNjKqS+VJs4I7F+Ni", Amazon.RegionEndpoint.USEast1);
            _s3ClientObj = new AmazonS3Client("Secret key", "Access Key", Amazon.RegionEndpoint.USEast1);
            string fname = ddlIOTDevice.SelectedItem.Value.ToString().ToLower() + ".xml";
            string fpath = bhcpath + fname;
            string bn = "iot-block-2023" + ddlIOTDevice.SelectedItem.Value.ToString().ToLower();
            GetObjectResponse _responseObj = _s3ClientObj.GetObject(new GetObjectRequest() { BucketName = bn, Key = fname });
            _responseObj.WriteResponseStreamToFile(Server.MapPath(fpath));

            _s3ClientObj.DeleteObject(new Amazon.S3.Model.DeleteObjectRequest() { BucketName = bn, Key = fname });

            doc = new XmlDocument();
            doc.Load(Server.MapPath(fpath));

            XmlNodeList _xmlNL = doc.GetElementsByTagName("iotdevice");
            int _cnt = _xmlNL.Count;

            MyConnection obj = new MyConnection();
            DataTable tabdevice = new DataTable();



            tabdevice = obj.GetIOTDevice(ddlIOTDevice.SelectedItem.Value.ToString());

            string _fname = tabdevice.Rows[0]["DeviceId"].ToString().ToLower() + ".xml";
            string _fpath = bhcpath + _fname;
            string _bn = "iot-block-2023" + tabdevice.Rows[0]["DeviceId"].ToString().ToLower();

            _responseObj = _s3ClientObj.GetObject(new GetObjectRequest() { BucketName = _bn, Key = _fname });
            _responseObj.WriteResponseStreamToFile(Server.MapPath(_fpath));

            

            ledger = new XmlDocument();
            ledger.Load(Server.MapPath(_fpath));

            XmlElement root = ledger.DocumentElement;
            string Dataval = "";
            foreach (XmlElement ele in root.ChildNodes)
            {
                if (ele["SlNo"].InnerText == (_cnt - 1).ToString())
                {
                    Dataval=ele["DataVal"].InnerText;
                    break;
                }
            }


            XmlElement _root = doc.DocumentElement;
            foreach (XmlElement ele in _root.ChildNodes)
            {
                if (ele["SlNo"].InnerText == (_cnt - 1).ToString())
                {
                    ele["DataVal"].InnerText = Dataval;
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
                File.Delete(Server.MapPath(_fpath));
                lblMsg.Text = "Transaction Recover Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }

        }

       
    }
}