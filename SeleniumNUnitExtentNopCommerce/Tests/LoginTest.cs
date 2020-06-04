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
            //InitPages.LoginPage.GoToLoginPage(HomePage);
            //InitPages.LoginPage.UserLogin();
            Assert.True(InitPages.LoginPage.IsAtHomePageDisplayed().Equals("Your store"));
            
        }

       
    }
}
