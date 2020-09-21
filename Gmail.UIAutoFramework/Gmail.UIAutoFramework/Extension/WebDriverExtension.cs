using Gmail.UIAutoFramework.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmail.UIAutoFramework.Extension
{
   public static class WebDriverExtension
    {
        public static void WaitforPageLoaded(this IWebDriver driver)
        {
            driver.WaitforCondition(dri => {
                string state = dri.ExecuteJs("return document.readyState").ToString();
                return state == "complete";
            }, 20);
        }

        public static void WaitforCondition<T>(this T obj, Func<T, bool> condition, int timeout)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                };

            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds < timeout)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        internal static object ExecuteJs(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }
    }
}
