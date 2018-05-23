using OpenQA.Selenium;

namespace SpecflowSetup.Helpers
{
    public static class Constants
    {
        public static string CartUrl = "https://www.northernsafety-dev.com/Cart";
        public static string EmptyCartMessage = "Your Shopping Cart is Empty";
        public static string ZipCode = "73001";
        public static string CheckoutUrl = "https://www.northernsafety-dev.com/Checkout";
        public static string Password = "www123";
        public static string PriorityCode = "25OFFANY";
    }

    public enum Shipping
    {
        FREE,
        Unavailable
    }
}
