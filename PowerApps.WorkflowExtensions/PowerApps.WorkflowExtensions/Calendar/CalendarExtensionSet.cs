using System;

namespace PowerApps.WorkflowExtensions.Calendar
{
    public class CalendarExtensionSet : BaseExtensionSet
    {
        // Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="worker">The worker for this collection of workflow extensions.</param>
        public CalendarExtensionSet(WorkflowHelper worker): base(worker)
        {

        }

        // Workflows

        /// <summary>
        /// Formats a date by the given date format.
        /// </summary>
        /// <param name="dt">The date/time to be formatted.</param>
        /// <param name="format">The format to apply to the given date/time.</param>
        /// <returns>The formatted date/time.</returns>
        public string FormatDateTime(DateTime dt, string format)
        {
            format = string.IsNullOrEmpty(format) ? "d[q] MMMM yyyy" : format;

            var rob = dt.ToString("");

            var ordinal = string.Empty;
            if (format.Contains("[q]"))
            {
                var day = dt.Day;
                if (day == 1 || day == 21 || day == 31)
                {
                    ordinal = "st";
                }
                else if (day == 2 || day == 22)
                {
                    ordinal = "nd";
                }
                else if (day == 3 || day == 23)
                {
                    ordinal = "rd";
                }
                else
                {
                    ordinal = "th";
                }
            };
            var dtStr = dt.ToString(format);
            dtStr = dtStr.Replace("[q]", ordinal);
            return dtStr;
        }

        /// <summary>
        /// Returns the number of days between two dates.
        /// </summary>
        /// <param name="first">The first date to compare.</param>
        /// <param name="second">The second date to compare.</param>
        /// <returns>The number of days between the two dates.</returns>
        public double DaysBetween(DateTime first, DateTime second)
        {
            var diff = first.Subtract(second);
            return Math.Round(diff.TotalDays, 2);
        }

        /// <summary>
        /// Adds an amount of time to a date.
        /// </summary>
        /// <param name="dt">Gets or sets the date/time to add to.</param>
        /// <param name="unit">Gets or sets the unit of time to be added.</param>
        /// <param name="amount">Gets or sets the amount of time to be added.</param>
        /// <returns>The new date with the amount of time added on.</returns>
        public DateTime AddToDate(DateTime dt, string unit, double amount)
        {
            switch (unit)
            {
                case "Seconds":
                    var secondsTs = TimeSpan.FromSeconds(amount);
                    dt = dt.Add(secondsTs);
                    break;

                case "Minutes":
                    var minsTs = TimeSpan.FromMinutes(amount);
                    dt = dt.Add(minsTs);
                    break;

                case "Hours":
                    var hoursTs = TimeSpan.FromHours(amount);
                    dt = dt.Add(hoursTs);
                    break;

                case "Days":
                    var daysTs = TimeSpan.FromDays(amount);
                    dt = dt.Add(daysTs);
                    break;
            }
            return dt;
        }

        /// <summary>
        /// Subtracts an amount of time from a date.
        /// </summary>
        /// <param name="dt">Gets or sets the date/time to subtract from.</param>
        /// <param name="unit">Gets or sets the unit of time to be subtracted.</param>
        /// <param name="amount">Gets or sets the amount of time to be subtracted.</param>
        /// <returns>The new date with the amount of time subtracted.</returns>
        public DateTime SubtractFromDate(DateTime dt, string unit, double amount)
        {
            switch (unit)
            {
                case "Seconds":
                    var secondsTs = TimeSpan.FromSeconds(amount);
                    dt = dt.Subtract(secondsTs);
                    break;

                case "Minutes":
                    var minsTs = TimeSpan.FromMinutes(amount);
                    dt = dt.Subtract(minsTs);
                    break;

                case "Hours":
                    var hoursTs = TimeSpan.FromHours(amount);
                    dt = dt.Subtract(hoursTs);
                    break;

                case "Days":
                    var daysTs = TimeSpan.FromDays(amount);
                    dt = dt.Subtract(daysTs);
                    break;
            }
            return dt;
        }

        /// <summary>
        /// Converts a number of minutes to a number of hours.
        /// </summary>
        /// <param name="mins">The number of minutes to convert.</param>
        /// <returns>The number of minutes as hours.</returns>
        public decimal ConvertMinsToHours(int mins)
        {
            int MINS_PER_HOUR = 60;
            var result = (decimal)mins / MINS_PER_HOUR;
            return result;
        }

        /// <summary>
        /// Returns the day of the week for a given date/time.
        /// </summary>
        /// <param name="date">The date/time to retrieve the day of the week for.</param>
        /// <returns>The day of the week for a given date/time.</returns>
        public string DayOfTheWeek(DateTime date)
        {
            return Enum.GetName(typeof(DayOfWeek), date.DayOfWeek);
        }

    }
}
