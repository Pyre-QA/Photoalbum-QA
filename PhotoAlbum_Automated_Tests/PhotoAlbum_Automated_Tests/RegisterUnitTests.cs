namespace PhotoAlbum_Automated_Tests
{
    using System;
    using System.Diagnostics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    [TestClass]
    public class RegisterUnitTests
    {
        private const string BaseUrl = "http://photoalbum.bugs3.com/#/";
        private const string RegisterUsername = "gogo";
        private const string RegisterEmail = "gogo@gogo.com";
        private const string RegisterPassword = "123456";

        private const string BugTrackerUrl = "https://github.com/Pyre-QA";
        private const string Username = "QASoftUni";
        private const string Password = "QASoftUni123456";

        private IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            this.driver = new FirefoxDriver();
        }

        [TestMethod]
        public void ClickRegisterButton_ShouldOpenRegisterPage()
        {
            try
            {
                this.driver.Navigate().GoToUrl(BaseUrl);
                this.driver.Manage().Window.Maximize();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement registerMenuButton = this.driver.FindElement(By.XPath("//li[3]/a"));
                registerMenuButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                Assert.AreEqual("http://photoalbum.bugs3.com/#/register", this.driver.Url);
            }
            catch (AssertFailedException e)
            {
                string currentTest = this.GetCurrentMethod();
                this.BugReport(e, currentTest);
            }
        }

        [TestMethod]
        public void SuccessfulRegistration_ShouldOpenPicturesPage()
        {
            try
            {
                this.driver.Navigate().GoToUrl(BaseUrl);
                this.driver.Manage().Window.Maximize();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement registerMenuButton = this.driver.FindElement(By.XPath("//li[3]/a"));
                registerMenuButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement usernameField = this.driver.FindElement(By.Id("username"));
                usernameField.Click();
                usernameField.Clear();
                usernameField.SendKeys(RegisterUsername);

                IWebElement emailField = this.driver.FindElement(By.Id("email"));
                emailField.Click();
                emailField.Clear();
                emailField.SendKeys(RegisterEmail);

                IWebElement passwordField = this.driver.FindElement(By.Id("password"));
                passwordField.Click();
                passwordField.Clear();
                passwordField.SendKeys(RegisterPassword);

                IWebElement repeatPasswordField = this.driver.FindElement(By.Id("repeatPass"));
                repeatPasswordField.Click();
                repeatPasswordField.Clear();
                repeatPasswordField.SendKeys(RegisterPassword);

                IWebElement registerButton = this.driver.FindElement(By.Id("register"));
                registerButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                IWebElement greetingElement = this.driver.FindElement(By.Id("greet-user"));
                Assert.AreEqual("http://photoalbum.bugs3.com/#/pictures", this.driver.Url);
            }
            catch (AssertFailedException e)
            {
                string currentTest = this.GetCurrentMethod();
                this.BugReport(e, currentTest);
            }
        }

        [TestMethod]
        public void SuccessfulRegistration_ShouldGreetUser_WithUsername()
        {
            try
            {
                this.driver.Navigate().GoToUrl(BaseUrl);
                this.driver.Manage().Window.Maximize();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement registerMenuButton = this.driver.FindElement(By.XPath("//li[3]/a"));
                registerMenuButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement usernameField = this.driver.FindElement(By.Id("username"));
                usernameField.Click();
                usernameField.Clear();
                usernameField.SendKeys(RegisterUsername);

                IWebElement emailField = this.driver.FindElement(By.Id("email"));
                emailField.Click();
                emailField.Clear();
                emailField.SendKeys(RegisterEmail);

                IWebElement passwordField = this.driver.FindElement(By.Id("password"));
                passwordField.Click();
                passwordField.Clear();
                passwordField.SendKeys(RegisterPassword);

                IWebElement repeatPasswordField = this.driver.FindElement(By.Id("repeatPass"));
                repeatPasswordField.Click();
                repeatPasswordField.Clear();
                repeatPasswordField.SendKeys(RegisterPassword);

                IWebElement registerButton = this.driver.FindElement(By.Id("register"));
                registerButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));


                IWebElement greetingElement = this.driver.FindElement(By.Id("greet-user"));
                var expected = "Hello, gogo";
                var actual = greetingElement.Text;

                Assert.AreEqual(expected, actual);
            }
            catch (AssertFailedException e)
            {
                string currentTest = this.GetCurrentMethod();
                this.BugReport(e, currentTest);
            }
        }


        [TestMethod]
        public void SuccessfulRegistration_ShouldAddUser_UsersPage()
        {
            try
            {
                this.driver.Navigate().GoToUrl(BaseUrl);
                this.driver.Manage().Window.Maximize();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement registerMenuButton = this.driver.FindElement(By.XPath("//li[3]/a"));
                registerMenuButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement usernameField = this.driver.FindElement(By.Id("username"));
                usernameField.Click();
                usernameField.Clear();
                usernameField.SendKeys(RegisterUsername);

                IWebElement emailField = this.driver.FindElement(By.Id("email"));
                emailField.Click();
                emailField.Clear();
                emailField.SendKeys(RegisterEmail);

                IWebElement passwordField = this.driver.FindElement(By.Id("password"));
                passwordField.Click();
                passwordField.Clear();
                passwordField.SendKeys(RegisterPassword);

                IWebElement repeatPasswordField = this.driver.FindElement(By.Id("repeatPass"));
                repeatPasswordField.Click();
                repeatPasswordField.Clear();
                repeatPasswordField.SendKeys(RegisterPassword);

                IWebElement registerButton = this.driver.FindElement(By.Id("register"));
                registerButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                IWebElement homeMenuButton = this.driver.FindElement(By.XPath("//li/a"));
                homeMenuButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement usersSidebarButton = this.driver.FindElement(By.XPath("/html/body/div/aside/a[3]"));
                usersSidebarButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement newUserDiv = this.driver.FindElement(By.XPath("//div[contains(.,'gogo')]"));

                Assert.AreEqual(true, newUserDiv.Displayed);
            }
            catch (AssertFailedException e)
            {
                string currentTest = this.GetCurrentMethod();
                this.BugReport(e, currentTest);
            }
        }

        [TestMethod]
        public void Register_EmptyFields_ShouldStayOnRegisterPage()
        {
            try
            {
                this.driver.Navigate().GoToUrl(BaseUrl);
                this.driver.Manage().Window.Maximize();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement registerMenuButton = this.driver.FindElement(By.XPath("//li[3]/a"));
                registerMenuButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement registerButton = this.driver.FindElement(By.Id("register"));
                registerButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));


                Assert.AreEqual("http://photoalbum.bugs3.com/#/register", this.driver.Url);
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
