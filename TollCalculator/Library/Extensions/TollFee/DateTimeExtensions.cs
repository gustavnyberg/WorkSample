namespace TollCalculator.Library.Extensions.TollFee;

using System;
using System.Collections.Generic;

public static class TollFeeDateTimeExtensions
{
    private static readonly HashSet<DateTime> TollFreeDates;

    static TollFeeDateTimeExtensions()
    {
        TollFreeDates = GetTollFreeDates();
    }

    /// <summary>
    /// Checks if a date is toll-free.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <returns>True if the date is toll-free, false otherwise.</returns>
    public static bool IsTollFree(this DateTime date) =>
        IsWeekend(date) || date.IsFixedTollFreeDate();

    /// <summary>
    /// Checks if a date falls on a weekend.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <returns>True if the date is a Saturday or Sunday, false otherwise.</returns>
    private static bool IsWeekend(DateTime date) =>
        date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

    /// <summary>
    /// Checks if a date is a fixed toll-free date.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <returns>True if the date is a fixed toll-free date, false otherwise.</returns>
    public static bool IsFixedTollFreeDate(this DateTime date) =>
        TollFreeDates.Contains(date);

    /// <summary>
    /// Creates the set of toll-free dates.
    /// </summary>
    /// <returns>A HashSet of toll-free dates.</returns>
    private static HashSet<DateTime> GetTollFreeDates()
    {
        var tollFreeDates = new HashSet<DateTime>
        {
            // Specific toll-free dates
            new(2013, 1, 1),
            new(2013, 3, 28),
            new(2013, 3, 29),
            new(2013, 4, 1),
            new(2013, 4, 30),
            new(2013, 5, 1),
            new(2013, 5, 8),
            new(2013, 5, 9),
            new(2013, 6, 5),
            new(2013, 6, 6),
            new(2013, 6, 21),
            new(2013, 11, 1),
            new(2013, 12, 24),
            new(2013, 12, 25),
            new(2013, 12, 26),
            new(2013, 12, 31)
        };
        
        // All dates in July
        AddAllDatesInJulyTo(tollFreeDates);
        return tollFreeDates;
    }
    /// <summary>
    /// Adds all dates in July to the set of toll-free dates.
    /// </summary>
    /// <param name="dates">The set of toll-free dates.</param>
    private static void AddAllDatesInJulyTo(HashSet<DateTime> dates)
    {
        for (var day = 1; day <= 31; day++)
            dates.Add(new DateTime(2013, 7, day));
    }
}