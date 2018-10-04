﻿using System.IO;
using Automation.Paramters;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Automation
{
    [TestFixture]
    public class BaseTest
    {
        public IWebDriver driver;
        private TestDriver _testDriver;
        private static TestContext TestContext { get; set; }        

        public TestDriver TestDriver
        {
            get
            {
                return _testDriver;
            }            
        }

        [SetUp]
        public void Initialize()
        {
            TestContext = TestContext.CurrentContext;
            TestDriver.Initialize(TestContext);
            (new Parameter()).CollectParamter();
        }

        [TearDown]
        public void CleanUp()
        {
            _testDriver = null;
            driver.Quit();

        }

    }

}
