using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Calendar
{
    /// <summary>
    /// Converts a number of minutes to a number of hours.
    /// </summary>
    public class ConvertMinsToHours : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the number of minutes.
        /// </summary>
        [RequiredArgument]
        [Input("Minutes")]
        public InArgument<int> Duration { get; set; }

        /// <summary>
        /// Gets or sets the duration as a number of hours.
        /// </summary>
        [Output("Hours")]
        public OutArgument<decimal> Hours { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var duration = worker.ActivityContext.GetValue(Duration);
            var result = worker.Calendar.ConvertMinsToHours(duration);
            Hours.Set(worker.ActivityContext, result);
        }
    }
}
