﻿using OpenQA.Selenium;
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
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace SeleniumNUnitExtentNopCommerce
{
    public class BrowserSelect
    {

        public enum BrowserType
        {
            Chrome,
            FireFox,
            IE,
            Edege,
            SeleniumGrid
        }
        private BrowserType _browserType;
        public BrowserType PassInBrowser(string Browsertype)
        {

            return _browserType = (BrowserType)Enum.Parse(typeof(BrowserType), Browsertype);

        }
        public IWebDriver Create(BrowserType browserType)
        {

            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();

                case BrowserType.IE:
                    return GetIEDriver();

                case BrowserType.Edege:
                    return GetEdgeDriver();

                case BrowserType.FireFox:

                    return GetFireFoxDriver();

                default:
                    throw new ArgumentOutOfRangeException("Browser Not supported!");
            }
        }
        private IWebDriver GetChromeDriver()
        {

            return new ChromeDriver(GetDriverPath()); //GetDriverPath()
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
            return new EdgeDriver(GetDriverPath());
        }

        private string GetDriverPath()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driverPath = directory + "\\..\\..\\Drivers";
            //var resourcesDirectory = Path.GetFullPath(outPutDirectory);
            return driverPath;
        }
    }
}
