using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestingJira
{
    public static class LoginPage
    {
        private const string UserName = "nbriktc";
        private const string Password = "\"1zZwsyt";
        public static void Login(IWebDriver driver)
        {
            By loginField = By.XPath("//input[contains(@name, 'os_username')]");
            By passwordField = By.XPath("//input[contains(@name, 'os_password')]");
            By loginButton = By.XPath("//input[contains(@name, 'login')]");

            driver.FindElement(loginField).SendKeys(UserName);
            driver.FindElement(passwordField).SendKeys(Password);
            driver.FindElement(loginButton).Click();
        }
    }

    
}
