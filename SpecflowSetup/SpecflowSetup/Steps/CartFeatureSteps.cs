using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowSetup.Helpers;
using TechTalk.SpecFlow;

namespace SpecflowSetup.Steps
{
    [Binding]
    public class CartFeatureSteps : AbstractSteps
    {
        public CartFeatureSteps(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        [Given(@"the user is in cart")]
        public void GivenTheUserIsInCart()
        {
            CartPage.NavigateTo(Constants.CartUrl);
        }

        [Given(@"there is product (.*) with quantity (.*) in cart")]
        [Given(@"there is (.*) with (.*) in cart")]
        public void GivenThereIsProductWithQuantityInCart(int sku, int quantity)
        {
            CartPage.AddProductInCart(sku, quantity);
        }

        [Given(@"there are the following products in cart")]
        public void GivenThereAreTheFollowingProductsInCart(Table table)
        {
            CartPage.AddProductsToCart(table);
        }

        //[Given(@"there is (.*) with (.*) in cart")]
        //public void GivenThereIsWithInCart(int sku, int quantity)
        //{

        //}

        [When(@"the user removes the product from cart")]
        public void WhenTheUserRemovesTheProductFromCart()
        {
            CartPage.RemoveProductFromCart();
        }

        [When(@"the user apply a zip code")]
        public void WhenTheUserApplyAZipCode()
        {
            CartPage.ApplyZipCode();
        }

        [When(@"the user select Empty cart link")]
        public void WhenTheUserSelectEmptyCartLink()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the cart gets empty")]
        public void ThenTheCartGetsEmpty()
        {
            var actualMessage = CartPage.GetEmptyCartMessage();
            Assert.AreEqual(Constants.EmptyCartMessage, actualMessage);
        }

        [Then(@"the shipping is not free")]
        public void ThenTheShippingIsNotFree()
        {
            var actualShipping = CartPage.GetShipping();
            Assert.AreNotEqual(Shipping.FREE, actualShipping);
        }

        [Then(@"the shipping is free")]
        public void ThenTheShippingIsFree()
        {
            var actualShipping = CartPage.GetShipping();
            Assert.AreEqual(Shipping.FREE, actualShipping);
        }

        [Then(@"the shipping is unavailable")]
        public void ThenTheShippingIsUnavailable()
        {
            var actualShipping = CartPage.GetShipping();
            Assert.AreEqual(Shipping.Unavailable, actualShipping);
        }

        [Then(@"shipping is (.*)")]
        public void ThenTheShippingIs(string shipping)
        {
            var actualShipping = CartPage.GetShipping();
            Assert.AreEqual(actualShipping, shipping);
        }

    }
}
