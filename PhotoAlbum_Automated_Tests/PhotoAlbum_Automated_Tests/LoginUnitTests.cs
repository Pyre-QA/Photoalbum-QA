namespace PhotoAlbum_Automated_Tests
{
    using System;
    using System.Diagnostics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    [TestClass]
    public class LoginUnitTests
    {
        private const string BaseUrl = "http://photoalbum.bugs3.com/#/";
        private const string ValidUsername = "pesho";
        private const string ValidPassword = "123456";
        private const string InvalidUsername = "pesho1";
        private const string InvalidPassword = "1234567";

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
        public void ClickLoginButton_ShouldOpenLoginPage()
        {
            try
            {
                this.driver.Navigate().GoToUrl(BaseUrl);
                this.driver.Manage().Window.Maximize();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement loginMenuButton = this.driver.FindElement(By.XPath("//li[2]/a"));
                loginMenuButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                Assert.AreEqual("http://photoalbum.bugs3.com/#/login", this.driver.Url);
            }
            catch (AssertFailedException e)
            {
                string currentTest = this.GetCurrentMethod();
                this.BugReport(e, currentTest);
            }
        }
        
        [TestMethod]
        public void SuccessfulLogin_ShouldOpenPicturesPage()
        {
            try
            {
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
        public void SuccessfulLogin_ShouldGreetUser_WithUsername()
        {
            try
            {
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


                IWebElement greetingElement = this.driver.FindElement(By.Id("greet-user"));
                var expected = "Hello, pesho";
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
        public void Login_InavlidUsername_ShouldStayOnLoginPage()
        {
            try
            {
                this.driver.Navigate().GoToUrl(BaseUrl);
                this.driver.Manage().Window.Maximize();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement loginMenuButton = this.driver.FindElement(By.XPath("//li[2]/a"));
                loginMenuButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement usernameField = this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]"));
                usernameField.Click();
                usernameField.Clear();
                usernameField.SendKeys(InvalidUsername);

                IWebElement passwordField = this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]"));
                passwordField.Click();
                passwordField.Clear();
                passwordField.SendKeys(ValidPassword);

                IWebElement loginButton = this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/button"));
                loginButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                Assert.AreEqual("http://photoalbum.bugs3.com/#/login", this.driver.Url);
            }
            catch (AssertFailedException e)
            {
                string currentTest = this.GetCurrentMethod();
                this.BugReport(e, currentTest);
            }
        }

        [TestMethod]
        public void Login_InavlidPassword_ShouldStayOnLoginPage()
        {
            try
            {
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
                passwordField.SendKeys(InvalidPassword);

                IWebElement loginButton = this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/button"));
                loginButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                Assert.AreEqual("http://photoalbum.bugs3.com/#/login", this.driver.Url);
            }
            catch (AssertFailedException e)
            {
                string currentTest = this.GetCurrentMethod();
                this.BugReport(e, currentTest);
            }
        }

        [TestMethod]
        public void Login_EmptyFields_ShouldStayOnLoginPage()
        {
            try
            {
                this.driver.Navigate().GoToUrl(BaseUrl);
                this.driver.Manage().Window.Maximize();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement loginMenuButton = this.driver.FindElement(By.XPath("//li[2]/a"));
                loginMenuButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

                IWebElement loginButton = this.driver.FindElement(
                    By.XPath("/html/body/div/div/div/div/div/form/button"));
                loginButton.Click();
                this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                Assert.AreEqual("http://photoalbum.bugs3.com/#/login", this.driver.Url);
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
