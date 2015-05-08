using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace Evidence_Selenium 
{
    [TestFixture]
    public class Evidence_Homepage
    {
        IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            //stert browser and openurl
            driver = 
            driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("http://test.evidence.nhs.uk");

        }

        [TestCase]
        public void Homepage_TestTextIsThere()
        {
            var text = driver.FindElement(By.ClassName("strap")).Text;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(text, "Search our unique index of authoritative, evidence-based information from hundreds of trustworthy and accredited sources.");
        }

        [TearDown]
        public void CleanTest()
        {
            //close browser
            driver.Quit();
        }
    }
}
