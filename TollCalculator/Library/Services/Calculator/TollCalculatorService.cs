namespace TollCalculator.Library.Services.Calculator;

using Extensions.TollFee;
using Vehicles.Base;

public class TollCalculatorService
    : ITollCalculatorService
{
public int GetTollFee(IVehicle vehicle, DateTime[] dates)
    {
        var intervalStart = dates[0];
        var totalFee = 0;
        foreach (var date in dates)
        {
            totalFee = CalculateTotalFee(vehicle, date, intervalStart, totalFee);
            intervalStart = date;
        }

        if (totalFee.IsMaxFeePerDay())
            totalFee = TollFeeExtensions.GetMaxFeePerDay();

        return totalFee;
    }

    private static readonly Dictionary<(TimeSpan Start, TimeSpan End), int> TollFees = new()
    {
        {(new TimeSpan(6, 0, 0), new TimeSpan(6, 30, 00)), 8},
        {(new TimeSpan(6, 30, 0), new TimeSpan(7, 00, 00)), 13},
        {(new TimeSpan(7, 0, 0), new TimeSpan(8, 0, 0)), 18},
        {(new TimeSpan(8, 0, 0), new TimeSpan(8, 30, 0)), 13},
        {(new TimeSpan(8, 30, 0), new TimeSpan(15, 0, 0)), 8},
        {(new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0)), 13},
        {(new TimeSpan(15, 30, 0), new TimeSpan(17, 0, 0)), 18},
        {(new TimeSpan(17, 0, 0), new TimeSpan(18, 0, 0)), 13},
        {(new TimeSpan(18, 0, 0), new TimeSpan(18, 30, 0)), 8},
        {(new TimeSpan(18, 30, 0), new TimeSpan(06, 0, 0)), 0}
    };

    private static int CalculateTotalFee(IVehicle vehicle, DateTime date, DateTime intervalStart, int totalFee)
         {
        var nextFee = GetTollFee(date, vehicle);
        var tempFee = GetTollFee(intervalStart, vehicle);
        
        var minutes = CalculateTimeDifferenceInMinutes(date, intervalStart);
        totalFee = UpdateTotalFee(totalFee, tempFee, nextFee, minutes);
        return totalFee;
    }

    private static long CalculateTimeDifferenceInMinutes(DateTime date, DateTime intervalStart)
    {
        var difference = date - intervalStart;
        return (long)difference.TotalMinutes;
    }

    private static int UpdateTotalFee(int totalFee, int tempFee, int nextFee, long minutes)
    {
        if(minutes > 60)
            totalFee += nextFee;

        else
        {
            if (totalFee > 0)
                totalFee -= tempFee;

            if (nextFee >= tempFee)
                tempFee = nextFee;

            totalFee += tempFee;
        }

        return totalFee;
    }

    private static int GetTollFee(DateTime dateTime, IVehicle vehicle)
    {
        var date = DateOnly.FromDateTime(dateTime);
        if (date.IsTollFree() || vehicle.IsTollFree())
            return 0;
        var time = dateTime.TimeOfDay;
        return CalculateTollFee(time);
    }
    
    private static int CalculateTollFee(TimeSpan time)
        => TollFees
            .Where(tollFee => time >= tollFee.Key.Start && time < tollFee.Key.End)
            .Select(tollFee => tollFee.Value).SingleOrDefault();
}