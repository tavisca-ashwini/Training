using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace UnitTestProject1
{
    [TestClass]
    public class ViewRemarks
    {
        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void ViewRemarkSuccess()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:49357/RoleBasedLogin/CustomLogin.aspx");
            driver.FindElement(By.Id("Authentication_TextBoxUsername")).SendKeys("aka@gmail.com");
            driver.FindElement(By.Id("Authentication_TextBoxPassword")).SendKeys("aka");
            driver.FindElement(By.Id("Authentication_ButtonLogin")).Click();

            var status = driver.FindElement(By.Id("WebForm3_GridViewRemark")).Displayed;
            Assert.IsFalse(!status);
        }
    }
}
