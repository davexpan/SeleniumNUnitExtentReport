using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using SeleniumNUnitExtentNopCommerce.Setups;

namespace SeleniumNUnitExtentNopCommerce.Tests
{
    [TestFixture]
    public class ExtentTestReports : DriverExtentHook
    {
        [Test]
        public void ExtentTestCase()
        {
            var htmlReporter = new ExtentHtmlReporter("extentReport.html");
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("OS", "Windows 10");
            extent.AddSystemInfo("Browser", "Chrome");

            var test = extent.CreateTest("ExtentTestCase");
            test.Log(Status.Info, "Step 1: Test case starts");
            test.Log(Status.Pass, "Step 2: Test case Pass");
            test.Log(Status.Fail, "Step 3: Test case Failed");

            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
            test.Pass("Screenshot").AddScreenCaptureFromPath("screenshot.png");

            extent.Flush();

        }
    }
}
