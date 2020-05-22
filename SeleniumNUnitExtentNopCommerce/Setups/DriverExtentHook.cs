using AventStack.ExtentReports;
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
        protected ExtentReports _extent;
        protected ExtentTest _test;
        public IWebDriver Driver;
        public Page AllPages { get; set; }
        //public DataBaseHelper DbHelper { get; set; }
        public GetUserCredentials GetUser { get; set; }
        public BrowserSelect Browser { get; set; }
        public ApplicationSettings EnvSettings { get; set; }
        public string HomePage { get; set; }
        public CommonHelpers CommonHelpers { get; set; }

        [OneTimeSetUp]
        protected void Setup()
        {
            Browser = new BrowserSelect();
            //DbHelper = new DataBaseHelper();
            Driver = Browser.Create(BrowserSelect.Type.Chrome);
            Driver.Manage().Window.Maximize();
            EnvSettings = GetAppSettings();
            GetUser = GetUserCred();
            HomePage = EnvSettings.HomePage;
            AllPages = new Page(Driver, GetUser);
            CommonHelpers = new CommonHelpers();

            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);

            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);

            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "TestUser");
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public GetUserCredentials GetUserCred()
        {
            GetUser = new GetUserCredentials()
            {
                Email = EnvSettings.Email,
                Password = EnvSettings.Password,
                NewPassword = "",
                DataBase = EnvSettings.ClientID,
            };

            return GetUser;
        }

        public ApplicationSettings GetAppSettings()
        {
            var AppSettings = new ApplicationSettings
            {
                HomePage = TestContext.Parameters["Environment"].ToString(),
                Email = TestContext.Parameters["Email"].ToString(),
                Password = TestContext.Parameters["Password"].ToString()

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

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + time.ToString("hh_mm_ss") + ".png";
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

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
            Driver.Quit();
        }

        // public IWebDriver GetDriver()
        // {
        //     return Driver;
        // }

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

        //[TearDown]
        //public void TearDownTest()
        //{
        //    if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        //    {
        //        string datestamp = DateTime.Now.ToString("yyyy-MM-dd");
        //        string timestamp = DateTime.Now.ToString("_hh_mm_ss");

        //        // Create directory if it doesn't exist
        //        Directory.CreateDirectory("C:\\ScreenShots");

        //        Directory.CreateDirectory($"C:\\ScreenShots\\{datestamp}");
        //        // Take screenshot
        //        var screenshot = Driver.TakeScreenshot();

        //        // Define path for files to be saved
        //        var filePath = $"C:\\ScreenShots\\{datestamp}\\" +
        //            $"{TestContext.CurrentContext.Test.Name}" + $"{timestamp}";

        //        // Build error log file 
        //        string errorLog = $"Test Name: {TestContext.CurrentContext.Test.Name}\r\n\r\n" +
        //            $"Error Message: {TestContext.CurrentContext.Result.Message}\r\n\r\n" +
        //            $"Stack Trace: {TestContext.CurrentContext.Result.StackTrace}";


        //        screenshot.SaveAsFile(filePath + ".png", ScreenshotImageFormat.Png);
        //        File.WriteAllText(filePath + ".txt", errorLog);
        //    }
        //}

        [OneTimeTearDown]
        protected void TearDown()
        {
            _extent.Flush();
        }
    }
}