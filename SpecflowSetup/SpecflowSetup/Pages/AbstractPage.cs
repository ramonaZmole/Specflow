using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecflowSetup.Pages
{
    public class AbstractPage
    {
        public static IWebDriver Driver;

        public AbstractPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public static void SetupDriver(IWebDriver driver)
        {
            Driver = driver;
        }

        public static CartPage CartPage => new CartPage(Driver);

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
            WaitForAllAjaxRequestToFinish();
        }

        public void ActionClick(By bySelector)
        {
            var clickableWe = Driver.FindElement(bySelector);
            clickableWe.Click();
        }

        protected void ActionClearField(By bySelector)
        {
            var clearWe = Driver.FindElement(bySelector);
            clearWe.Clear();
        }

        public void ActionSendKeys(By bySelector, string text)
        {
            var sendKeysWe = Driver.FindElement(bySelector);
            sendKeysWe.SendKeys(text);
        }

        public void WaitForAllAjaxRequestToFinish()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(driver =>
            {
                var isAjaxFinished = (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return angular.element(document.body).injector().get('$http').pendingRequests.length == 0");
                return isAjaxFinished;
            });

        }
    }
}
