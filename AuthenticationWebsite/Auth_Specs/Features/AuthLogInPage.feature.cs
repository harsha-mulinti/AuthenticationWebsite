﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AuthenticationWebsite.Auth_Specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("AuthLogInPage", Description="As a User I want to be able to LogIn Successfully", SourceFile="Auth_Specs\\Features\\AuthLogInPage.feature", SourceLine=0)]
    public partial class AuthLogInPageFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AuthLogInPage.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AuthLogInPage", "As a User I want to be able to LogIn Successfully", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void LogInWithIncorrectPassword(string username, string incorrectPassword, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "LogIn",
                    "IncorrectPassword",
                    "Error"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("LogIn with Incorrect Password", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given(string.Format("I enter the {0} and {1}", username, incorrectPassword), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.When("I click on SignIn Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
 testRunner.Then("I should be able to see the Error message as \"Invalid email or password, please t" +
                    "ry again.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("LogIn with Incorrect Password, lnpmsapi+qatestlatest72@gmail.com", new string[] {
                "LogIn",
                "IncorrectPassword",
                "Error"}, SourceLine=12)]
        public virtual void LogInWithIncorrectPassword_LnpmsapiQatestlatest72Gmail_Com()
        {
            this.LogInWithIncorrectPassword("lnpmsapi+qatestlatest72@gmail.com", "Password", ((string[])(null)));
        }
        
        public virtual void DisplayCaptchaOnTypingIncorrectPassword(string username, string incorrectPassword, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "LogIn",
                    "Captcha"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Display Captcha on typing incorrect password", @__tags);
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given("I have Auth Site LogIn page in the browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.When(string.Format("I enter three times the {0} and {1}", username, incorrectPassword), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("I should be able to see security check to enter the captcha", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Display Captcha on typing incorrect password, lnpmsapi+qatestlatest72@gmail.com", new string[] {
                "LogIn",
                "Captcha"}, SourceLine=23)]
        public virtual void DisplayCaptchaOnTypingIncorrectPassword_LnpmsapiQatestlatest72Gmail_Com()
        {
            this.DisplayCaptchaOnTypingIncorrectPassword("lnpmsapi+qatestlatest72@gmail.com", "Password", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Invalid Email in Forgot Password", new string[] {
                "ForgotPassword",
                "InvalidEmail",
                "Error"}, SourceLine=26)]
        public virtual void InvalidEmailInForgotPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid Email in Forgot Password", new string[] {
                        "ForgotPassword",
                        "InvalidEmail",
                        "Error"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
 testRunner.Given("I have Auth Site LogIn page in the browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
 testRunner.When("I click on Forgot Password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then("I should be redirected to Forgot Password page asking for Email Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
 testRunner.When("I enter Invalid Email \"Anand@LexisNexis.com\" and click on Next", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
 testRunner.Then("I should get Error Message \"Already have an account?\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.When("I click on Cancel Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
 testRunner.Then("I should see Auth LogIn page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
 testRunner.And("I close the Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Improper Email in Forgot Password", new string[] {
                "ForgotPassword",
                "InvalidEmail",
                "Error"}, SourceLine=37)]
        public virtual void ImproperEmailInForgotPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Improper Email in Forgot Password", new string[] {
                        "ForgotPassword",
                        "InvalidEmail",
                        "Error"});
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
 testRunner.Given("I have Auth Site LogIn page in the browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.When("I click on Forgot Password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.Then("I should be redirected to Forgot Password page asking for Email Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.When("I enter Improper Email \"Anand\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.And("I Press Tab Key", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.Then("I should be able to see the Error message as \"Please enter a valid email address." +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
 testRunner.When("I click on Cancel Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.Then("I should see Auth LogIn page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
 testRunner.And("I close the Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Email and Phone validation in Forgot Password", new string[] {
                "ForgotPassword",
                "AlternateEmail",
                "PhoneNumber"}, SourceLine=49)]
        public virtual void EmailAndPhoneValidationInForgotPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Email and Phone validation in Forgot Password", new string[] {
                        "ForgotPassword",
                        "AlternateEmail",
                        "PhoneNumber"});
#line 50
this.ScenarioSetup(scenarioInfo);
#line 51
 testRunner.Given("I have Auth Site LogIn page in the browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
 testRunner.When("I click on Forgot Password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
 testRunner.Then("I should be redirected to Forgot Password page asking for Email Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
 testRunner.When("I enter Valid Email \"lnpmsapi+qatestlatest72@gmail.com\" and click on Next", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
 testRunner.Then("I should be displayed the Alternate Email and Phone Number Details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.When("I click on Cancel Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
 testRunner.Then("I should see Auth LogIn page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
 testRunner.And("I close the Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
