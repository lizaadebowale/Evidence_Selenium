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
    public class Evidence_ResultsPage_HandlesApostrophe
    {
        IWebDriver driver;
        

        [SetUp]
        public void Setup()
        {
            //start browser and open url
            //driver = new ChromeDriver(@"C:\webdrivers");
            driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("http://test.evidence.nhs.uk/Search?q=asperger%27s+syndrome");

        }

        [TestCase]
        public void ResultsPage_VerifyTitle()
        {
            string title = driver.Title;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(title, "asperger's syndrome - Search Results - Evidence Search - Search Engine for Evidence in Health and Social Care");
        }

        [TestCase]
        public void ResultsPage_TestEmptySearchBar()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(driver.FindElement(By.Name("q")).Text, string.Empty);
        }

        [TestCase]
        public void ResultsPage_TestURLEncoding_NumberofResultsChanged()
        {
            driver.FindElement(By.Name("ps")).SendKeys("50" + Keys.Enter);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("asperger's syndrome", driver.FindElement(By.Name("q")).GetAttribute("value"));
        }   

        [TestCase]

        public void ResultsPage_TestTextTitle()
        {
            var text = driver.FindElements(By.XPath("//*[@id=\"searchfilters\"]/ul/li[1]/a"));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(text[0].Text, "Accredited");
        }

       
        [TearDown]
        public void CleanTest()
        {
            //close browser
            driver.Quit();
        }
    }
}
