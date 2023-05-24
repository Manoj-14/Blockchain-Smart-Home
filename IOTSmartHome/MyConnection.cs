using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace IOTSmartHome
{
    public class MyConnection
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataAdapter adp = null;

        public MyConnection()
        {
            con = new MySqlConnection("server=localhost;database=smartiot;user id=root;password=root;port=3306;");
            con.Open();
        }

        public int LoginVerify(string UserId, string Password, string UserType)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = "";
            if (UserType == "Admin")
            {
                sql = string.Format("Select count(*) from adminmaster where AdminId='{0}' and Password='{1}'", UserId, Password);
            }
            else if (UserType == "User")
            {
                sql = string.Format("Select count(*) from usermaster where UserId='{0}' and Password='{1}'", UserId, Password);
            }
            cmd.CommandText = sql;
            int result = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return result;
        }
        public string ChangePassword(string UserId, string Password, string UserType)
        {

            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            if (UserType == "Admin")
            {
                sql = string.Format("Update adminmaster set Password='{0}' where AdminId='{1}'", Password, UserId);
            }
            else if (UserType == "User")
            {
                sql = string.Format("Update usermaster set Password='{0}' where UserId='{1}'", Password, UserId);
            }
            
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public int Userverify(int UserId,string IpAddress,string MACAddress)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = "";
            sql = string.Format("Select count(*) from usermaster where UserId='{0}' and IpAddress='{1}' and MACAddress='{2}'", UserId, IpAddress, MACAddress);
            cmd.CommandText = sql;
            int result = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return result;
        }
        public string AddIOTDevice(string DId, string DeviceName, string Description)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;

            string chksql = string.Format("Select count(*) from devicemaster where DeviceId='{0}'", DId);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            string result = "";
            if (res == "0")
            {
                string sqls = string.Format("insert into devicemaster(DeviceId,DeviceName,Description)values('{0}','{1}','{2}')", DId,DeviceName,Description);
                cmd.CommandText = sqls;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }

        public string UserRegister(string UserId, string Name, string Password, string MobileNo, string EmailId, string Address,string IpAddress,string MACAddress)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string chksql = string.Format("Select count(*) from usermaster where IpAddress='{0}' and MACAddress='{1}'", IpAddress, MACAddress);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            string result = "";
            if (res == "0")
            {
                string sql = string.Format("insert into usermaster(UserId,Password,UserName,IpAddress,MACAddress,MobileNo,EmailId,Address,Status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','Pending')", UserId,Password,Name,IpAddress,MACAddress, MobileNo, EmailId, Address);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }
        public DataTable GetUserPending()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqllp = string.Format("select * from usermaster where Status='Pending'");
            cmd.CommandText = sqllp;
            DataTable tablp = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tablp);
            con.Close();
            return tablp;
        }
        public string ApproveUser(int UserId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            sql = string.Format("Update usermaster set Status='Approve' where UserId={0}", UserId);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public DataTable GetIOTDevice()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqllp = string.Format("select * from devicemaster");
            cmd.CommandText = sqllp;
            DataTable tablp = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tablp);
            con.Close();
            return tablp;
        }
        public DataTable GetIOTDevice(string DId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqllp = string.Format("select * from devicemaster where DeviceId<>'{0}'", DId);
            cmd.CommandText = sqllp;
            DataTable tablp = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tablp);
            con.Close();
            return tablp;
        }
        public DataTable GetIOT_UserLedger(int UserId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqllp = string.Format("select * from userledger where UserId<>{0}",UserId);
            cmd.CommandText = sqllp;
            DataTable tablp = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tablp);
            con.Close();
            return tablp;
        }
        public DataTable GetIOTUserLedger(int UserId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqllp = string.Format("select * from userledger where UserId={0}",UserId);
            cmd.CommandText = sqllp;
            DataTable tablp = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tablp);
            con.Close();
            return tablp;
        }
        public DataTable GetUser(int UserId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqllp = string.Format("select * from usermaster where UserId={0}", UserId);
            cmd.CommandText = sqllp;
            DataTable tablp = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tablp);
            con.Close();
            return tablp;
        }

        public string BCUserLedger(int UserId,string FilePath)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            sql = string.Format("insert into userledger(UserId,FilePath)values({0},'{1}')",UserId,FilePath);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
    }
}