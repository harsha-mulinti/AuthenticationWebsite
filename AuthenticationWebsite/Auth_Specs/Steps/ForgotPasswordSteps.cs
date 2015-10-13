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
    public sealed class ForgotPasswordSteps : ScriptHelper
    {
        public CommonActions CommonAction = new CommonActions();

        [When(@"I click on Forgot Password")]
        public void WhenIClickOnForgotPassword()
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement ForgotPassword = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.ForgotPasswordLink + "']"));

            if (ForgotPassword != null)
            {
                ForgotPassword.Click();
            }
            else
            {
                Assert.Fail("Forgot Password Link Not Found");
            }

            System.Threading.Thread.Sleep(2000);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [Then(@"I should be redirected to Forgot Password page asking for Email Address")]
        public void ThenIShouldBeRedirectedToForgotPasswordPageAskingForEmailAddress()
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement EmailField = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.LogInUserId + "']"));

            Assert.IsNotNull(EmailField);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [When(@"I enter Invalid Email ""(.*)"" and click on Next")]
        [When(@"I enter Valid Email ""(.*)"" and click on Next")]
        public void WhenIEnterInvalidEmailAndClickOnNext(string EmailAddress)
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement EmailField = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.LogInUserId + "']"));
            EmailField.Clear();
            EmailField.SendKeys(EmailAddress);

            IWebElement SubmitButton = Driver.FindElement(By.CssSelector("button[value='" + UIMAP_Repository.NextButton + "']"));
            SubmitButton.Click();
            System.Threading.Thread.Sleep(2000);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [When(@"I enter Improper Email ""(.*)""")]
        public void WhenIEnterImproperEmail(string EmailAddress)
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement EmailField = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.LogInUserId + "']"));
            EmailField.Clear();
            EmailField.SendKeys(EmailAddress);

            ScenarioContext.Current[ContextKeys.Element] = EmailField;

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [When(@"I Press Tab Key")]
        public void WhenIPressTabButton()
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            var Element = ScenarioContext.Current.Get<IWebElement>(ContextKeys.Element);

            CommonAction.PressTab(Driver, Element);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }


        [Then(@"I should get Error Message ""(.*)""")]
        public void ThenIShouldGetErrorMessage(string ErrorText)
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);
            
            if (ErrorText.ToLower().Contains("password"))
            {
                IWebElement PasswordError = Driver.FindElement(By.CssSelector("span[class='" + UIMAP_Repository.ValidationError + "']"));

                string PasswordErrorText = PasswordError.Text;
                Assert.AreEqual(PasswordErrorText, ErrorText);
                Console.WriteLine("Validation Passed");

                CommonAction.LogOut(Driver);

                Driver.Close();

            }
            else if (ErrorText.ToLower().Contains("email"))
            {
                IWebElement EmailError = Driver.FindElement(By.CssSelector("span[class='" + UIMAP_Repository.ValidationError + "']"));

                string EmailErrorText = EmailError.Text;
                Assert.AreEqual(EmailErrorText, ErrorText);
                Console.WriteLine("Validation Passed");

                CommonAction.LogOut(Driver);

                Driver.Close();

            }
            else if (ErrorText.ToLower().Contains("account"))
            {
                IWebElement EmailError = Driver.FindElement(By.CssSelector("div[class='" + UIMAP_Repository.AccountValidationError + "']"));

                string EmailErrorText = EmailError.Text;
                Assert.AreEqual(EmailErrorText, ErrorText);
                Console.WriteLine("Validation Passed");
            }
            else
            {
                Assert.Fail("Validation Failed");
            }
           

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [Then(@"I should be displayed the Alternate Email and Phone Number Details")]
        public void ThenIShouldBeDisplayedTheAlternateEmailAndPhoneNumberDetails()
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement AlternateEmail = Driver.FindElement(By.CssSelector("span[class='" + UIMAP_Repository.VerifyAlternateEmail + "']"));
            IWebElement PhoneNumber = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.MobileNumber + "']"));

            Assert.IsNotNull(AlternateEmail);
            Assert.IsNotNull(PhoneNumber);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [When(@"I click on Cancel Button")]
        public void WhenIClickOnCancelButton()
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement CancelButton = Driver.FindElement(By.CssSelector("a[class='" + UIMAP_Repository.CancelButton + "']"));
            CancelButton.Click();
            System.Threading.Thread.Sleep(2000); 
           
            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [Then(@"I should see Auth LogIn page")]
        public void ThenIShouldSeeAuthLogInPage()
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement LogInPage = Driver.FindElement(By.CssSelector("h2[class='" + UIMAP_Repository.LogInPageText + "']"));
            string LogInPageText = LogInPage.Text;

            string LogInText = "Sign in to your account";

            Assert.AreEqual(LogInPageText, LogInText);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

    }
}
