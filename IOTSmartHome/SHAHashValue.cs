using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections.ObjectModel;
using Sha2;

namespace IOTSmartHome
{
    public class SHAHashValue
    {
        public static string ShaKeyGeneration(string DId, string DVal, string DTime)
        {
            try
            {
                string data = DId + "," + DVal + "," + DTime;
                string strFilePath = HttpContext.Current.Server.MapPath("data.txt");
                if (File.Exists(strFilePath))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(strFilePath);
                }
                FileStream fp = new FileStream(strFilePath, FileMode.Create);
                StreamWriter wr = new StreamWriter(fp);
                wr.WriteLine(data);
                wr.Close();
                fp.Close();

                ReadOnlyCollection<byte> hash = Sha384mManaged.HashFile(File.OpenRead(strFilePath));

                return Util.ArrayToString(hash);
            }
            catch
            {
                return null;
            }
        }
        
    }
}