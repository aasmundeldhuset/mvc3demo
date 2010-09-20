namespace Commons
{
    public static class Utilities
    {
        public static decimal RoundTowardsZeroToTwoDecimals(decimal number)
        {
            return decimal.Truncate(number * 100) / 100;
        }
    }
}
