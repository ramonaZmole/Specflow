using OpenQA.Selenium;
using SpecflowSetup.Helpers;

namespace SpecflowSetup.Pages
{
    public class CheckoutPage : AbstractPage
    {
        private readonly By _priorityCodeInput = By.CssSelector("[name='priorityCode']");
        private readonly By _applyPromoCodeButton = By.CssSelector("#PriorityCodeBody > div:nth-child(2) > button");
        private readonly By _discountValue = By.CssSelector("#discounts-value-checkout>strong");
        private readonly By _emailInput = By.CssSelector("input#Login_Email");
        private readonly By _loginButton = By.CssSelector("#loginForm  button");
        private readonly By _passInput = By.CssSelector("#Login_Password");

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
        }

        public void ApplyPriorityCode()
        {
            ActionSendKeys(_priorityCodeInput, Constants.PriorityCode);
            ActionClick(_applyPromoCodeButton);
            WaitForAllAjaxRequestToFinish();
        }

        public bool IsDiscountDisplayed()
        {
            return Driver.FindElement(_discountValue).Displayed;
        }

        public void Login()
        {
            ActionSendKeys(_emailInput, "test.noriel@gmail.com");
            ActionSendKeys(_passInput, Constants.Password);
            ActionClick(_loginButton);
            WaitForAllAjaxRequestToFinish();
        }
    }
}
