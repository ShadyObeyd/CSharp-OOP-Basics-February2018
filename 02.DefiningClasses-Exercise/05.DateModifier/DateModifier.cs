using System;
using System.Globalization;

public class DateModifier
{
    public int CalculateDifference(string firstDate, string secondDate)
    {
        DateTime firstDateInput = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime secondDateInput = DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture);

        return Math.Abs((firstDateInput - secondDateInput).Days);
    }
}