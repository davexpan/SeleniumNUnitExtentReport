using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumNUnitExtentNopCommerce
{
    public class BasePage
    {

        protected IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }
    }
}
