using PowerApps.WorkflowExtensions.Calendar;
using System;
using System.Collections.Generic;
using Xunit;

namespace PowerApps.WorkflowExtensions.Tests
{
    /// <summary>
    /// Tests the helpers in the calendar namepace.
    /// </summary>
    public class CalendarTests
    {
        [Theory]
        [InlineData("01/12/2022 12:30", "d[q] MMMM yy", "1st December 22")]
        [InlineData("2/12/2022 19:30", "d[q] MMMM yy HH:mm:ss", "2nd December 22 19:30:00")]
        [InlineData("2/12/2022 19:30", "d MMMM yyyy HH:mm:ss", "2 December 2022 19:30:00")]
        [InlineData("3/12/2022 12:30", "d[q] MMMM yyyy", "3rd December 2022")]
        [InlineData("4/12/2022 12:30", "dd[q] MMM yyyy", "04th Dec 2022")]
        [InlineData("5/12/2022 12:30", "", "5th December 2022")]
        public void FormatDateTime(string date, string format, string expected)
        {
            // Arrange
            var dateTime = DateTime.Parse(date);
            var inputs = new Dictionary<string, object>
            {
                { "DateTime", dateTime },
                { "Format", format }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<FormatDateTime>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["FormattedDate"]);
        }

        [Theory]
        [InlineData("01/12/2022", "01/12/2022", 0.0)]
        [InlineData("01/12/2022", "08/12/2022", 7.0)]
        [InlineData("01/12/2022", "03/12/2022", 2.0)]
        [InlineData("01/12/2022 12:00", "03/12/2022 12:00", 2.0)]
        [InlineData("01/12/2022 00:00", "03/12/2022 12:00", 2.5)]
        public void DaysBetween(string date1str, string date2str, double days)
        {
            // Arrange
            var date1 = DateTime.Parse(date1str);
            var date2 = DateTime.Parse(date2str);
            var inputs = new Dictionary<string, object>
            {
                { "FirstDate", date1 },
                { "SecondDate", date2 }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<DaysBetween>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(days, double.Parse(outputs["Result"].ToString()));
        }

        [Theory]
        [InlineData(60, 1.0D)]
        [InlineData(120, 2.0D)]
        [InlineData(30, 0.5D)]
        [InlineData(150, 2.5D)]
        public void ConvertMinsToHours(int mins, decimal hours)
        {
            // Arrange
            var builder = new WorkflowTestBuilder();
            builder.Setup<ConvertMinsToHours>();
            var inputs = new Dictionary<string, object>
            {
                { "Duration", mins }
            };

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(hours, decimal.Parse(outputs["Hours"].ToString()));
        }

        [Theory]
        [InlineData("26/12/2022", "Monday")]
        [InlineData("27/12/2022", "Tuesday")]
        [InlineData("28/12/2022", "Wednesday")]
        [InlineData("29/12/2022", "Thursday")]
        [InlineData("30/12/2022", "Friday")]
        [InlineData("31/12/2022", "Saturday")]
        [InlineData("01/01/2023", "Sunday")]
        public void DayOfTheWeek(string date, string day)
        {
            // Arrange
            var builder = new WorkflowTestBuilder();
            builder.Setup<DayOfTheWeek>();
            var inputs = new Dictionary<string, object>
            {
                { "Date", DateTime.Parse(date) }
            };

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(day, outputs["DayWeek"]);
        }

        [Theory]
        [InlineData("26/12/2022 23:59:58", "Seconds", 1.0, "26/12/2022 23:59:59")]
        [InlineData("26/12/2022 23:59:59", "Seconds", 10.0, "27/12/2022 00:00:09")]
        [InlineData("26/12/2022 23:00:00", "Minutes", 15.0, "26/12/2022 23:15:00")]
        [InlineData("26/12/2022 23:00:00", "Minutes", 5.5, "26/12/2022 23:05:30")]
        [InlineData("26/12/2022 23:00:00", "Hours", 36.0, "28/12/2022 11:00:00")]
        [InlineData("26/12/2022 23:00:00", "Hours", 12.5, "27/12/2022 11:30:00")]
        [InlineData("26/12/2022 23:00:00", "Days", 1.0, "27/12/2022 23:00:00")]
        [InlineData("26/12/2022 23:00:00", "Days", 1.5, "28/12/2022 11:00:00")]
        public void AddToDate(string date, string unit, double amount, string expected)
        {
            // Arrange
            var builder = new WorkflowTestBuilder();
            builder.Setup<AddToDate>();
            var expectedDate = DateTime.Parse(expected);
            var inputs = new Dictionary<string, object>
            {
                { "DateTime", DateTime.Parse(date) },
                { "Unit", unit },
                { "Amount", amount }
            };

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expectedDate, DateTime.Parse(outputs["NewDateTime"].ToString()));
        }

        [Theory]
        [InlineData("26/12/2022 23:59:58", "Seconds", 1.0, "26/12/2022 23:59:57")]
        [InlineData("26/12/2022 23:59:59", "Seconds", 10.0, "26/12/2022 23:59:49")]
        [InlineData("26/12/2022 23:00:00", "Minutes", 15.0, "26/12/2022 22:45:00")]
        [InlineData("26/12/2022 23:00:00", "Minutes", 5.5, "26/12/2022 22:54:30")]
        [InlineData("26/12/2022 23:00:00", "Hours", 36.0, "25/12/2022 11:00:00")]
        [InlineData("26/12/2022 23:00:00", "Hours", 12.5, "26/12/2022 10:30:00")]
        [InlineData("26/12/2022 23:00:00", "Days", 1.0, "25/12/2022 23:00:00")]
        [InlineData("26/12/2022 23:00:00", "Days", 1.5, "25/12/2022 11:00:00")]
        public void SubtractFromDate(string date, string unit, double amount, string expected)
        {
            // Arrange
            var builder = new WorkflowTestBuilder();
            builder.Setup<SubtractFromDate>();
            var expectedDate = DateTime.Parse(expected);
            var inputs = new Dictionary<string, object>
            {
                { "DateTime", DateTime.Parse(date) },
                { "Unit", unit },
                { "Amount", amount }
            };

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expectedDate, DateTime.Parse(outputs["NewDateTime"].ToString()));
        }
    }
}
