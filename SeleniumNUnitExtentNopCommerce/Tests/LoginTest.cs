using NUnit.Framework;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Reflection;
using SeleniumNUnitExtentNopCommerce.Setups;
using OpenQA.Selenium.Chrome;

namespace SeleniumNUnitExtentNopCommerce.Tests
{
    [TestFixture]
    public class LoginTest:ExtentReporting
    {
        [Test]
        public void FirefoxTest()
        {
           
            

                //FirefoxOptions options = new FirefoxOptions();
                //var profile = new FirefoxProfile();
                //var binary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
                //driver = new FirefoxDriver(binary, profile); test gitea



                var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var pathDrivers = directory + "\\..\\..\\Drivers";

                driver = new FirefoxDriver(pathDrivers);
                driver.Navigate().GoToUrl("http://www.mozilla.org/");
                driver.Manage().Window.Maximize();
            }
        [Test]
        public void ChromeTest()
        {



            //FirefoxOptions options = new FirefoxOptions();
            //var profile = new FirefoxProfile();
            //var binary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
            //driver = new FirefoxDriver(binary, profile);



            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var pathDrivers = directory + "\\..\\..\\Drivers";

            driver = new ChromeDriver(pathDrivers);





            driver.Navigate().GoToUrl("http://www");
           
            driver.Manage().Window.Maximize();

            Assert.AreEqual(3, 4);
        }
    }
}
