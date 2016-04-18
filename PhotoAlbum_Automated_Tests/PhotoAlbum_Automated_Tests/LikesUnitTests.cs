namespace PhotoAlbum_Automated_Tests
{
    using System;
    using System.Diagnostics;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
   
    [TestClass]
    public class LikesUnitTests
    {
        private const string BaseUrl = "http://photoalbum.bugs3.com/#/";
        private const string ValidUsername = "pesho";
        private const string ValidPassword = "123456";

        private const string BugTrackerUrl = "https://github.com/Pyre-QA";
        private const string Username = "QASoftUni";
        private const string Password = "QASoftUni123456";

        private IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            this.driver = new FirefoxDriver();

            this.driver.Navigate().GoToUrl(BaseUrl);
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

            IWebElement loginMenuButton = this.driver.FindElement(By.XPath("//li[2]/a"));
            loginMenuButton.Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

            IWebElement usernameField = this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]"));
            usernameField.Click();
            usernameField.Clear();
            usernameField.SendKeys(ValidUsername);

            IWebElement passwordField = this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]"));
            passwordField.Click();
            passwordField.Clear();
            passwordField.SendKeys(ValidPassword);

            IWebElement loginButton = this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/button"));
            loginButton.Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void LikePicture_FirstTime_ShouldSucceed()
        {
            try
            {
                IWebElement numberOfLikesSpan = this.driver.FindElement(By.XPath("//div[3]/span"));
                int numberOfLikesBefore = int.Parse(numberOfLikesSpan.Text);

                IWebElement likeIcon = this.driver.FindElement(By.XPath("//span/img"));
                likeIcon.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                int numberOfLikesAfter = int.Parse(numberOfLikesSpan.Text);

                Assert.AreEqual(numberOfLikesBefore + 1, numberOfLikesAfter);
            }
            catch (AssertFailedException e)
            {
                string currentTest = this.GetCurrentMethod();
                this.BugReport(e, currentTest);
            }
        }

        [TestMethod]
        public void LikePicture_MoreThanOnce_ShouldFail()
        {
            try
            {
                IWebElement numberOfLikesSpan = this.driver.FindElement(By.XPath("//div[3]/span"));
                
                IWebElement likeIcon = this.driver.FindElement(By.XPath("//span/img"));
                likeIcon.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                int numberOfLikesBefore = int.Parse(numberOfLikesSpan.Text);
                
                likeIcon.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                int numberOfLikesAfter = int.Parse(numberOfLikesSpan.Text);

                Assert.AreEqual(numberOfLikesBefore, numberOfLikesAfter);
            }
            catch (AssertFailedException e)
            {
                string currentTest = this.GetCurrentMethod();
                this.BugReport(e, currentTest);
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            this.driver.Quit();
        }

        public string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        private void BugReport(AssertFailedException e, string testMethod)
        {
            string exceptionMessage = e.Message;

            this.driver.Navigate().GoToUrl(BugTrackerUrl);

            IWebElement signInButton = this.driver.FindElement(By.LinkText("Sign in"));
            signInButton.Click();

            IWebElement usernameField = this.driver.FindElement(By.Id("login_field"));
            usernameField.Clear();
            usernameField.SendKeys(Username);

            IWebElement passwordField = this.driver.FindElement(By.Id("password"));
            passwordField.Clear();
            passwordField.SendKeys(Password);

            IWebElement commitButton = this.driver.FindElement(By.Name("commit"));
            commitButton.Click();

            IWebElement repoButton = this.driver.FindElement(By.LinkText("Photoalbum-QA"));
            repoButton.Click();

            IWebElement issuesTabButton = this.driver.FindElement(By.XPath("//span[2]/a/span"));
            issuesTabButton.Click();

            this.driver.Navigate().GoToUrl(BugTrackerUrl + "/Pyre-QA/Photoalbum-QA/issues");
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            IWebElement newIssueButton = this.driver.FindElement(By.XPath("//div/div/div/a"));
            newIssueButton.Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            IWebElement issueTitleField = this.driver.FindElement(By.Id("issue_title"));
            issueTitleField.Clear();
            issueTitleField.SendKeys(testMethod + " failed");

            IWebElement issueBodyField = this.driver.FindElement(By.Id("issue_body"));
            issueBodyField.Clear();
            issueBodyField.SendKeys(exceptionMessage);

            IWebElement submitNewIssueButton = this.driver.FindElement(By.XPath("//form/div[2]/div/div/div/div[3]/button"));
            submitNewIssueButton.Click();
        }
    }
}
