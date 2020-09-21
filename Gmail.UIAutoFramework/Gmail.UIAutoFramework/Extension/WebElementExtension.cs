using Gmail.UIAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmail.UIAutoFramework.Extension
{
    public static class WebElementExtension
    {

        public static string GetSelectedDropDown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        public static IList<IWebElement> GetSelectedListDropDown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        public static void Hover(this IWebElement element)
        {
            Actions action = new Actions(DriverContext.Driver);
            action.MoveToElement(element).Perform();


        }

        public static void SelectDropdown(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByValue(value);
        }

        public static void AssertElementPersent(this IWebElement element)
        {
            if (!IsElementPresnt(element))
            {
                throw new Exception(string.Format("Element not present Exception"));
            }
        }

        private static bool IsElementPresnt(IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
