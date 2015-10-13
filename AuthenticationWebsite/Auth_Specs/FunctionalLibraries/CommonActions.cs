using System;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuthenticationWebsite.Auth_Specs.UIMAP;
using AuthenticationWebsite.Auth_Specs.SupportLibraries;

namespace AuthenticationWebsite.Auth_Specs.FunctionalLibraries
{
    /// <summary>
    /// This FIle Contains the Commonly used Functions which can be used across the different tests
    /// </summary>
    public class CommonActions
    {           
        /// <summary>
        /// Function to Inoke the Application URL
        /// </summary>
        /// <param name="Driver"></param>
        public void InvokeURL(IWebDriver Driver)
        {
            Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 5));
            Driver.Url = ConfigurationManager.AppSettings["AuthDevUrl"];

            Driver.Navigate().GoToUrl(Driver.Url);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 5));

        }

        /// <summary>
        /// Function to LogIN to the application
        /// </summary>
        /// <param name="Driver"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void LogIn(IWebDriver Driver, string userName, string password)
        {
            //Set User ID
            IWebElement userNameText = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.LogInUserId + "']"));
            userNameText.Clear();
            userNameText.SendKeys(userName);
            WaitTime(1000);

            //Set Password
            IWebElement PasswordText = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.LogInPassword + "']"));
            PasswordText.Clear();
            PasswordText.SendKeys(password);
            WaitTime(1000);

            //Click LogIn Button
            IWebElement signIn = Driver.FindElement(By.CssSelector("button[value='" + UIMAP_Repository.SignInButton + "']"));
            signIn.Click();
            System.Threading.Thread.Sleep(2000);

        }

        /// <summary>
        /// Function to LogOut from the Application
        /// </summary>
        /// <param name="Driver"></param>
        public void LogOut(IWebDriver Driver)
        {
            IWebElement AccDropdown = Driver.FindElement((By.CssSelector("span[class='" + UIMAP_Repository.AccountDropdown + "']")));
            AccDropdown.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement DropdownMenu = Driver.FindElement((By.CssSelector("ul[class='" + UIMAP_Repository.AccDropdownMenu + "']")));
            IList<IWebElement> LogOut = DropdownMenu.FindElements(By.TagName("li"));
            if (LogOut != null)
            {
                LogOut[1].Click();
                System.Threading.Thread.Sleep(1000);
            }
            else 
            {
                Assert.Fail("LogOut Button is Not Displayed");
            }

            IWebElement LogInPage = Driver.FindElement((By.CssSelector("h2[class='" + UIMAP_Repository.LogInPageText + "']")));
            string LogInText = LogInPage.Text;
            Assert.AreEqual(LogInText, "Sign in to your account");
         }

        /// <summary>
        /// Function to Click on Submit Button
        /// </summary>
        /// <param name="Driver"></param>
        public void ClickSubmit(IWebDriver Driver)
        {
            WaitTime(1000);

            //Click Submit Button
            IWebElement SubmitButton = Driver.FindElement((By.CssSelector("button[value='" + UIMAP_Repository.SubmitButton + "']")));
            SubmitButton.Click();
            WaitTime(1000);

        }

        /// <summary>
        /// Function to Press Tab Key
        /// </summary>
        /// <param name="Driver"></param>
        public void PressTab(IWebDriver Driver,IWebElement Element)
        {
            WaitTime(1000);

            //Click Tab Key
            Element.SendKeys(Keys.Tab);
            WaitTime(1000);

        }
        
        /// <summary>
        /// Function to Verify the Success Message displayed in Application
        /// </summary>
        /// <param name="Driver"></param>
        /// <param name="MessageText"></param>
        public void SucessMessage(IWebDriver Driver,string MessageText)
        {
            IWebElement SucessMessage = Driver.FindElement((By.CssSelector("div[class='" + UIMAP_Repository.SuccessMessage + "']")));

            string SucessMessageText = SucessMessage.Text;
            Assert.AreEqual(SucessMessageText, MessageText);
            System.Threading.Thread.Sleep(7000);

        }

        public void WaitTime(int Time)
        {
            System.Threading.Thread.Sleep(Time);
        
        }

    }
}
