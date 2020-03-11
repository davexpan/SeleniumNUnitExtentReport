using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace SeleniumNUnitExtentNopCommerce.Tests
{
    [SetUpFixture]
    public class TestBase
    {
        public IWebDriver driver;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}