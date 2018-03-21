using System;
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
    }
}
