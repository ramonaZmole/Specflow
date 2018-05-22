using OpenQA.Selenium;
using SpecflowSetup.Helpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowSetup.Pages
{
    public class CartPage : AbstractPage
    {
        private readonly By _quickShopLink = By.CssSelector("#qs-toggle");
        private readonly By _firstItemNumberInput = By.CssSelector("[name='materialNumber0']");
        private readonly By _firstQuantityInput = By.CssSelector("[name='quantity0']");
        private readonly By _addToCArtButton = By.CssSelector("#topBarQuickShopForm .btn.btn-success.btn-block");
        private readonly By _removeLink = By.CssSelector("#remove1");
        private readonly By _emptyCartMessage = By.CssSelector(".col-xs-12 h3");
        private readonly By _zipCodeInput = By.CssSelector("#zip-code-input");
        private readonly By _applyZipCodeButton = By.CssSelector("#zip-submit");
        private readonly By _shippingValue = By.CssSelector("#shipping-and-handling>div:last-child");
        private readonly By _materialNumberInputs = By.CssSelector("[name*='materialNumber']");
        private readonly By _quantityInputs = By.CssSelector("[name*='quantity']");
        private readonly By _emptyCartLink = By.CssSelector("#empty-cart-link");

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public void AddProductInCart(int sku, int quantity)
        {
            ActionClick(_quickShopLink);
            ActionSendKeys(_firstItemNumberInput, sku.ToString());
            ActionSendKeys(_firstQuantityInput, quantity.ToString());
            ActionClick(_addToCArtButton);
            WaitForAllAjaxRequestToFinish();
            NavigateTo(Constants.CartUrl);
            WaitForAllAjaxRequestToFinish();
        }

        public void RemoveProductFromCart()
        {
            ActionClick(_removeLink);
            WaitForAllAjaxRequestToFinish();
        }

        public string GetEmptyCartMessage()
        {
            return Driver.FindElement(_emptyCartMessage).Text;
        }

        public void ApplyZipCode()
        {
            ActionClearField(_zipCodeInput);
            ActionSendKeys(_zipCodeInput, Constants.ZipCode);
            ActionClick(_applyZipCodeButton);
            WaitForAllAjaxRequestToFinish();
        }

        public string GetShipping()
        {
            var shipping =
                Driver.FindElement(_shippingValue).FindElement(By.CssSelector("strong")).GetAttribute("ng-if") ??
                Driver.FindElement(_shippingValue).FindElement(By.CssSelector("span")).GetAttribute("ng-if");

            var shippingText = shipping.Equals("cart.shippingAndHandling.success")
                ? Driver.FindElement(_shippingValue).FindElement(By.CssSelector("span>strong")).Text.Replace("$", "")
                : Driver.FindElement(_shippingValue).FindElement(By.CssSelector("strong")).Text;

            return shippingText;
        }

        public bool IsShippingFreeOrUnavailable()
        {
            WaitForAllAjaxRequestToFinish();
            var shipping =
                Driver.FindElement(_shippingValue).FindElement(By.CssSelector("strong")).GetAttribute("ng-if") ??
                Driver.FindElement(_shippingValue).FindElement(By.CssSelector("span")).GetAttribute("ng-if");

            var shippingText = shipping.Equals("cart.shippingAndHandling.success")
                ? Driver.FindElement(_shippingValue).FindElement(By.CssSelector("span>strong")).Text
                : Driver.FindElement(_shippingValue).FindElement(By.CssSelector("strong")).Text;

            return shippingText.Equals("$0.00") || shippingText.Equals(Shipping.FREE) || shippingText.Equals(Shipping.Unavailable);
        }

        public void AddProductsToCart(Table table)
        {
            ActionClick(_quickShopLink);
            var materials = table.CreateSet<MaterialDetails>();
            foreach (var material in materials)
            {
                for (var i = 0; i < 5; i++)
                {
                    var materialList = Driver.FindElements(_materialNumberInputs);
                    var quantityList = Driver.FindElements(_quantityInputs);

                    materialList[i].SendKeys(material.MaterialNumber.ToString());
                    quantityList[i].SendKeys(material.Quantity.ToString());
                }
            }
            ActionClick(_addToCArtButton);
        }

        public void ClickEmptyCartLink()
        {
            ActionClick(_emptyCartLink);
        }
    }
}
