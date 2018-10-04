using NUnit.Framework;
using Selenium;
using Selenium.Browser;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using n = OpenQA.Selenium.Interactions;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace Automation.TestCases
{
    [TestFixture]
    public class DemoTest : BaseTest
    {
        
        [Test]
        public void Test_XXX()
        {
            driver = (new WebDriverFactory()).InitializeDriver("chrome", "http://demo.automationtesting.in/WebTable.html");

            string cXpath = $"//div[@class='ui-grid-header ng-scope']//div[@col='col']";
            string rXpath = $"//div[@class='ui-grid-canvas']/div";

            var cols = Finds(By.XPath(cXpath));
            for(int i=0;i<=cols.Count;i++)
            {
                var rows = Finds(By.XPath($"//div[@class='ui-grid-canvas']/div[{i+1}]//div[@role='gridcell']")).ToList();
                for(int j=0;j<rows.Count;j++)
                {
                    if(rows[j].Text== "gjsfhkqW")
                    {
                       var a = Find(By.XPath($"//div[@class='ui-grid-canvas']/div[{i+1}]//div[@role='gridcell'][6]"));
                       var ele = a.FindElement(By.TagName("button"));
                        var act = new Actions(driver);
                        act.MoveToElement(ele).DoubleClick().Click().Build().Perform();
                        break;
                    
                    }
                }

            }

        }

        private IWebElement Find(By by)
        {
            return driver.FindElement(by);
        }
        private IReadOnlyCollection<IWebElement> Finds(By by)
        {
           return driver.FindElements(by);
        }
    }
}
