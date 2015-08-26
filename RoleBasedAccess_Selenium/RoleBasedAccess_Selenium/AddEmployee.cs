using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace UnitTestProject1
{
    [TestClass]
    public class AddEmployee
    {
        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void AddEmployeeSuccess()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:49357/RoleBasedLogin/CustomLogin.aspx");
            driver.FindElement(By.Id("Authentication_TextBoxUsername")).SendKeys("IshaN@gmail.com");
            driver.FindElement(By.Id("Authentication_TextBoxPassword")).SendKeys("ishannn");
            driver.FindElement(By.Id("Authentication_ButtonLogin")).Click();

            driver.FindElement(By.Id("WebForm1_TextBoxTitle")).SendKeys("Mr");
            driver.FindElement(By.Id("WebForm1_TextBoxFirstName")).SendKeys("anil");
            driver.FindElement(By.Id("WebForm1_TextBoxLastName")).SendKeys("sharma");
            driver.FindElement(By.Id("WebForm1_TextBoxEmail")).SendKeys("anil@gmail.com");
            driver.FindElement(By.Id("WebForm1_TextBoxContact")).SendKeys("7889451312");
            driver.FindElement(By.Id("WebForm1_TextBoxDesignation")).SendKeys("HR");
            driver.FindElement(By.Id("WebForm1_ButtonSubmit")).Click();

            var status = driver.FindElement(By.Id("Label6")).Displayed;
            Assert.IsTrue(status);
        }

        [TestMethod]
        public void AddEmployeeFailure()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:49357/RoleBasedLogin/CustomLogin.aspx");
            driver.FindElement(By.Id("Authentication_TextBoxUsername")).SendKeys("IshaN@gmail.com");
            driver.FindElement(By.Id("Authentication_TextBoxPassword")).SendKeys("ishannn");
            driver.FindElement(By.Id("Authentication_ButtonLogin")).Click();

            driver.FindElement(By.Id("WebForm1_TextBoxTitle")).SendKeys("Mr");
            driver.FindElement(By.Id("WebForm1_TextBoxFirstName")).SendKeys("anil");
            driver.FindElement(By.Id("WebForm1_TextBoxLastName")).SendKeys("sharma");
            driver.FindElement(By.Id("WebForm1_TextBoxEmail")).SendKeys("anil@gmail.com");
            driver.FindElement(By.Id("WebForm1_TextBoxContact")).SendKeys("fevbfjkgc");
            driver.FindElement(By.Id("WebForm1_TextBoxDesignation")).SendKeys("HR");
            driver.FindElement(By.Id("WebForm1_ButtonSubmit")).Click();

            var status = driver.FindElement(By.Id("Label6")).Displayed;
            Assert.IsTrue(!status);
        }
    }
}
