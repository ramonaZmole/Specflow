using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowSetup.TestFixture
{
    internal class TestBase
    {
        private static IWebDriver editorDriver;

        public static IWebDriver EditorDriver
        {
            get { return editorDriver; }
        }

        public static void SetUpEditorDriver()
        {
            try
            {
                var options = new ChromeOptions();
                options.AddArguments("start-maximized");
                editorDriver = new ChromeDriver(options);
                editorDriver.Manage().Window.Maximize();
                editorDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 2);

                ConsumerPages.SetupDriver(editorDriver);

                var editorHomePage = ConsumerPages.EditorPage;
                editorDriver.Navigate().GoToUrl(editorHomePage.Url);
            }
            catch (Exception e)
            {
                AppSettings.log.Error("Error with setting up the EMT Driver, exception: " + e);
            }
        }

        public static void TeardownEditorDriver()
        {
            EditorDriver.Dispose();
        }
    }
}
