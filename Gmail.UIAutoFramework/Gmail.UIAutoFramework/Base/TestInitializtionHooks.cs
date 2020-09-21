using Gmail.UIAutoFramework.Config;
using Gmail.UIAutoFramework.Helper;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmail.UIAutoFramework.Base
{
    public class TestInitializtionHooks:Base
    {

        public readonly BrowserType Browser;


        public TestInitializtionHooks(BrowserType browser)
        {
            this.Browser = browser;
        }

        public void InitializeSetting()
        {
            //Set all the setting for framwrok
            ConfigReader.SetFrameworkSettings();

            //Set log 
            LogHelper.CreateLogFile();

            //Open the browser
            OpenBrowser(Browser);

            LogHelper.Write("Initalize the framework");

        }

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GotoUrl(Setting.AUT);
            LogHelper.Write("Opened the browser");
        }

        private void OpenBrowser(BrowserType browserType = BrowserType.FireFox)
        {
            switch (browserType)
            {
                case BrowserType.InternetExploere:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.FireFox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    DriverContext.Driver.Manage().Window.Maximize();
                    break;
            }
        }

    }
}
