using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingJira
{
    public class IssuePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        //Create comment
        By commentButton = By.XPath("//a[contains(@title, 'Comment on this issue')]");
        By commentField = By.XPath("//div[contains(@class, 'rte-container')]");
        By sendCommentButton = By.XPath("//input[contains(@accesskey, 's')]");
        By textOfComment = By.XPath("//div[contains(@class, 'action-body flooded')]");

        //Edit comment
        By editCommentButton = By.XPath("//span[contains(@class, 'icon-default aui-icon aui-icon-small aui-iconfont-ed')]");
        By editCommentField = By.XPath("//div[contains(@id, 'comment-wiki-edit')]");
        By statusEditComment = By.XPath("//span[contains(@class, 'redText subText')]");

        //Delete comment
        By deleteCommentButton = By.XPath("//span[contains(@class, 'delete')]");
        By confirmDeleteButton = By.XPath("//input[contains(@name, 'Delete')]");
        By textOfStatusAfterDelete = By.XPath("//div[contains(@class, 'message-container')]");

        //Watchers
        By watchersLink = By.XPath("//a[contains(@id, 'watching-toggle')]");
        By quantityWatchers = By.XPath("//span[contains(@id, 'watcher')]");

        //Watch Worflow
        By workflowWindow = By.XPath("//div[contains(@id, 'view-workflow-dialog')]");
        By workflowLink = By.XPath("//a[contains(@title, 'workflow:')]");

        public IssuePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void ClickCommentButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(commentButton));
            driver.FindElement(commentButton).Click();
        }

        public void FillCommentField(string message)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(commentField));
            driver.FindElement(commentField).SendKeys(message);
        }

        public void SendComment()
        {
            driver.FindElement(sendCommentButton);
        }

        public string GetTextOfComment()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(textOfComment));
            return driver.FindElement(textOfComment).GetAttribute("innerText").ToString();
        }

        public void EditCommentButtonClick()
        {
            driver.FindElement(editCommentButton).Click();
        }

        public void FillEditCommentField(string editMessage)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(editCommentField));
            driver.FindElement(editCommentField).SendKeys(editMessage);
        }

        public void SaveEditComment()
        {
            driver.FindElement(sendCommentButton).Click();
        }

        public string GetStatusEditComment()
        {
            return driver.FindElement(statusEditComment).GetAttribute("innerText").ToString();
        }

        public void DeleteCommentClick()
        {
            driver.FindElement(deleteCommentButton).Click();
        }

        public void ConfirmDeleteClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(confirmDeleteButton));
            driver.FindElement(confirmDeleteButton).Click();
        }

        public string GetStatusAfterDelete()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(textOfStatusAfterDelete));
            return driver.FindElement(textOfStatusAfterDelete).GetAttribute("innerText").ToString();
        }

        public void WatchersClick()
        {
            driver.FindElement(watchersLink).Click();
        }

        public string GetQuantityWatchers()
        {
            return driver.FindElement(quantityWatchers).GetAttribute("innerText").ToString();
        }

        public void ClickWorkflowLink()
        {
            driver.FindElement(workflowLink).Click();
        }

        public bool WorkFlowIsOpened()
        {
            return driver.FindElement(workflowWindow).Displayed;
        }

    }
}
