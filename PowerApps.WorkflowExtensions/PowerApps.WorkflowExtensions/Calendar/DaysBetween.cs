using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Calendar
{
    /// <summary>
    /// Returns the number of days between two dates.
    /// </summary>
    public class DaysBetween : CodeActivity
    {
        //Properties

        /// <summary>
        /// Gets or sets the first date.
        /// </summary>
        [RequiredArgument]
        [Input("First Date")]
        public InArgument<DateTime> FirstDate { get; set; }

        /// <summary>
        /// Gets or sets the second date.
        /// </summary>
        [RequiredArgument]
        [Input("Second Date")]
        public InArgument<DateTime> SecondDate { get; set; }

        /// <summary>
        /// Gets or sets the number of days between the two dates.
        /// </summary>
        [Output("Days")]
        public OutArgument<double> Result { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        protected override void Execute(CodeActivityContext context)
        {
            var firstDate = context.GetValue(FirstDate);
            var secondDate = context.GetValue(SecondDate);
            var diff = firstDate.Subtract(secondDate);
            Result.Set(context, Math.Round(diff.TotalDays, 2));
        }
    }
}
