namespace TestNamespace
{
    using System;
    using NUnit.Framework;
    using NUnit.Core;
    using SeleniumTests;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    class AllTests
    {
        public static IWebDriver WebDriver { get; private set; }

        [Suite]
        public static TestSuite Suite
        {
            get
            {
                TestSuite suite = new TestSuite("All Tests");

                //Setup a Web driver (see methods below for different browsers) - SetupIE(), SetupChrome(), SetupFirefox()
                SetupIE();

                // Add tests to suite
                suite.Add(new FlashLoadedTest { Driver = WebDriver });

                // Tear down a Web driver
                suite.Add(new TearDownTest { DriverToTearDown = WebDriver });

                // return suite to NUnit
                return suite;
            }
        }

        // Method that's initialises FireFox Driver
        private static void SetupFireFox()
        {
            WebDriver = new FirefoxDriver();
        }

        // Method that's initialises IE Driver
        private static void SetupIE()
        {
            WebDriver = new InternetExplorerDriver();
        }


        // Can't get this working, but this is how its supposed to work
        private static void SetupChrome()
        {
            WebDriver = new ChromeDriver(@"C:\webdrivers");
        }


        // Class with a test that tears down browser instance
        [TestFixture]
        class TearDownTest
        {
            public IWebDriver DriverToTearDown;

            [Test]
            public void TearDownBrowser()
            {
                if (DriverToTearDown == null)
                    Assert.Fail("No Browser to Tear Down");

                try
                {
                    DriverToTearDown.Close();
                    DriverToTearDown.Dispose();
                }
                catch
                {
                    Assert.Fail("Browser failed to tear down");
                }
            }
        }

    }
}
