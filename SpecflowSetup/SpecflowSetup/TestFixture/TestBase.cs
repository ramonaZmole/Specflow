using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecflowSetup.TestFixture
{
    internal class TestBase
    {
        private static IWebDriver driver;
   
        public static void SetUpDriver()
        {
                var options = new ChromeOptions();
                options.AddArguments("start-maximized");
                driver = new ChromeDriver(options);
                driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 2);
        }

        public static void TeardownEditorDriver()
        {
            driver.Dispose();
        }
    }
}
