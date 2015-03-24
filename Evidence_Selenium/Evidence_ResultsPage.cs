using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace Evidence_Selenium
{
    [TestClass]
    public class Evidence_ResultsPage
    {
        IWebDriver driver;
        

        [TestInitialize]
        public void Setup()
        {
            //start browser and open url
            //driver = new ChromeDriver(@"C:\webdrivers");
            driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("http://test.evidence.nhs.uk/Search?q=asperger%27s+syndrome");

        }

        [TestMethod]
        public void VerifyTitle()
        {
            string title = driver.Title;
            Assert.AreEqual(title, "asperger's syndrome - Search Results - Evidence Search - Search Engine for Evidence in Health and Social Care");
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            Assert.AreEqual("asperger's syndrome", driver.FindElement(By.Name("q")).GetAttribute("value"));
        }   

        [TestMethod]

        public void TestTextTitle()
        {
            var text = driver.FindElements(By.XPath("//*[@id=\"searchfilters\"]/ul/li[1]/a"));
            Assert.AreEqual(text[0].Text, "Accredited");
        }

       
        [TestCleanup]
        public void CleanTest()
        {
            //close browser
            driver.Quit();
        }
    }
}
