using OpenQA.Selenium;
using Gmail.UIAutoFramework.Base;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Gmail.Tests.Pages
{
    public class GooglePage :BasePage
    {
        /// <summary>
        /// Gets or sets the the text serch box
        /// </summary>
        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement txtSearch { get; set; }

        /// <summary>
        /// Gets or sets the google search button
        /// </summary>
        [FindsBy(How = How.Name, Using = "btnK")]
        private IWebElement googleSearchButton { get; set; }


        /// <summary>
        /// Gets or sets the google img
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//img[@alt='Google']")]
        private IWebElement googleImg { get; set; }

        /// <summary>
        /// Gets or sets the the google search result
        /// </summary>
        [FindsBy(How =How.XPath,Using = "//cite[contains(text(),'www.google.com')]")]
        private IWebElement serachResult { get; set; }


        /// <summary>
        /// Gmail search 
        /// </summary>
        /// <param name="str">seasrch tearm</param>
        public void GmailSearch(string  str)
        {
            this.SearchText(str);
        }

        /// <summary>
        /// Get search result
        /// </summary>
        /// <returns> search result</returns>
        public string GetSearchResult()
        {
            Thread.Sleep(80);
            return this.serachResult.Text;
        }

        /// <summary>
        /// Perfomr search operation
        /// </summary>
        /// <param name="text">Search text</param>
        private void SearchText(string text)
        {
            txtSearch.SendKeys(text);
            txtSearch.SendKeys(Keys.Enter);
        }

    }
}
