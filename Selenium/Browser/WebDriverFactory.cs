using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;

namespace Selenium.Browser
{
    public class WebDriverFactory
    {
        IWebDriver driver;
        public IWebDriver InitializeDriver(string browser,string Url)
        {           

            switch (browser.ToLower())
            {
                case "chrome":
                    {
                        ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--disable-infobars");
                        options.AddArguments("--disable-extensions");
                        driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(120));
                        break;
                    }                    

                case "ie":
                    {
                        InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService();
                        InternetExplorerOptions options = new InternetExplorerOptions();
                        driver = new InternetExplorerDriver(service, options, TimeSpan.FromSeconds(120));
                        driver.Manage().Window.Maximize();
                        break;
                    }

                default:
                    throw new ArgumentException($"Browser Option {browser} Is Not Valid - Use Chrome, Firefox or IE Instead");
            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Url);
            return driver;
        }

        public void Close()
        {
            if (driver != null)
                driver.Quit();
        }
    }
}
