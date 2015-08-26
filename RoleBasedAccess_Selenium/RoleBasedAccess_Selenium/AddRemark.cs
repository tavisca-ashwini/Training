using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{
    [TestClass]
    public class AddRemark
    {
        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void AddRemarkSuccess()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:49357/RoleBasedLogin/CustomLogin.aspx");
            driver.FindElement(By.Id("Authentication_TextBoxUsername")).SendKeys("IshaN@gmail.com");
            driver.FindElement(By.Id("Authentication_TextBoxPassword")).SendKeys("ishannn");
            driver.FindElement(By.Id("Authentication_ButtonLogin")).Click();

            new SelectElement(driver.FindElement(By.Id("WebForm2_EmployeeDropDownList"))).SelectByIndex(2);
            driver.FindElement(By.Id("WebForm2_TextAreaRemark")).SendKeys("this is remark for testing");
            driver.FindElement(By.Id("WebForm2_AddRemarkButton")).Click();

            var status = driver.FindElement(By.Id("Label7")).Displayed;
            Assert.IsTrue(status);
        }

        [TestMethod]
        public void AddRemarkFailure()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:49357/RoleBasedLogin/CustomLogin.aspx");
            driver.FindElement(By.Id("Authentication_TextBoxUsername")).SendKeys("IshaN@gmail.com");
            driver.FindElement(By.Id("Authentication_TextBoxPassword")).SendKeys("ishannn");
            driver.FindElement(By.Id("Authentication_ButtonLogin")).Click();

            new SelectElement(driver.FindElement(By.Id("WebForm2_EmployeeDropDownList"))).SelectByIndex(2);
            driver.FindElement(By.Id("WebForm2_TextAreaRemark")).SendKeys("this is remark for testing");
            driver.FindElement(By.Id("WebForm2_AddRemarkButton")).Click();

            var status = driver.FindElement(By.Id("Label7")).Displayed;
            Assert.IsTrue(!status);
        }
    }
}
