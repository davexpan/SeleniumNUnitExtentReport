using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Reflection;
using SeleniumNUnitExtentNopCommerce.Setups;
using OpenQA.Selenium.Chrome;

namespace SeleniumNUnitExtentNopCommerce.Tests
{
    [TestFixture]
    public class ChromeTest2: DriverExtentHook
    {
        [Test]
        public void UFOSearch()
        {

            Driver.Navigate().GoToUrl("http://www.google.com");

            Driver.Manage().Window.Maximize();
            IWebElement element = Driver.FindElement(By.Name("q"));

            //Perform Ops
            element.SendKeys("UFO");
            element.Submit();
            Assert.IsTrue(Driver.Title.Contains("Google"));
            //Assert.IsTrue(Driver.Title == "G0oogle");
        }
    }
}
