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
        private readonly By _emptyCartButton = By.CssSelector("#empty-cart-model-save");
        private readonly By _applyPriorityCodeButton = By.CssSelector("#prioritycode-apply-button");
        private readonly By _priorityCodeField = By.CssSelector("#promoCode-input");
        private readonly By _discountValue = By.CssSelector("[ng-if='cart.productsDiscount']>.row:nth-child(1) strong");


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

        public void AddProductsToCart(Table table)
        {
            ActionClick(_quickShopLink);
            WaitForAllAjaxRequestToFinish();
            var materials = table.CreateSet<MaterialDetails>();
            var materialList = Driver.FindElements(_materialNumberInputs);
            var quantityList = Driver.FindElements(_quantityInputs);
            var i = 0;
            foreach (var material in materials)
            {
                materialList[i].SendKeys(material.MaterialNumber.ToString());
                quantityList[i].SendKeys(material.Quantity.ToString());
                i++;
            }
            ActionClick(_addToCArtButton);
            WaitForAllAjaxRequestToFinish();
            NavigateTo(Constants.CartUrl);
        }

        public void ClickEmptyCartLink()
        {
            ActionClick(_emptyCartLink);
            ActionClick(_emptyCartButton);
            WaitForAllAjaxRequestToFinish();
        }

        public void AddPriorityCode()
        {
            ActionSendKeys(_priorityCodeField, Constants.PriorityCode);
            ActionClick(_applyPriorityCodeButton);
            WaitForAllAjaxRequestToFinish();
        }

        public bool IsDiscountPresent()
        {
            return Driver.FindElement(_discountValue).Displayed;
        }
    }
}
