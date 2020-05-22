using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SeleniumNUnitExtentNopCommerce
{
    public class BrowserSelect
    {
        public enum Type
        {
            Chrome,
            FireFox,
            IE,
            Edege,
            SeleniumGrid
        }

        public IWebDriver Create(Type browserType)
        {
            switch (browserType)
            {
                case Type.Chrome:
                    return GetChromeDriver();

                case Type.IE:
                    return GetIEDriver();

                case Type.Edege:
                    return GetEdgeDriver();

                case Type.FireFox:

                    return GetFireFoxDriver();
                
                //case Type.SeleniumGrid:
                //    return GetSeleniumGrid();
                default:
                    throw new ArgumentOutOfRangeException("Browser Not supported!");
            }
        }
        private IWebDriver GetChromeDriver()
        {

            return new ChromeDriver(); //GetDriverPath()
        }

        private IWebDriver GetIEDriver()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.RequireWindowFocus = true;
            options.EnableNativeEvents = true;
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnablePersistentHover = true;
            options.IgnoreZoomLevel = false;



            return new InternetExplorerDriver(GetDriverPath(), options);
        }

        private IWebDriver GetFireFoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.download.dir", Path);
            options.SetPreference("browser.download.manager.alertOnEXEOpen", false);
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/msword, application/csv, application/ris, text/csv, text/xlsx, image/png, application/pdf, text/html, text/plain, application/zip, application/x-zip, application/x-zip-compressed, application/download, application/octet-stream");
            options.SetPreference("browser.download.manager.showWhenStarting", false);
            options.SetPreference("browser.download.manager.focusWhenStarting", false);
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.helperApps.alwaysAsk.force", false);
            options.SetPreference("browser.download.manager.alertOnEXEOpen", false);
            options.SetPreference("browser.download.manager.closeWhenDone", true);
            options.SetPreference("browser.download.manager.showAlertOnComplete", false);
            options.SetPreference("browser.download.manager.useWindow", false);
            options.SetPreference("services.sync.prefs.sync.browser.download.manager.showWhenStarting", false);
            return new FirefoxDriver(GetDriverPath(), options);

        }

        private IWebDriver GetEdgeDriver()
        {
            //var edgeOptions = new EdgeOptions();
            ////Set Internet Explorer browser to accept the SSL Certificates by default
            //edgeOptions.AddAdditionalCapability(CapabilityType.IsJavaScriptEnabled, true);
            //edgeOptions.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true);


            return new EdgeDriver(GetDriverPath());
        }

        private string GetDriverPath()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driverPath = directory + "/../../../Drivers"; 
            //var resourcesDirectory = Path.GetFullPath(outPutDirectory);
            return driverPath;
        }

        
       //private IWebDriver GetSeleniumGrid()
       // {
       //     IoLibrary.WriteLine("Launching Browser Using Selenium Grid - Chrome Browser.");

       //     const string gridUrl = "http://y75EbcWLcnPNI0p8sZBQTcTUGj5PCOl0:LhvNjhomu4Z3Ue2d3tTMwDx3MtJe7V5I@SESYNPZ6.gridlastic.com:80/wd/hub";
       //     ChromeOptions options = new ChromeOptions();
       //     options.AddArguments("--start-maximized");
       //     options.AddArguments("--disable-extensions");
       //     DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
       //     capabilities.SetCapability(ChromeOptions.Capability, options);
       //     return Driver = new RemoteWebDriver(capabilities); 
       //     var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
       //     var driverPath = directory + "\\..\\..\\Drivers";
       //     return driverPath;

       //     else
       //     {
       //         throw new Exception(string.Format("Browser Type {0}, not Found, please add additional code for this desired WebDriver Type.", browser));
       //     }
       // }
    }
}
