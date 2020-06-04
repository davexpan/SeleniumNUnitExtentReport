using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleniumNUnitExtentNopCommerce.Pages
{
    public class ComputersPage : BasePage
    {
        //private IWebDriver Driver;
        public ComputersPage(IWebDriver driver) : base(driver) { }
        public IWebElement ComputerTopMenu => Driver.WaitForAndFindElement(By.XPath("//ul[@class='top-menu notmobile']//a[contains(text(),'Computers')]"));
        public IWebElement NotebookMenu => Driver.WaitForAndFindElement(By.XPath("//ul[@class='top-menu notmobile']//a[contains(text(),'Notebooks')]"));
        public IWebElement MacBook => Driver.WaitForAndFindElement(By.XPath("//h2/a[contains(text(),'Apple MacBook Pro 13-inch')]"));
        public IWebElement AddToCartbtn => Driver.WaitForAndFindElement(By.XPath("//input[@id='add-to-cart-button-4']"));
        public IWebElement QuantityInput => Driver.WaitForAndFindElement(By.XPath("//input[@id='product_enteredQuantity_4']"));
        public IWebElement ShoppingCartbtn => Driver.WaitForAndFindElement(By.XPath("//span[@class='cart-label']"));
        public IWebElement ProductName => Driver.WaitForAndFindElement(By.XPath("//a[@class='product-name']"));

        public string OrderNotebook()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            Actions action = new Actions(Driver);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//ul[@class='top-menu notmobile']//a[contains(text(),'Computers')]")));
            action.MoveToElement(Driver.FindElement(By.XPath("//ul[@class='top-menu notmobile']//a[contains(text(),'Computers')]"))).Build().Perform();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//ul[@class='top-menu notmobile']//a[contains(text(),'Notebooks')]")));
            NotebookMenu.SafeClick();
            //((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);",  MacBook);
            //((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 350)");
            MacBook.SafeClick();
            AddToCartbtn.SafeClick();
            ShoppingCartbtn.SafeClick();
            return ProductName.Text;
        }
       

    }
}
