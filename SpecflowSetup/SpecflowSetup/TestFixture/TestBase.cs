using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecflowSetup.TestFixture
{
    [Binding]
    [SetUpFixture]
    internal class TestBase
    {
        private static IWebDriver driver;

        [BeforeTestRun]
        public static void SetUpDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 2);
        }

        [AfterTestRun]
        public static void TeardownEditorDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
