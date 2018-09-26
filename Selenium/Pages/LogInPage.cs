using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Pages
{
    public class LogInPage : BasePage
    {
        private RemoteWebDriver _driver;
        public LogInPage(IWebDriver driver) : base(driver)
        {

        }

        private IWebElement UserName => _driver.FindElementByName(""); 
    }
}
