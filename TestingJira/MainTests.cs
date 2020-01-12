using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace TestingJira
{
    [TestFixture]
    public class MainTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://jira.softserve.academy/login.jsp");
            LoginPage.Login(driver);
            HomePage.SearchingInJira(driver, "Test-26");
        }

        [Test]
        public void CreateCommentInIssue()
        {
            IssuePage comment = new IssuePage(driver);
            string message = "TestComment";
            comment.ClickCommentButton();
            comment.FillCommentField(message);
            comment.SendComment();
            string actualResult = comment.GetTextOfComment();
            Assert.AreEqual(message, actualResult);
        }

        [Test]
        public void EditCommentInIssue()
        {
            IssuePage editComment = new IssuePage(driver);

            string editMessage = "EditTestComment";
            string expectedStatusOfComment = "edited";
            editComment.EditCommentButtonClick();
            editComment.FillEditCommentField(editMessage);
            editComment.SaveEditComment();
            string actualMessage = editComment.GetTextOfComment();
            string actualStatusOfComment = editComment.GetStatusEditComment();
            Assert.AreEqual(editMessage, actualMessage);
            Assert.AreEqual(expectedStatusOfComment, actualStatusOfComment);
        }

        [Test]
        public void DeleteCommentInIssue()
        {
            IssuePage deleteComment = new IssuePage(driver);

            string expectedText = "There are no comments yet on this issue.";
            deleteComment.DeleteCommentClick();
            deleteComment.ConfirmDeleteClick();
            string actualText = deleteComment.GetStatusAfterDelete();
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void StopAndStartWatchersByLink()
        {
            IssuePage watchers = new IssuePage(driver);
            //Start watch
            watchers.WatchersClick();
            string actualQuantity = watchers.GetQuantityWatchers();
            Assert.AreEqual("1", actualQuantity);
            //Stop watch
            watchers.WatchersClick();
            actualQuantity = watchers.GetQuantityWatchers();
            Assert.AreEqual("0", actualQuantity);
        }

        [Test]
        public void ViewWorkflowFromIssue()
        {
            IssuePage workflow = new IssuePage(driver);

            workflow.ClickWorkflowLink();
            bool actualResult = workflow.WorkFlowIsOpened();
            Assert.IsTrue(actualResult);
        }
        [OneTimeTearDown]
        public void CloseChrome()
        {
            driver.Quit();
        }
    }
}
