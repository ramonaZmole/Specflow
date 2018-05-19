using OpenQA.Selenium;
using SpecflowSetup.Helpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowSetup.Pages
{
    public class CartPage : AbstractPage
    {
        private readonly By quickShopLink = By.CssSelector("#qs-toggle");
        private readonly By firstItemNumberInput = By.CssSelector("[name='materialNumber0']");
        private readonly By firstQuantityInput = By.CssSelector("[name='quantity0']");
        private readonly By addToCArtButton = By.CssSelector("#topBarQuickShopForm .btn.btn-success.btn-block");
        private readonly By removeLink = By.CssSelector("#remove1");
        private readonly By emptyCartMessage = By.CssSelector(".col-xs-12 h3");
        private readonly By zipCodeInput = By.CssSelector("#zip-code-input");
        private readonly By applyZipCodeButton = By.CssSelector("#zip-submit");
        private readonly By shippingValue = By.CssSelector("#shipping-and-handling>div:last-child");
        private readonly By materialNumberInputs = By.CssSelector("[name*='materialNumber']");
        private readonly By quantityInputs = By.CssSelector("[name*='quantity']");

        public CartPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }


        public void AddProductInCart(int sku, int quantity)
        {
            ActionClick(quickShopLink);
            ActionSendKeys(firstItemNumberInput, sku.ToString());
            ActionSendKeys(firstQuantityInput, quantity.ToString());
            ActionClick(addToCArtButton);
            NavigateTo(Constants.CartUrl);
        }

        public void RemoveProductFromCart()
        {
            ActionClick(removeLink);
        }

        public string GetEmptyCartMessage()
        {
            return Driver.FindElement(emptyCartMessage).Text;
        }

        public void ApplyZipCode()
        {
            ActionClearField(zipCodeInput);
            ActionSendKeys(zipCodeInput, Constants.ZipCode);
            ActionClick(applyZipCodeButton);
        }

        public string GetShipping()
        {
            var shipping =
                Driver.FindElement(shippingValue).FindElement(By.CssSelector("strong")).GetAttribute("ng-if") ??
                Driver.FindElement(shippingValue).FindElement(By.CssSelector("span")).GetAttribute("ng-if");

            var shippingText = shipping.Equals("cart.shippingAndHandling.success")
                ? Driver.FindElement(shippingValue).FindElement(By.CssSelector("span>strong")).Text.Replace("$", "")
                : Driver.FindElement(shippingValue).FindElement(By.CssSelector("strong")).Text;

            return shippingText;
        }

        public bool IsShippingFreeOrUnavailable()
        {
            WaitForAllAjaxRequestToFinish();
            var shipping =
                Driver.FindElement(shippingValue).FindElement(By.CssSelector("strong")).GetAttribute("ng-if") ??
                Driver.FindElement(shippingValue).FindElement(By.CssSelector("span")).GetAttribute("ng-if");

            var shippingText = shipping.Equals("cart.shippingAndHandling.success")
                ? Driver.FindElement(shippingValue).FindElement(By.CssSelector("span>strong")).Text
                : Driver.FindElement(shippingValue).FindElement(By.CssSelector("strong")).Text;

            return shippingText.Equals("$0.00") || shippingText.Equals(Shipping.FREE) || shippingText.Equals(Shipping.Unavailable);
        }

        public void AddProductsToCart(Table table)
        {
            var materials = table.CreateSet<MaterialDetails>();
            foreach (var material in materials)
            {
                for (var i = 0; i < 5; i++)
                {
                    var materialList = Driver.FindElements(materialNumberInputs);
                    var quantityList = Driver.FindElements(quantityInputs);

                    materialList[i].SendKeys(material.MaterialNumber.ToString());
                    quantityList[i].SendKeys(material.Quantity.ToString());
                }
            }
            ActionClick(addToCArtButton);
        }
    }
}
