using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace UnitTestProject1
{
    [TestClass]
    public class ChangePassword
    {
        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void ChangePasswordSuccess()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:49357/RoleBasedLogin/CustomLogin.aspx");
            driver.FindElement(By.Id("Authentication_TextBoxUsername")).SendKeys("aka@gmail.com");
            driver.FindElement(By.Id("Authentication_TextBoxPassword")).SendKeys("aka");
            driver.FindElement(By.Id("Authentication_ButtonLogin")).Click();

            driver.FindElement(By.Id("WebForm5_TextBoxEmail")).SendKeys("aka@gmail.com");
            driver.FindElement(By.Id("WebForm5_TextBoxOldPassword")).SendKeys("aka");
            driver.FindElement(By.Id("WebForm5_TextBoxNewPassword")).SendKeys("akardile");
            driver.FindElement(By.Id("WebForm5_TextBoxConfirm")).SendKeys("akardile");
            driver.FindElement(By.Id("WebForm5_ButtonSubmit")).Click();

            var status = driver.FindElement(By.Id("Label6")).Displayed;
            Assert.IsFalse(!status);
        }
    }
}
