using OpenQA.Selenium;

namespace SpecflowSetup.Pages
{
    public class ConsumerPages
    {
        public static IWebDriver Driver;

        public static void SetupDriver(IWebDriver driver)
        {
            Driver = driver;
        }

        public static CartPage CartPage => new CartPage(Driver);
    }
}
