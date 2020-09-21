using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Gmail.UIAutoFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {

            XPathItem aut;
            XPathItem testtype;
            XPathItem islog;
            XPathItem isreport;
            XPathItem buildname;
            XPathItem logPath;

            string strFilename = Environment.CurrentDirectory.ToString() + "\\Config\\GlobalConfig.xml";
            FileStream stream = new FileStream(strFilename, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            //Get XML Details and pass it in XPathItem type variables
            aut = navigator.SelectSingleNode("EAAutoFramework/RunSettings/AUT");
            buildname = navigator.SelectSingleNode("EAAutoFramework/RunSettings/BuildName");
            testtype = navigator.SelectSingleNode("EAAutoFramework/RunSettings/TestType");
            islog = navigator.SelectSingleNode("EAAutoFramework/RunSettings/IsLog");
            isreport = navigator.SelectSingleNode("EAAutoFramework/RunSettings/IsReport");
            logPath = navigator.SelectSingleNode("EAAutoFramework/RunSettings/LogPath");

            //Set XML Details in the property to be used accross framework
            Setting.AUT = aut.Value.ToString();
            Setting.BuildName = buildname.Value.ToString();
            Setting.TestType = testtype.Value.ToString();
            Setting.IsLog = islog.Value.ToString();
            Setting.IsReporting = isreport.Value.ToString();
            Setting.LogPath = logPath.Value.ToString();

        }
    }
}
