using OpenQA.Selenium;
using SeleniumNUnitExtentNopCommerce.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumNUnitExtentNopCommerce
{
    public class Page 
    {
        
        public IWebDriver Driver { get; set; }

        public GetUserCredentials GetUser { get; set; }

        public Page(IWebDriver driver, GetUserCredentials GetUser)
        {
            this.Driver = driver;
            this.GetUser = GetUser;
        }

        public LoginPage LoginPage => new LoginPage(Driver, GetUser);   
        
        
        //public MaintenancePage maintenancePage => new MaintenancePage(Driver);
       
    }
}
