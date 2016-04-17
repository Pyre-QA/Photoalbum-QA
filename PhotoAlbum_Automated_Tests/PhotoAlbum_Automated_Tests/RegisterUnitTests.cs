namespace PhotoAlbum_Automated_Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    [TestClass]
    public class RegisterUnitTests
    {
        private const string BaseUrl = "http://photoalbum.bugs3.com/#/";
        private IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            this.driver = new FirefoxDriver();
        }

        [TestMethod]
        public void SuccessfulRegistrationAndExistingUserAddedToUsersPage()
        {
            this.driver.Navigate().GoToUrl(BaseUrl);
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/header/div/nav/ul/li[2]/a")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).SendKeys("User01");
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).SendKeys("123456");
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/button")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/header/div/nav/ul/li[1]/a")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/div/aside/a[3]")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            Assert.AreEqual(true, this.driver.FindElement(By.XPath("//div[contains(.,'User01')]")).Displayed);
        }


        [TestMethod]
        public void SuccessfulRegistrationAndNewUserAddedToUsersPage()
        {
            this.driver.Navigate().GoToUrl(BaseUrl);
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/header/div/nav/ul/li[3]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).SendKeys("UserAddQA"); // Needs to be changed every Test!
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).SendKeys("user" + DateTime.Now.Millisecond + "@dgd.bg");
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[3]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[3]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[3]")).SendKeys("123456");
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[4]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[4]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[4]")).SendKeys("123456");
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/button")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/header/div/nav/ul/li[1]/a")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/div/aside/a[3]")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            Assert.AreEqual(true, this.driver.FindElement(By.XPath("//div[contains(.,'UserAddQA')]")).Displayed);
        }

        [TestMethod]
        public void SuccessfulRegistration()
        {
            this.driver.Navigate().GoToUrl(BaseUrl);
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/header/div/nav/ul/li[3]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).SendKeys("user" + DateTime.Now.Millisecond);
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).SendKeys("user" + DateTime.Now.Millisecond + "@dgd.bg");
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[3]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[3]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[3]")).SendKeys("123456");
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[4]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[4]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[4]")).SendKeys("123456");
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/button")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            Assert.AreEqual(true, this.driver.FindElement(By.Id("greet-user")).Displayed);
        }


        [TestCleanup]
        public void TearDown()
        {
            this.driver.Quit();
        }

    }
}
