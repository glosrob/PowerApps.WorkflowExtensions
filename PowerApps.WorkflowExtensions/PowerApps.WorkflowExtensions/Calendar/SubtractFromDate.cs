using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Calendar
{
    /// <summary>
    /// Subtracts an amount of time from a date.
    /// </summary>
    public class SubtractFromDate : WorkflowServiceBase
    {
        // Properties

        /// <summary>
        /// Gets or sets the date/time to subtract from.
        /// </summary>
        [Input("Date")]
        [RequiredArgument]
        public InArgument<DateTime> DateTime { get; set; }

        /// <summary>
        /// Gets or sets the unit of time to be subtracted.
        /// </summary>
        [Input("Unit [Seconds, Minutes, Hours, Days]")]
        [RequiredArgument]
        public InArgument<string> Unit { get; set; }

        /// <summary>
        /// Gets or sets the amount of time to be subtracted.
        /// </summary>
        [Input("Amount")]
        [RequiredArgument]
        public InArgument<double> Amount { get; set; }

        /// <summary>
        /// Gets or sets the date/time with time subtracted.
        /// </summary>
        [Output("Date")]
        public OutArgument<DateTime> NewDateTime { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var dt = DateTime.Get(worker.ActivityContext);
            var unit = Unit.Get(worker.ActivityContext);
            var amount = Amount.Get(worker.ActivityContext);
            var newDt = worker.Calendar.SubtractFromDate(dt, unit, amount);
            NewDateTime.Set(worker.ActivityContext, newDt);
        }
    }
}
