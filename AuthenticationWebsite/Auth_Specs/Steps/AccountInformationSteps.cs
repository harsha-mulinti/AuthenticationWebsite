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
    class AccountInformationSteps : ScriptHelper
    {
        public CommonActions CommonAction = new CommonActions();

        [When(@"I select the Account Information link on the left panel")]
        public void WhenISelectTheAccountInformationLinkOnTheLeftPanel()
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            IWebElement AccInfoLink = Driver.FindElement(By.CssSelector("a[href='" + UIMAP_Repository.AccInfoLink + "']"));
            IWebElement AccInfoIcon = AccInfoLink.FindElement(By.CssSelector("span[class='" + UIMAP_Repository.AccInfoIcon + "']"));

            if (AccInfoLink != null)
            {
                AccInfoIcon.Click();
                
                ScenarioContext.Current[ContextKeys.Driver] = Driver;
            }
            else
            {
                Assert.Fail("Account Information Link Not Found");
            }

        }

        [Then(@"I should be able to see the account information username with values")]
        public void ThenIShouldBeAbleToSeeTheAccountInformationWithValues()
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            string userName = ConfigurationManager.AppSettings["UserName"];

            CommonAction.WaitTime(2000);

            IWebElement AccInfoEmail = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.EmailAddress + "']"));
            string AccInfoText = AccInfoEmail.GetAttribute("value");
            Assert.AreEqual(AccInfoText.ToLower(), userName.ToLower());

            CommonAction.LogOut(Driver);

            Driver.Close();

        }
        
        [When(@"I clear Alternate email field on Account Information Page")]
        public void WhenIClearAlternateEmailFieldOnAccountInformationPage()
        {
           var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            CommonAction.WaitTime(2000);

           IWebElement AlternateEmailText = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.AlternateEmail + "']"));
           AlternateEmailText.Clear();

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [When(@"I clear Phone Number field on Account Information Page")]
        public void WhenIClearPhoneNumberFieldOnAccountInformationPage()
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            CommonAction.WaitTime(2000);

            IWebElement PhoneNumber = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.MobileNumber + "']"));
            PhoneNumber.Clear();

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [When(@"click on save button")]
        public void WhenClickOnSaveButton()
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            CommonAction.ClickSubmit(Driver);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [Then(@"I Should get a validation saying ""(.*)""")]
        public void ThenIShouldGetAValidationSaying(string ErrorText)
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            if (ErrorText.ToLower().Contains("email"))
            {
                IWebElement AltEmailError = Driver.FindElement(By.CssSelector("span[for='" + UIMAP_Repository.AlternateEmailError + "']"));

                string AltEmailErrorText = AltEmailError.Text;
                Assert.AreEqual(AltEmailErrorText, ErrorText);
                Console.WriteLine("Validation Passed");
            }
            else if (ErrorText.ToLower().Contains("phone"))
            {
                IList<IWebElement> PhoneNumber = Driver.FindElements(By.CssSelector("span[class='" + UIMAP_Repository.ValidationError + "']"));

                string PhoneNumberErrorText = null;

                foreach (IWebElement Element in PhoneNumber)
                {
                    if (Element.GetAttribute("data-valmsg-for").Equals("MobilePhoneNumber"))
                    {
                        PhoneNumberErrorText = Element.Text;
                    }
                }

                Assert.AreEqual(PhoneNumberErrorText, ErrorText);
                Console.WriteLine("Validation Passed");

                CommonAction.LogOut(Driver);

                Driver.Close();
            }
            else if (ErrorText.ToLower().Contains("password"))
            {
                IWebElement PasswordError = Driver.FindElement(By.CssSelector("span[for='" + UIMAP_Repository.NewPasswordError + "']"));

                string PasswordErrorText = PasswordError.Text;
                Assert.AreEqual(PasswordErrorText, ErrorText);
                Console.WriteLine("Validation Passed");

                CommonAction.LogOut(Driver);

                Driver.Close();
            }
            else
            {
                Assert.Fail("Validation Failed");
            }
        }

        [When(@"I enter Alternate email value as ""(.*)""")]
        public void WhenIEnterAlternateEmailValueAs(string AlternateEmailText)
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            CommonAction.WaitTime(2000);

            IWebElement AlternateEmail = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.AlternateEmail + "']"));
            AlternateEmail.Clear();
            AlternateEmail.SendKeys(AlternateEmailText);

            ScenarioContext.Current[ContextKeys.Element] = AlternateEmail;

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [When(@"I enter Alternate email value same as LogIn Email")]
        public void WhenIEnterAlternateEmailValueSameAsLogInEmail()
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            string LogInEmail = ConfigurationManager.AppSettings["UserName"];

            CommonAction.WaitTime(2000);

            IWebElement AlternateEmail = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.AlternateEmail + "']"));
            AlternateEmail.Clear();
            AlternateEmail.SendKeys(LogInEmail);

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [When(@"I enter Mobile Phone value as ""(.*)""")]
        public void WhenIEnterMobilePhoneValueAs(string PhoneNmber)
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            CommonAction.WaitTime(2000);

            IWebElement PhoneNumber = Driver.FindElement(By.CssSelector("input[id='" + UIMAP_Repository.MobileNumber + "']"));
            PhoneNumber.Clear();
            PhoneNumber.SendKeys(PhoneNmber);

            ScenarioContext.Current[ContextKeys.Element] = PhoneNumber;

            ScenarioContext.Current[ContextKeys.Driver] = Driver;
        }

        [Then(@"I Should get a Message saying ""(.*)""")]
        public void ThenIShouldGetAMessageSaying(string MessageText)
        {
            var Driver = ScenarioContext.Current.Get<IWebDriver>(ContextKeys.Driver);

            CommonAction.SucessMessage(Driver, MessageText);
        }

    }
}
