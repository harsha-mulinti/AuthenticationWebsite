using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace AuthenticationWebsite.Auth_Specs.SupportLibraries
{
    /// <summary>
    /// Wrapper class for common framework objects, to be used across the entire test case and dependent libraries
    /// </summary>
    public class ScriptHelper
    {
        public IWebDriver Driver;
        //public IWebDriver Driver { get; set; }

        public void InitializeWebDriver()
        {
       
            Driver = new ChromeDriver("C:\\Driver");
           // Driver = new InternetExplorerDriver("C:\\Driver");
            //Driver = new FirefoxDriver();
        }
		
    }
}
