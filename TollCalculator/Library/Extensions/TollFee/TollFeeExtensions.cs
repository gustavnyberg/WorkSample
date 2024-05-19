namespace TollCalculator.Library.Extensions.TollFee;

public static class TollFeeExtensions
{
    public static bool IsMaxFeePerDay(this int fee) => fee > 60;

    public static int GetMaxFeePerDay() => 60;
}