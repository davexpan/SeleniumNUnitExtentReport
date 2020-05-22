using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumNUnitExtentNopCommerce
{
    public static class SeleniumHelper
    {
        public static void HoverOver(this IWebDriver driver, IWebElement elem)
        {
            Actions actions = new Actions(driver);
            IAction hoverOver = actions.MoveToElement(elem).MoveByOffset(1, 1).Build();
            hoverOver.Perform();
        }

        public static void ClearAndSendKeys(this IWebElement element, string keys)
        {
            element.Clear();
            element.SendKeys(keys);
        }
    }
}
