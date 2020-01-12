using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingJira
{
    public static class HomePage
    {
        public static void SearchingInJira(IWebDriver driver,string message)
        {
            By searchField = By.XPath("//input[contains(@name, 'searchString')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(searchField));
            driver.FindElement(searchField).SendKeys(message);
            driver.FindElement(searchField).SendKeys(Keys.Enter);
        }
    }
}
