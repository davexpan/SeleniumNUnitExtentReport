// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.IO;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;


namespace SeleniumNUnitExtentNopCommerce
{
    [TestFixture]
    public class TestClass
    
    {
        //private static IWebDriver _chrome;
        //private static IWebDriver _edge;
        private static IWebDriver _firefox;

        [SetUp]
        public void SetUp()
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var pathDrivers = directory + "\\..\\..\\Drivers";

            //_chrome = new ChromeDriver(pathDrivers);
            //_edge = new EdgeDriver(pathDrivers);
            _firefox = new FirefoxDriver(pathDrivers);
        }

        [Test]
        public void FireFoxTest()
        {

            //_chrome.Navigate().GoToUrl("https://google.com/");
            //_edge.Navigate().GoToUrl("https://www.microsoft.com/");
            _firefox.Navigate().GoToUrl("http://www.mozilla.org/");
            _firefox.Manage().Window.Maximize();
            Thread.Sleep(5000);
        }

        [TearDown]
        public void Cleanup()
        {
            //_edge?.Dispose();
            //_chrome?.Dispose();
            _firefox?.Dispose();
        }
    }
}
