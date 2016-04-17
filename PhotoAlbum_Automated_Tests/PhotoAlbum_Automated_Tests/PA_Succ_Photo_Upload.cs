using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Windows.Forms;
using System.Threading;

namespace TestProjectPhotoAlbum
{
    [TestClass]
    public class SuccessPhotoUpload
    {


        [TestMethod]
        public void SuccessfulPhotoUpload()
        {
            FirefoxDriver driver = new FirefoxDriver();
            string baseURL = "http://photoalbum.bugs3.com/";
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL + "#/");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            driver.FindElement(By.XPath("/html/body/header/div/nav/ul/li[2]/a")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Clear();
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).SendKeys("User01");
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).Clear();
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[2]")).SendKeys("123456");
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/button")).Click();
            Thread.Sleep(3000); // Redirect is slow so extra w8 is needed
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.XPath("/html/body/header/div/nav/ul/li[1]/a")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            driver.FindElement(By.XPath("/html/body/div/aside/a[2]")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            driver.FindElement(By.XPath("/html/body/div/ul/li[1]/button")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.XPath("/html/body/div/ul/li[1]/div/input")).Click();
            driver.FindElement(By.Id("picture-name")).Clear();
            driver.FindElement(By.Id("picture-name")).SendKeys("RamTestQA"); // Needs to be changed every Test!
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.XPath("/html/body/div/ul/li[1]/div/label[2]/input")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            SendKeys.SendWait(@"S:\Users\QA\Desktop\OLD\1432811674.jpg");
            SendKeys.SendWait(@"{Enter}");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            Assert.AreEqual(true, driver.FindElement(By.XPath("//div[contains(.,'RamTestQA')]")).Displayed); // Needs to be changed every Test!
            driver.Close();
        }
    }
}