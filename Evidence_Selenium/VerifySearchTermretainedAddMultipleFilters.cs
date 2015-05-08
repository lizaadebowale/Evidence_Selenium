using System;
using System.Text;
using System.Text.RegularExpressions;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
//using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Evidence_Selenium
{
    [TestFixture]
    public class VerifySearchTermretainedAddMultipleFilters
    {
        IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void Setup()
        {
            driver = new InternetExplorerDriver();
            baseURL = "http://www.evidence.nhs.uk/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void CleanTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            NUnit.Framework.Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestCase]
        public void TheVerifySearchTermretainedAddMultipleFiltersTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Name("q")).Clear();
            driver.FindElement(By.Name("q")).SendKeys("paracetamol");
            driver.FindElement(By.CssSelector("button[type=\"submit\"]")).Click();
            driver.FindElement(By.LinkText("Areas of interest")).Click();
            driver.FindElement(By.LinkText("Clinical")).Click();
            driver.FindElement(By.LinkText("Sources")).Click();
            driver.FindElement(By.LinkText("Alzheimer's Society")).Click();
            new SelectElement(driver.FindElement(By.Name("ps"))).SelectByText("100 per page");
            driver.FindElement(By.CssSelector("button.btn-primary")).Click();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("paracetamol", driver.FindElement(By.Name("q")).GetAttribute("value"));
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
