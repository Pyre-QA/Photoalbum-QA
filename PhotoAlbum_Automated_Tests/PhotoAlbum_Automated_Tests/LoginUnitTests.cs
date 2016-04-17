namespace PhotoAlbum_Automated_Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    [TestClass]
    public class LoginUnitTests
    {
        private const string BaseUrl = "http://photoalbum.bugs3.com/#/";
        private IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            this.driver = new FirefoxDriver();
        }


        [TestMethod]
        public void SuccessfulLogIn()
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
            Assert.AreEqual(true, this.driver.FindElement(By.Id("greet-user")).Displayed);
        }


        [TestMethod]
        public void UnSuccessfulLogInAllFieldsWrong()
        {
            this.driver.Navigate().GoToUrl(BaseUrl);
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/header/div/nav/ul/li[2]/a")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).SendKeys("user" + DateTime.Now.Millisecond);
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).SendKeys("user" + DateTime.Now.Millisecond + "@dgd.bg");
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/button")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            Assert.AreEqual(true, this.driver.FindElement(By.Id("username")).Displayed);
        }



        [TestMethod]
        public void UnSuccessfulLogInEmptyAllFields()
        {
            this.driver.Navigate().GoToUrl(BaseUrl);
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/header/div/nav/ul/li[2]/a")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/button")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            Assert.AreEqual(true, this.driver.FindElement(By.Id("username")).Displayed);
        }

        [TestMethod]
        public void UnSuccessfulLogInEmptyPass()
        {
            this.driver.Navigate().GoToUrl(BaseUrl);
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/header/div/nav/ul/li[2]/a")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).SendKeys("User01");
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/button")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            Assert.AreEqual(true, this.driver.FindElement(By.Id("username")).Displayed);
        }


        [TestMethod]
        public void UnSuccessfulLogInEmptyUser()
        {
            this.driver.Navigate().GoToUrl(BaseUrl);
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/header/div/nav/ul/li[2]/a")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).SendKeys("123456");
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/button")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            Assert.AreEqual(true, this.driver.FindElement(By.Id("username")).Displayed);
        }


        [TestMethod]
        public void UnSuccessfulLogInPassword()
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
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).SendKeys("pass" + DateTime.Now.Millisecond);
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/button")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            Assert.AreEqual(true, this.driver.FindElement(By.Id("username")).Displayed);
        }


        [TestMethod]
        public void UnSuccessfulLogInUser()
        {
            this.driver.Navigate().GoToUrl(BaseUrl);
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/header/div/nav/ul/li[2]/a")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).SendKeys("user" + DateTime.Now.Millisecond);
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Click();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Clear();
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).SendKeys("123456");
            this.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/button")).Click();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            Assert.AreEqual(true, this.driver.FindElement(By.Id("username")).Displayed);
        }

        [TestCleanup]
        public void TearDown()
        {
            this.driver.Quit();
        }
    }
}
