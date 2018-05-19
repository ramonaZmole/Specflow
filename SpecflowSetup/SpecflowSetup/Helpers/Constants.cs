namespace SpecflowSetup.Helpers
{
    public static class Constants
    {
        public static string CartUrl = "https://www.northernsafety-dev.com/Cart";
        public static string EmptyCartMessage = "Your Shopping Cart is Empty";
        public static string ZipCode = "73001";
    }

    public enum Shipping
    {
        FREE,
        Unavailable
    }
}
