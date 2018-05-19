using OpenQA.Selenium;
using SpecflowSetup.Pages;

namespace SpecflowSetup.Steps
{
    public class AbstractSteps
    {
        public AbstractPage AbstractPage;

        protected readonly CartPage CartPage;

        protected IWebDriver Driver;

        public AbstractSteps(IWebDriver driver)
        {
            Driver = driver;

            AbstractPage = new AbstractPage(driver);
            CartPage = new CartPage(driver);
        }

        public void NavigateTo(string url)
        {
            AbstractPage.NavigateTo(url);
        }
    }
}
