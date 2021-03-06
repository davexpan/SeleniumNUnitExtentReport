﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;

namespace SeleniumNUnitExtentNopCommerce.Setups
{
    [SetUpFixture]

    public abstract class DriverExtentHook
    {
        protected static ExtentReports _extent = new ExtentReports();
        protected static ExtentHtmlReporter htmlReporter;
        protected static ExtentTest _test;
        public IWebDriver Driver;
        public Page InitPages { get; set; }
        //public DataBaseHelper DbHelper { get; set; }
        public GetUserCredentials GetUser { get; set; }
        public BrowserSelect Browser { get; set; }
        public ApplicationSettings EnvSettings { get; set; }
        public string HomePage { get; set; }
        public CommonHelpers CommonHelpers { get; set; }

        [OneTimeSetUp]
        protected void Setup()
        {
            EnvSettings = GetAppSettings();
            GetUser = GetUserCred();
            Browser = new BrowserSelect();
            var browser = EnvSettings.Browsertype;
            //var browser = TestContext.Parameters.Get("Browser", "firefox");
            Driver = Browser.Create(Browser.PassInBrowser(browser));
            Driver.Manage().Window.Maximize();

            HomePage = EnvSettings.HomePage;
            InitPages = new Page(Driver, GetUser);
            CommonHelpers = new CommonHelpers();
            InitPages.LoginPage.GoToLoginPage(HomePage);
            InitPages.LoginPage.UserLogin();
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\";
            string dir = TestContext.CurrentContext.TestDirectory + "\\";
            string fileName = browser.ToString() + "_ExtentTestReports.html"; // this.GetType().ToString() +
            var htmlReporter = new ExtentHtmlReporter(reportPath + fileName);

            _extent.AttachReporter(htmlReporter);

            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "David Pan");
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public GetUserCredentials GetUserCred()
        {
            GetUser = new GetUserCredentials()
            {
                Email = EnvSettings.Email,
                Password = EnvSettings.Password,

            };

            return GetUser;
        }

        public ApplicationSettings GetAppSettings()
        {
            var AppSettings = new ApplicationSettings
            {
                HomePage = TestContext.Parameters["Environment"].ToString(),
                Email = TestContext.Parameters["Email"].ToString(),
                Password = TestContext.Parameters["Password"].ToString(),
                Browsertype = TestContext.Parameters["Browsertype"].ToString()
            };
            return AppSettings;
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            string testMethodName = TestContext.CurrentContext.Test.Name;
            //var fileName = this.GetType().ToString();  //get class name?

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;

                    String fileName = testMethodName + time.ToString("_hh_mm_ss") + ".png";
                    String screenShotPath = Capture(Driver, fileName);
                    _test.Log(Status.Fail, "Fail");
                    _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, testMethodName + " " + logstatus + stacktrace);
            _extent.Flush();
        }


        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            string testMethodName = TestContext.CurrentContext.Test.Name;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }



        [OneTimeTearDown]
        protected void TearDown()
        {
            _extent.Flush();
            Driver.Dispose();  // Quit();
        }
    }
}