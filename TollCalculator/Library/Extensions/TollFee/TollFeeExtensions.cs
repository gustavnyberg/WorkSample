namespace TollCalculator.Library.Extensions.TollFee;

public static class TollFeeExtensions
{
    public static bool IsMaxFeePerDate(this int fee) => fee > 60;

    public static int GetMaxFeePerDate() => 60;
}