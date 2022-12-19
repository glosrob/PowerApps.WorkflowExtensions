using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Calendar
{
    /// <summary>
    /// Converts a number of minutes to a number of hours.
    /// </summary>
    public class ConvertMinsToHours : CodeActivity
    {
        //Properties

        /// <summary>
        /// Gets or sets the number of minutes
        /// </summary>
        [RequiredArgument]
        [Input("Minutes")]
        public InArgument<int> Duration { get; set; }

        /// <summary>
        /// Gets or sets the duration as a number of hours.
        /// </summary>
        [Output("Hours")]
        public OutArgument<decimal> Hours { get; set; }

        private const int MINS_PER_HOUR = 60;

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        protected override void Execute(CodeActivityContext context)
        {
            var duration = context.GetValue(Duration);
            var result = (decimal)duration / MINS_PER_HOUR;
            Hours.Set(context, result);
        }
    }
}
