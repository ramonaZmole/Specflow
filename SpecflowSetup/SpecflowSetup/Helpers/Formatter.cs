namespace SpecflowSetup.Helpers
{
    public static class Formatter
    {
        public static string CleanNumber(this string number)
        {
            var result = number.Trim();

            //remove all special chars - non alpha numeric
            result = result.Replace("$", string.Empty);
            result = result.Replace(":", string.Empty);
            result = result.Replace("#", string.Empty);
            result = result.Replace("(", string.Empty);
            result = result.Replace(")", string.Empty);
            result = result.Replace("\"", string.Empty);
            result = result.Replace(",", string.Empty);
            //remove all alpha chars
            result = result.Replace(" ", string.Empty);
            result = result.Replace("/", string.Empty);

            return result;
        }
    }
}
