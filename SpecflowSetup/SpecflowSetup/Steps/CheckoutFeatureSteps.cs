using NUnit.Framework;
using SpecflowSetup.Helpers;
using SpecflowSetup.Pages;
using TechTalk.SpecFlow;

namespace SpecflowSetup.Steps
{
    [Binding]
    public class CheckoutFeatureSteps : TechTalk.SpecFlow.Steps
    {
        private readonly CheckoutPage _checkoutPage = AbstractPage.CheckoutPage;

        [Given(@"the user goes to checkout")]
        public void GivenTheUserIsInChekout()
        {
            _checkoutPage.NavigateTo(Constants.CheckoutUrl);
            _checkoutPage.Login();
        }

        [When(@"the user apply a priority code")]
        [Scope(Feature = "CheckoutFeature")]
        public void WhenTheUserApplyAPriorityCode()
        {
            _checkoutPage.ApplyPriorityCode();
        }

        [Then(@"the discount is present")]
        [Scope(Feature = "CheckoutFeature")]
        public void ThenTheDiscountIsPresent()
        {
            var isDisplayed = _checkoutPage.IsDiscountDisplayed();
            Assert.AreEqual(isDisplayed, true);
        }
    }
}
