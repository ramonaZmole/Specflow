using TechTalk.SpecFlow;

namespace External
{
    [Binding]
    public class CartStep
    {
        [Given(@"the user is in cart")]
        public void GivenTheUserIsInCart()
        {
            //_cartPage.NavigateTo(Constants.CartUrl);
        }
    }
}
