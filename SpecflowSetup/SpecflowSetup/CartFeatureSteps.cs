using TechTalk.SpecFlow;

namespace SpecflowSetup
{
    [Binding]
    public class CartFeatureSteps
    {
        [Given]
        public void GivenTheUserIsInCart()
        {
            ScenarioContext.Current.Pending();
        }

        [Given]
        public void GivenThereIsProduct_MATERIALNUMBER_WithQuantity_QUANTITY_InCart(string materialNumber, int quantity)
        {
            ScenarioContext.Current.Pending();
        }


        [Then]
        public void ThenTheShippingIsUnavailable()
        {
            ScenarioContext.Current.Pending();
        }

        [When]
        public void WhenTheUserApplyAZipCode()
        {
            ScenarioContext.Current.Pending();
        }

        [Then]
        public void ThenTheShippingIsNotFree()
        {
            ScenarioContext.Current.Pending();
        }

        [Given]
        public void GivenThereAreTheFollowingProductsInCart(Table table)
        {
            foreach (var row in table.Rows)
            {
                foreach (var val in row)
                {

                }
            }
        }

        [When]
        public void WhenTheUserSelectEmptyCartLink()
        {
            ScenarioContext.Current.Pending();
        }

        [When]
        public void WhenTheUserRemovesTheProductFromCart()
        {
            ScenarioContext.Current.Pending();
        }

        [Then]
        public void ThenTheCartGetsEmpty()
        {
            ScenarioContext.Current.Pending();
        }

        [Then]
        public void ThenTheShippingIsFree()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
