using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Calendar
{
    /// <summary>
    /// Gets the day of the week for a given date.
    /// </summary>
    public class DayOfTheWeek : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the date to find the day of the week for.
        /// </summary>
        [RequiredArgument]
        [Input("Date")]
        public InArgument<DateTime> Date { get; set; }

        /// <summary>
        /// Gets or sets the day of the week.
        /// </summary>
        [Output("Day of the Week")]
        public OutArgument<string> DayWeek { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var date = worker.ActivityContext.GetValue(Date);
            var dayWeek = worker.Calendar.DayOfTheWeek(date);
            DayWeek.Set(worker.ActivityContext, dayWeek);
        }
    }
}
