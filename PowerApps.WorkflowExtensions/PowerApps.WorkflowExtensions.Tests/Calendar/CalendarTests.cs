using FakeXrmEasy;
using System;
using System.Collections.Generic;
using System.Globalization;
using PowerApps.WorkflowExtensions.Calendar;
using Xunit;

namespace PowerApps.WorkfowExtensionsTests.Calendar
{
    /// <summary>
    /// Tests the helpers in the calendar namepace.
    /// </summary>
    public class CalendarTests
    {
        /// <summary>
        /// Test that the 'Days Between' helper correctly calculates days between two dates.
        /// </summary>
        [Theory]
        [InlineData("3/12/2019 12:00", "1/12/2019 12:00", 2.0)]
        [InlineData("1/12/2019 12:00", "3/12/2019 12:00", -2.0)]
        [InlineData("3/12/2019 12:00", "3/12/2019 23:59", -0.5)]
        [InlineData("3/12/2019 12:00", "3/12/2019 00:00", 0.5)]
        public void Days_Between_Calculates_Correctly(string first, string second, double expectedDays)
        {
            //Arrange
            var firstDate = DateTime.ParseExact(first, "d/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            var secondDate = DateTime.ParseExact(second, "d/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            var fakedContext = new XrmFakedContext();
            var inputs = new Dictionary<string, object>()
            {
                { "FirstDate", firstDate },
                { "SecondDate", secondDate }
            };

            //Act
            var result = fakedContext.ExecuteCodeActivity<DaysBetween>(inputs);

            //Assert
            Assert.Equal(expectedDays, Math.Round((double)result["Result"], 2));
        }

        /// <summary>
        /// Test that the 'ConvertMinsToHours' helper correctly calculates minutes into hours.
        /// </summary>
        [Theory]
        [InlineData(90, 1.5)]
        [InlineData(60, 1.0)]
        [InlineData(180, 3.0)]
        [InlineData(30, 0.5)]
        public void Convert_Mins_To_Hours_Calculates_Correctly(int mins, decimal expectedHours)
        {
            //Arrange
            var fakedContext = new XrmFakedContext();
            var inputs = new Dictionary<string, object>()
            {
                { "Duration", mins }
            };

            //Act
            var result = fakedContext.ExecuteCodeActivity<ConvertMinsToHours>(inputs);

            //Assert
            Assert.Equal(expectedHours, Math.Round((decimal)result["Hours"], 2));
        }
    }
}
