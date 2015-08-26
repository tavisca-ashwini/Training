using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace UnitTestProject1
{
    [TestClass]
    public class LoginCheck
    {
        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void LoginSuccess()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:49357/RoleBasedLogin/CustomLogin.aspx");
            driver.FindElement(By.Id("Authentication_TextBoxUsername")).SendKeys("aka@gmail.com");
            driver.FindElement(By.Id("Authentication_TextBoxPassword")).SendKeys("aka");
            driver.FindElement(By.Id("Authentication_ButtonLogin")).Click();

            var status = driver.FindElement(By.Id("Authentication_LabelAuth")).Displayed;
        }

        [TestMethod]
        public void LoginFailure()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:49357/RoleBasedLogin/CustomLogin.aspx");
            driver.FindElement(By.Id("Authentication_TextBoxUsername")).SendKeys("aka@gmail.com");
            driver.FindElement(By.Id("Authentication_TextBoxPassword")).SendKeys("password");
            driver.FindElement(By.Id("Authentication_ButtonLogin")).Click();

            var status = driver.FindElement(By.Id("Authentication_LabelAuth")).Displayed;
            Assert.IsFalse(!status);
        }
    }
}
