using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Calendar
{
    /// <summary>
    /// Returns a string representing the provided date/time.
    /// </summary>
    public class FormatDateTime : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the date/time to be converted to text.
        /// </summary>
        [Input("Date")]
        [RequiredArgument]
        public InArgument<DateTime> DateTime { get; set; }

        /// <summary>
        /// Gets or sets the format to use to output the date/time.
        /// </summary>
        [Input("Format [default: d[q] MMMM yyyy e.g. 3rd October 2020]")]
        public InArgument<string> Format { get; set; }

        /// <summary>
        /// Gets or sets the outputted date.
        /// </summary>
        [Output("Formatted Date")]
        public OutArgument<string> FormattedDate { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic for this workflow step.
        /// </summary>
        /// <param name="worker">Helper for accessing common workflow services.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var format = Format.Get(worker.ActivityContext);
            var dt = DateTime.Get(worker.ActivityContext);
            var formattedDt = worker.Calendar.FormatDateTime(dt, format);
            FormattedDate.Set(worker.ActivityContext, formattedDt);
        }
    }
}
