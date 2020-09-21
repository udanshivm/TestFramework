using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmail.UIAutoFramework.Base
{
   public class Base
    {

        private IWebDriver _driver;

        public BasePage currentPage { get; set; }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage()
            {
                _driver = DriverContext.Driver

            };

            PageFactory.InitElements(DriverContext.Driver, pageInstance);

            return pageInstance;
        }


        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}
