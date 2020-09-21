using Gmail.UIAutoFramework.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmail.UIAutoFramework.Helper
{
    public class LogHelper
    {

        //Log file name 
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);

        private static StreamWriter _streamw = null;



        //Create a file which can store log information


        public static void CreateLogFile()
        {
            Random r = new Random();
            string dir = Setting.LogPath;

            if (Directory.Exists(dir))
            {
                _streamw = File.AppendText(dir + _logFileName + r.Next(11, 99999) + ".log");
            }

            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
        }

        //Create a method whioch cann write text in log file
        public static void Write(string logMessage)
        {
            _streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamw.WriteLine(" {0}", logMessage);
            _streamw.Flush();
        }

    }
}
