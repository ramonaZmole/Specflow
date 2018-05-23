using NUnit.Framework;
using SpecflowSetup.Helpers;
using SpecflowSetup.Pages;
using TechTalk.SpecFlow;

namespace SpecflowSetup.Steps
{
    [Binding]
    public class CartFeatureSteps : TechTalk.SpecFlow.Steps
    {
        private readonly CartPage _cartPage = AbstractPage.CartPage;

        [Given(@"the user is in cart")]
        public void GivenTheUserIsInCart()
        {
            _cartPage.NavigateTo(Constants.CartUrl);
        }

        [Given(@"there is product (.*) with quantity (.*) in cart")]
        [Given(@"there is (.*) with (.*) in cart")]
        public void GivenThereIsProductWithQuantityInCart(int sku, int quantity)
        {
            _cartPage.AddProductInCart(sku, quantity);
        }

        [Given(@"there are the following products in cart")]
        public void GivenThereAreTheFollowingProductsInCart(Table table)
        {
            _cartPage.AddProductsToCart(table);
        }

        [When(@"the user removes the product from cart")]
        public void WhenTheUserRemovesTheProductFromCart()
        {
            _cartPage.RemoveProductFromCart();
        }

        [When(@"the user apply a zip code")]
        public void WhenTheUserApplyAZipCode()
        {
            _cartPage.ApplyZipCode();
        }

        [When(@"the user select Empty cart link")]
        public void WhenTheUserSelectEmptyCartLink()
        {
            _cartPage.ClickEmptyCartLink();
        }

        [Then(@"the cart gets empty")]
        public void ThenTheCartGetsEmpty()
        {
            var actualMessage = _cartPage.GetEmptyCartMessage();
            Assert.AreEqual(Constants.EmptyCartMessage, actualMessage);
        }

        [Then(@"the shipping is not free")]
        public void ThenTheShippingIsNotFree()
        {
            var actualShipping = _cartPage.GetShipping();
            Assert.AreNotEqual(Shipping.FREE, actualShipping);
        }

        [Then(@"the shipping is free")]
        public void ThenTheShippingIsFree()
        {
            var actualShipping = _cartPage.GetShipping();
            Assert.AreEqual(Shipping.FREE.ToString(), actualShipping);
        }

        [Then(@"the shipping is unavailable")]
        public void ThenTheShippingIsUnavailable()
        {
            var actualShipping = _cartPage.GetShipping();
            Assert.AreEqual(Shipping.Unavailable.ToString(), actualShipping);
        }

        [Then(@"shipping is (.*)")]
        public void ThenTheShippingIs(string shipping)
        {
            var actualShipping = _cartPage.GetShipping();
            Assert.AreEqual(actualShipping, shipping);
        }

        [Given(@"I have material (.*) with quantity (.*)")]
        public void GivenIHaveMaterialWithQuantity(int sku, int quantity)
        {
            Given($"there is product {sku} with quantity {quantity} in cart");
            When("the user apply a zip code");
        }

        [When(@"the user apply a priority code")]
        public void WhenTheUserApplyAPriorityCode()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the discount is present")]
        public void ThenTheDiscountIsPresent()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
