using System;
using TechTalk.SpecFlow;

namespace SpecflowSetup.Steps
{
    [Binding]
    public class CartFeatureSteps
    {
        [Given(@"the user is in cart")]
        public void GivenTheUserIsInCart()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"there is product (.*) with quantity (.*) in cart")]
        public void GivenThereIsProductWithQuantityInCart(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"there are the following products in cart")]
        public void GivenThereAreTheFollowingProductsInCart(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"there is (.*) with (.*) in cart")]
        public void GivenThereIsWithInCart(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the user removes the product from cart")]
        public void WhenTheUserRemovesTheProductFromCart()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the user apply a zip code")]
        public void WhenTheUserApplyAZipCode()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the user select Empty cart link")]
        public void WhenTheUserSelectEmptyCartLink()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the cart gets empty")]
        public void ThenTheCartGetsEmpty()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the shipping is not free")]
        public void ThenTheShippingIsNotFree()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the shipping is free")]
        public void ThenTheShippingIsFree()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the shipping is unavailable")]
        public void ThenTheShippingIsUnavailable()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
