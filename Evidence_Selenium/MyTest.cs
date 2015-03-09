using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace Evidence_Selenium
{
    [TestClass]
    public class MyTest
    {
        IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            //start browser and open url
            driver = new ChromeDriver(@"C:\webdrivers");
            driver.Navigate().GoToUrl("http://alpha.evidence.nhs.uk/Search?q=asperger%27s+syndrome");

        }

        [TestMethod]
        public void VerifyTitle()
        {
            string title = driver.Title;
            Assert.AreEqual(title, "Evidence Search - Search Engine for Evidence in Health and Social Care");
        }

        [TestMethod]
        public void TestEmptySearchBar()
        {
            Assert.AreEqual(driver.FindElement(By.Name("q")).Text, string.Empty);
        }

        [TestMethod]
        public void TestURLEncoding_NumberofResultsChanged()
        {
            driver.FindElement(By.Name("ps")).SendKeys("50" + Keys.Enter);
            var searchBox = driver.FindElement(By.Name("q"));
            Assert.AreEqual(searchBox, "asperger's syndrome");
        }   

        [TestMethod]
        public void TestTextIsThere()
        {
            var text = driver.FindElement(By.ClassName("strap")).Text;
            Assert.AreEqual(text, "Search our unique index of authoritative, evidence-based information from hundreds of trustworthy and accredited sources.");
        }

        [TestMethod]

        public void TestTextTitle()
        {
            var text = driver.FindElement(By.ClassName("clearfix")).Text;
            Assert.AreEqual(text, "Evidence search");
        }

        [TestCleanup]
        public void CleanTest()
        {
            //close browser
            driver.Quit();
        }
    }
}
