using Gmail.UIAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gmail.Tests.Pages
{
    public class GmailLoginPage : BasePage
    {

        /// <summary>
        /// Gets or sets the emailTextBox
        /// </summary>
        [FindsBy(How = How.Id, Using = "identifierId")]
        private IWebElement emailTextBox { get; set; }

        /// <summary>
        /// Gets or sets the password textbox
        /// </summary>
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordTextBox { get; set; }

        /// <summary>
        /// Gets or sets the nextbutton
        /// </summary>
        [FindsBy(How = How.Id, Using = "identifierNext")]
        private IWebElement NextButton { get; set; }


        /// <summary>
        /// Login to the gmail
        /// </summary>
        /// <param name="uname"> Gmail username</param>
        /// <param name="pass">Gmail password</param>
        public void LoginGmail(string uname,string pass)
        {
            EnterUsername(uname);
            clickNextButton();
            EnterPassword(pass);
            clickNextButton();
        }


        private void EnterUsername(string uname)
        {
            emailTextBox.SendKeys(uname);
        }

        private void EnterPassword(string pass)
        {
            this.passwordTextBox.SendKeys(pass);
        }

        private void clickNextButton()
        {
            this.NextButton.Click();
        }

    }
}
