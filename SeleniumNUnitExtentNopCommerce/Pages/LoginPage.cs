using OpenQA.Selenium;
using SeleniumNUnitExtentNopCommerce.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumNUnitExtentNopCommerce.Pages
{
    public class LoginPage : BasePage
    {
        public GetUserCredentials GetUser { get; set; }

        public LoginPage(IWebDriver driver, GetUserCredentials GetUser) : base(driver)
        {
            this.GetUser = GetUser;
        }

        public IWebElement LogInBtnatHome => Driver.WaitForAndFindElement(By.XPath("//li/a[contains(., 'Log in')]"));
        public IWebElement EmailId => Driver.WaitForAndFindElement(By.Id("Email"));

        public IWebElement Password => Driver.WaitForAndFindElement(By.Id("Password"));

        public IWebElement LogInBtn => Driver.WaitForAndFindElement(By.XPath("//input[@value='Log in']"));

       
        public string PageTitle => Driver.Title;

        public IWebElement HavingTrubleSignInLink => Driver.WaitForAndFindElement(By.LinkText("Having trouble signing in?"));

        public IWebElement TryAgainButton => Driver.WaitForAndFindElement(By.XPath("//Button[@ng-click='hide()']"));

        public IWebElement ErrorMessage => Driver.WaitForAndFindElement(By.XPath("//md-content[@class ='error-dialog fontErrorMessage _md']"));

        public IWebElement LoginHelpAndSupport => Driver.WaitForAndFindElement(By.XPath("//*[@id='login-footer']/a"));

        public IWebElement HelpIcon => Driver.WaitForAndFindElement(By.Id("btnUserHelp"));

        public IWebElement Help => Driver.WaitForAndFindElement(By.Id("btnWebHelp"));

        public IWebElement About => Driver.WaitForAndFindElement(By.Id("btnVersion"));

        public IWebElement Support => Driver.WaitForAndFindElement(By.Id("btnUserSupport"));

        public IWebElement UserManagement => Driver.WaitForAndFindElement(By.Id("sctUsers")); //old id = btnUserManagementMenu

        public IWebElement BackToLoginBtn => Driver.WaitForAndFindElement(By.Id("btnBackToLogin"));
        public IWebElement LoginTitle => Driver.WaitForAndFindElement(By.Id("login-title"));
        public IWebElement ClientIdContinue => Driver.WaitForAndFindElement(By.Id("btn-continue"));

        public void UserLogin()
        {
            LogInBtnatHome.SafeClick();
            Thread.Sleep(1000);
            EmailId.SendKeys(GetUser.Email);
            Thread.Sleep(1000);
            Password.SendKeys(GetUser.Password);
            LogInBtn.SafeClick();
            Thread.Sleep(1000);
        }


        public void GoToLoginPage(string testEnv)
        {
            Driver.Navigate().GoToUrl(testEnv);
            Console.WriteLine("Testing Env:  " + testEnv);
        }

        public void GoToMechanicLoginPage(string loginUrl)
        {
            string MechanicPortalUrl = loginUrl.Replace("login.html", "mechanic");
            GoToLoginPage(MechanicPortalUrl);
        }

        public string IsAtHomePageDisplayed()
        {
            return PageTitle;
        }

        public void ClickHavingTroubleLoginIn()
        {
            HavingTrubleSignInLink.SafeClick();
        }


        public void PreLoginHelpAndSupport()
        {
            LoginHelpAndSupport.SafeClick();
            var popup = Driver.WindowHandles[1];
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Thread.Sleep(2000);
            Driver.WaitForAndFindElement(By.Id("headerimg")).SafeClick();
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }



        public IWebElement FindElement(By by, int index)
        {
            return Driver.FindElements(by)[index];
        }

        public void ClickHelp()
        {
            HelpIcon.SafeClick();
            Help.SafeClick();
            var popup = Driver.WindowHandles[1];
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Thread.Sleep(2000);
            Driver.WaitForAndFindElement(By.XPath("/html/body/div/div/div/div[1]/nav/div[1]/div/a")).SafeClick();
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            HelpIcon.SafeClick();
            About.SafeClick();
            Driver.WaitForAndFindElement(By.XPath("//*[@id='dialogContent_dlgVersionInfo']/div/img"));
            Driver.Navigate().Refresh();
        }

        public void ClickSupport()
        {
            Support.SafeClick();
            var popup = Driver.WindowHandles[1];
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Thread.Sleep(3000);
            Driver.WaitForAndFindElement(By.XPath("//*[@id='WPht0-gd2imgimage']"));
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            UserManagement.SafeClick();
        }

        public void BackToLogin()
        {
            BackToLoginBtn.SafeClick();
        }
    }
}

