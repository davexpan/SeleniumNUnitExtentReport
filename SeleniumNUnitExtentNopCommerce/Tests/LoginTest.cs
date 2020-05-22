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
    public class LoginTest : DriverExtentHook
    {
        [Test]
        [Category("Smoke")]
        public void LoginUserTest()
        {
            AllPages.LoginPage.GoToLoginPage(HomePage);
            AllPages.LoginPage.UserLogin();
            Assert.True(AllPages.LoginPage.IsAtHomePageDisplayed().Equals("My account - My Store"));
            //  AxeResult results = Driver.Analyze();
        }



        [Test]
        public void FirefoxTest()
        {

            //FirefoxOptions options = new FirefoxOptions();
            //var profile = new FirefoxProfile();
            //var binary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
            //driver = new FirefoxDriver(binary, profile); test gitea

            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var pathDrivers = directory + "\\..\\..\\Drivers";

            Driver = new FirefoxDriver(pathDrivers);
            Driver.Navigate().GoToUrl("http://www.mozilla.org/");
            Driver.Manage().Window.Maximize();
            Assert.IsTrue(Driver.Title == "Internet for people, not profit — Mozilla");
        }
        [Test]
        public void ChromeTest()
        {


            Driver.Navigate().GoToUrl("http://www.google.com");

            Driver.Manage().Window.Maximize();

            Assert.IsTrue(Driver.Title.Contains("Google"));
            Assert.IsTrue(Driver.Title == "G0oogle");
        }
    }
}
