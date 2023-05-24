using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace TamperApplication
{
    [Serializable]
    public class Block
    {
        public int index;
        public DateTime timestamp;
        public string deviceid;
        public string sourceid;
        public string devicestatus;
        public string data;
        public string dataval;
        public string previous_hash;
        public string hash;

        // The Definition of a Block
        public Block(int index, DateTime timestamp, string deviceid, string sourceid, string devicestatus, string dataval, string previous_hash)
        {
            this.index = index;
            this.timestamp = timestamp;
            this.deviceid = deviceid;
            this.sourceid = sourceid;
            this.devicestatus = devicestatus;
            //this.data = data;
            this.dataval = dataval;
            this.previous_hash = previous_hash;
            this.hash = hashBlockSha256();
        }

        // The Blockchain uses SHA-256
        private string hashBlockSha256()
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(GetUniqueKey(16)));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        // Method for Random Strings
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        // After the Genesis Block is created, we can create more Blocks
        public static Block nextBlock(Block lastBlock, string deviceid, string sourceid, string devicestatus, string ValData)
        {
            return new Block(lastBlock.index + 1, DateTime.Now, deviceid, sourceid, devicestatus, ValData, lastBlock.hash);
        }
    }
}