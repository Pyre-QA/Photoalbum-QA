namespace PhotoAlbum_Automated_Tests
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Forms;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    [TestClass]
    public class PicturesUnitTests
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
            Thread.Sleep(3000); // Redirect is slow so extra w8 is needed
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void UploadPicture_ValidData_ShouldSucceed()
        {
            try
            {
                IWebElement homeMenuButton = this.driver.FindElement(By.XPath("//li/a"));
                homeMenuButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement categoriesSidebarButton = this.driver.FindElement(By.XPath("/html/body/div/aside/a[2]"));
                categoriesSidebarButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement addPictureToNatureButton = this.driver.FindElement(By.XPath("/html/body/div/ul/li[1]/button"));
                addPictureToNatureButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement titleField = this.driver.FindElement(By.Id("picture-name"));
                titleField.Click();
                titleField.Clear();
                titleField.SendKeys("test");
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                IWebElement chooseFileButton = this.driver.FindElement(By.Id("picture-upload"));
                chooseFileButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                SendKeys.SendWait(@"C:\Users\Daniela\Pictures\test.jpg");
                SendKeys.SendWait(@"{Enter}");
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                Assert.AreEqual(true, this.driver.FindElement(By.XPath("//div[contains(.,'test')]")).Displayed);
            }
            catch (AssertFailedException e)
            {
                string currentTest = this.GetCurrentMethod();
                this.BugReport(e, currentTest);
            }
        }

        [TestMethod]
        public void EnlargePicture_ShouldDisplayAdditionalInformationCorrectly()
        {
            try
            {
            IWebElement firstPicture = this.driver.FindElement(By.XPath(".//*[@id='56e1bf739e3510905d00e0f2']/img"));
                firstPicture.Click();
                Thread.Sleep(5000);
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                IWebElement pictureNameDiv = this.driver.FindElement(By.XPath("//strong"));
                var expectedName = "pirin_in_july";
                var actualName = pictureNameDiv.Text;
                Assert.AreEqual(expectedName, actualName);

                IWebElement authorNameDiv = this.driver.FindElement(By.XPath("//div[2]"));
                var expectedAuthor = "Author: pesho";
                var actualAuthor = authorNameDiv.Text;
                Assert.AreEqual(expectedAuthor, actualAuthor);

                IWebElement likesDiv = this.driver.FindElement(By.XPath("//span"));
                var expectedLikes = "22";
                var actualLikes = likesDiv.Text;
                Assert.AreEqual(expectedLikes, actualLikes);
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
