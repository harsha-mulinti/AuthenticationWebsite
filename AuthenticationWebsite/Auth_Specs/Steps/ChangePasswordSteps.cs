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
    class ChangePasswordSteps : ScriptHelper
    {
        public CommonActions CommonAction = new CommonActions();

        [When(@"I select the Change Password link on the left panel")]
        public void WhenISelectTheChangePasswordLinkOnTheLeftPanel()
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement ChangePasswordLink = Driver.FindElement(By.CssSelector("a[href*='" + UIMAP_Repository.ChangePasswordLink + "']"));
            IWebElement ChangePasswordIcon = ChangePasswordLink.FindElement(By.CssSelector("i[class='" + UIMAP_Repository.ChangePasswordIcon + "']"));

            if (ChangePasswordIcon != null)
            {
                ChangePasswordIcon.Click();

                ScenarioContext.Current[ContextKeys.Driver] = Driver;
            }
            else
            {
                Assert.Fail("Change Password Link Not Found");
            }
        }

        [When(@"I enter the old (.*)")]
        public void WhenIEnterTheOld(string password)
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement OldPasswordText = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.OldPassword + "']"));
            OldPasswordText.Clear();
            OldPasswordText.SendKeys(password);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [When(@"enter values in (.*) and (.*) as different")]
        public void WhenEnterValuesInAndAsDifferent(string NewPassword, string ConfirmPassword)
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement NewPasswordText = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.NewPassword + "']"));
            NewPasswordText.Clear();
            NewPasswordText.SendKeys(NewPassword);

            IWebElement ConfirmPasswordText = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.ConfirmPassword + "']"));
            ConfirmPasswordText.Clear();
            ConfirmPasswordText.SendKeys(ConfirmPassword);
        }

        [When(@"enter values in (.*) and (.*) as same")]
        public void WhenEnterValuesInAndAsSame(string NewPassword, string ConfirmPassword)
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement NewPasswordText = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.NewPassword + "']"));
            NewPasswordText.Clear();
            NewPasswordText.SendKeys(NewPassword);

            IWebElement ConfirmPasswordText = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.ConfirmPassword + "']"));
            ConfirmPasswordText.Clear();
            ConfirmPasswordText.SendKeys(ConfirmPassword);
        }

        [Then(@"I Should get a validation Error saying ""(.*)""")]
        public void ThenIShouldGetAValidationErrorSaying(string ErrorText)
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement ConfirmPasswordError = Driver.FindElement(By.CssSelector("span[for='" + UIMAP_Repository.ConfirmPasswordError + "']"));

            string PasswordErrorText = ConfirmPasswordError.Text;
            Assert.AreEqual(PasswordErrorText, ErrorText);

            CommonAction.LogOut(Driver);

            Driver.Close();
        }

        [Then(@"I Should get a validation Error displayed as ""(.*)""")]
        public void ThenIShouldGetAValidationErrorDisplayedAs(string ErrorText)
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement ConfirmPasswordError = Driver.FindElement(By.CssSelector("div[class='" + UIMAP_Repository.PasswordValidationError + "]"));

            string PasswordErrorText = ConfirmPasswordError.Text;
            Assert.AreEqual(PasswordErrorText, ErrorText);

            CommonAction.LogOut(Driver);

            Driver.Close();
        }

        [When(@"I revert the (.*) changes")]
        public void WhenIRevertTheChanges(string newPassword)
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement OldPasswordText = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.OldPassword + "']"));
            OldPasswordText.Clear();
            OldPasswordText.SendKeys(newPassword);

            string password = ConfigurationManager.AppSettings["Password"];

            IWebElement NewPasswordText = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.NewPassword + "']"));
            NewPasswordText.Clear();
            NewPasswordText.SendKeys(password);

            IWebElement ConfirmPasswordText = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.ConfirmPassword + "']"));
            ConfirmPasswordText.Clear();
            ConfirmPasswordText.SendKeys(password);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

    }
}
