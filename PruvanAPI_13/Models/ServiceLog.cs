using System;
using System.IO;

namespace PruvanAPI_13.Models
{
    public class ServiceLog
    {
        public bool WriteToLog(string[] msg)
        {
            try
            {
                string dir = @"C:\Temp\pruvanapi\";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string fileName = dir + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";
                if (!File.Exists(fileName))
                {
                    var myFile = File.Create(fileName);
                    myFile.Close();
                    myFile.Dispose();
                }

                File.AppendAllLines(fileName, msg);

                return true;
            }
            catch { return false; }
        }
    }
}
