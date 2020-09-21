using System;
using System.Drawing.Imaging;
using Gmail.Tests.Pages;
using Gmail.UIAutoFramework.Base;
using Gmail.UIAutoFramework.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Gmail.Tests
{

    /// <summary>
    /// Gmail login Test cases
    /// </summary>
    [TestClass]
    public class GmailTests : HookInitialize
    {

        /// <summary>
        /// Test Case : Verify google search result functionality
        /// Repro Steps :
        ///         1. Go the google.com
        ///         2. Enter search text gmail in textbox
        ///         3. click enter and verify result
        /// </summary>
        [TestMethod]
        public void VerifyGoogleSearchResult()
        {
            LogHelper.Write("Test case : Verify google search result functionality");
            currentPage = GetInstance<GooglePage>();
            currentPage.As<GooglePage>().GmailSearch("Gmail");
            string result = currentPage.As<GooglePage>().GetSearchResult();
            Assert.IsTrue(result.ToLower().Contains("gmail"), "Search result should match");
        }


        /// <summary>
        /// Test Case : User can login Successfully in gmail
        /// Repro Steps :
        ///         1. Go the https://www.google.com/intl/en-GB/gmail/about
        ///         2. Click on the sign in button
        ///         3. Enter the usernmae and click on next
        ///         4. Enter the password and click on next
        ///         3. User should see gmail login successfully
        /// </summary>
        [TestMethod]
        public void UserShouldLoginGmailSuccessfully()
        {
            ExcelHelper.PopulateInCollection(Environment.CurrentDirectory + "\\Data\\login.xlsx");
            DriverContext.Browser.GotoUrl("https://accounts.google.com/AccountChooser?service=mail&amp;continue=https://mail.google.com/mail/");
            LogHelper.Write(" Test cases : User should login Successfully in gmail");
            currentPage = GetInstance<GmailLoginPage>();
            currentPage.As<GmailLoginPage>().LoginGmail(ExcelHelper.ReadData(1, "Username"), ExcelHelper.ReadData(1, "Password"));
            //Verify gmail login successfully using asset
            //To:do In automation getting error while login to gmail: This browser or app may not be secure. Learn more
            //Try using a different browser.If you’re already using a supported browser, you can refresh your screen and try again to sign in.
        }


        /// <summary>
        /// Clean up the test case
        /// </summary>
        [TestCleanup]
        public void close()
        {
            TakeScreenshot();
            DriverContext.Driver.Close();
        }

        /// <summary>
        /// Take screenshot of screen
        /// </summary>
        private void TakeScreenshot()
        {
            Random r = new Random();
            ITakesScreenshot screenshotDriver = DriverContext.Driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            var screenshotName = "\\" + string.Format(r.Next(111, 9999) + "Screenshot.png");
            var curdir = Environment.CurrentDirectory;
            var filename = string.Format(Environment.CurrentDirectory + screenshotName);
            screenshot.SaveAsFile(filename, ScreenshotImageFormat.Png);
        }
    }
}
