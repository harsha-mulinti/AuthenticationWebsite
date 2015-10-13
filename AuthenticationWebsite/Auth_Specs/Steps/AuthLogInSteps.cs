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
using AuthenticationWebsite.Auth_Specs.FunctionalLibraries;

namespace AuthenticationWebsite.Auth_Specs.Steps
{
    [Binding]
    public class AuthLogInSteps : ScriptHelper
    {             
        public CommonActions CommonAction = new CommonActions();

        [Given(@"I have a valid (.*) and (.*)")]
        public void GivenIHaveAValidAnd(string userName, string password)
        {          
            InitializeWebDriver();

            CommonAction.InvokeURL(Driver);

            CommonAction.LogIn(Driver,userName,password);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [When(@"I logIn with the (.*) and (.*)")]
        public void WhenILogInWithTheAnd(string userName, string password)
        {
            CommonAction.LogIn(Driver, userName, password);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [Given(@"I have a valid Credentials")]
        public void GivenIHaveAValidCredentials()
        {
            InitializeWebDriver();

            CommonAction.InvokeURL(Driver);

            string userName = ConfigurationManager.AppSettings["UserName"];
            string password = ConfigurationManager.AppSettings["Password"];

            CommonAction.LogIn(Driver, userName, password);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [Given(@"I logged into Auth UI Site")]
        [Then(@"I should be logged into Auth UI Site successfully")]
        public void GivenILoggedIntoAuthUISite()
        {
            IWebElement AccInfoLink = Driver.FindElement(By.ClassName("" + UIMAP_Repository.AccInfoPageText + ""));

            string AccInfoText = AccInfoLink.Text;

            Assert.AreEqual(AccInfoText, "Account Information");

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [Given(@"I enter the (.*) and (.*)")]
        public void GivenIEnterTheAnd(string userName, string password)
        {
            InitializeWebDriver();

            CommonAction.InvokeURL(Driver);

            //Set User ID
            IWebElement userNameText = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.LogInUserId + "']"));
            userNameText.Clear();
            userNameText.SendKeys(userName);

            //Set Password
            IWebElement PasswordText = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.LogInPassword + "']"));
            PasswordText.Clear();
            PasswordText.SendKeys(password);
        }

        [When(@"I click on SignIn Button")]
        public void WhenIClickOnSignInButton()
        {
            //Click LogIn Button
            IWebElement sighnIn = Driver.FindElement(By.CssSelector("button[value='" + UIMAP_Repository.SignInButton + "']"));
            sighnIn.Click();
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"I should be able to see the Error message as ""(.*)""")]
        public void ThenIShouldBeAbleToSeeTheErrorMessageAs(string ErrorText)
        {
            if (ErrorText.ToLower().Contains("password"))
            {
                IWebElement LogInError = Driver.FindElement(By.CssSelector("div[class*='" + UIMAP_Repository.LogInError + "']"));
                //IWebElement LogInErrorMsg = LogInError.FindElement(By.TagName("li"));

                string LogInErrorText = LogInError.Text;
                Assert.AreEqual(LogInErrorText, ErrorText);

                Driver.Close();
            }
            else if (ErrorText.ToLower().Contains("email"))
            {
                IWebElement LogInError = Driver.FindElement(By.CssSelector("span[for='" + UIMAP_Repository.EmailError + "']"));

                string LogInErrorText = LogInError.Text;
                Assert.AreEqual(LogInErrorText, ErrorText);
            }
            else 
            {
                Assert.Fail("Validation Failed");
            }
        }

        [Given(@"I have Auth Site LogIn page in the browser")]
        public void GivenIHaveAuthSiteLogInPageInTheBrowser()
        {
            InitializeWebDriver();

            CommonAction.InvokeURL(Driver);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [When(@"I enter three times the (.*) and (.*)")]
        public void WhenIEnterThreeTimesTheAnd(string userName, string password)
        {
            for (int i = 0; i < 3; i++)
            {
                CommonAction.LogIn(Driver, userName, password);
            }
        }

        [Then(@"I should be able to see security check to enter the captcha")]
        public void ThenIShouldBeAbleToSeeSecurityCheckToEnterTheCaptcha()
        {
            IWebElement CaptchaImg = Driver.FindElement(By.CssSelector("div[id='" + UIMAP_Repository.RecaptchaImage + "']"));

            Assert.IsNotNull(CaptchaImg);

            Driver.Close();
        }

        [When(@"I Logout of the Auth Site")]
        public void WhenILogoutOfTheAuthSite()
        {
            CommonAction.LogOut(Driver);
        }

        [Then(@"I LogOut and Close the browser")]
        public void ThenILogOutAndCloseTheBrowser()
        {
            CommonAction.LogOut(Driver);

            Driver.Close();
        }

        [Then(@"I close the Browser")]
        public void ThenICloseTheBrowser()
        {
            Driver.Close();
        }

    }
}
