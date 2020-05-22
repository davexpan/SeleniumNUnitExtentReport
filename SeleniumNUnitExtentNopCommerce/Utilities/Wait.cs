using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumNUnitExtentNopCommerce
{
    public static class Wait
    {
        public static int SecondsTimeout = 60;

        public static IWebElement WaitForAndFindElement(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SecondsTimeout));

            return wait.Until(webDriver =>
            {
               
                if (webDriver.FindElement(by).Displayed && webDriver.FindElement(by).Enabled)
                
                {
                    return webDriver.FindElement(by);
                }
                return null; 
            });
        }
        public static IWebElement WaitForElementExists(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SecondsTimeout));

            return wait.Until(webDriver => 
            {
                return driver.FindElement(by);
            });
        }

        public static IWebElement WaitForAndFindChildElement(this IWebElement parent, By by, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SecondsTimeout));

            return wait.Until(webDriver =>
            {
                if (parent.FindElement(by).Displayed && parent.FindElement(by).Enabled)
                {
                    return parent.FindElement(by);
                }
                return null;
            });
        }

        public static void SafeClick(this IWebElement element)
        {
            try
            {
                element.Click();
            }

            catch (OpenQA.Selenium.WebDriverException)
            {
                Thread.Sleep(6000);
                element.Click();
            }
        }

        public static void WaitForElementStale (this IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SecondsTimeout));

            wait.Until(webDriver =>
            {
                try
                {
                    return element == null || !element.Enabled;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            });
        }

        public static bool IsElementDisplayed (this IWebDriver driver, IWebElement element, int waitingTime)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));

            return wait.Until(webDriver =>
            {
                if (element.Displayed)
                {
                    return true;
                }
                return false;
            });
        }

        public static bool IsElementEnabled(this IWebDriver driver, IWebElement element, int waitingTime)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));

            return wait.Until(webDriver =>
            {
                if (element.Enabled)
                {
                    return true;
                }
                return false;
            });
        }

        public static bool IsElementDisplayed(this IWebDriver driver,By by, int waitingTime)
        {
          WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));

            bool isElementDisplayed = false;
            wait.Until(webDriver =>
            {
                if (driver.FindElement(by).Displayed)
                {
                    isElementDisplayed =  true;
                    return true;
                }
                return false;
            });
            return isElementDisplayed;
        }

        public static bool IsElementDisabled(this IWebDriver driver, By by, int waitingTime)
        {
          WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));
            bool disabled = false;
            wait.Until(webDriver =>
            {
                if (driver.FindElement(by).Displayed && !driver.FindElement(by).Enabled)
                {
                    disabled = true;
                    return true;
                }
                return false;
            });
            return disabled;
        }
        public static void WaitForLoading(this IWebDriver driver)
        {
            IWebElement element = driver.WaitForElementExists(By.TagName("md-toast"));
            driver.WaitForElementStale(element);
        }

        public static int ElementsCount(this IWebDriver driver, By element)
        {
         
            var count = driver.FindElements(element).Count;

            if ( count==0 )
            {
                Thread.Sleep(1000);
                count = driver.FindElements(element).Count;
            }
            return count;
        }

        public static bool ElementExist(this IWebDriver driver, By element)
        {
            try
            {
                driver.FindElement(element);
                return true;
            } catch
            {
                return false;
            }
        }
    }
}
