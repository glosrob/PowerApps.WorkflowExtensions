using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Calendar
{
    /// <summary>
    /// Adds an amount of time to a date.
    /// </summary>
    public class AddToDate : WorkflowServiceBase
    {
        // Properties

        /// <summary>
        /// Gets or sets the date/time to add to.
        /// </summary>
        [Input("Date")]
        [RequiredArgument]
        public InArgument<DateTime> DateTime { get; set; }

        /// <summary>
        /// Gets or sets the unit of time to be added.
        /// </summary>
        [Input("Unit [Seconds, Minutes, Hours, Days]")]
        [RequiredArgument]
        public InArgument<string> Unit { get; set; }

        /// <summary>
        /// Gets or sets the amount of time to be added.
        /// </summary>
        [Input("Amount")]
        [RequiredArgument]
        public InArgument<double> Amount { get; set; }

        /// <summary>
        /// Gets or sets the date/time with time added.
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
            var dt = worker.ActivityContext.GetValue(DateTime);
            var unit = worker.ActivityContext.GetValue(Unit);
            var amount = worker.ActivityContext.GetValue(Amount);

            var newDt = worker.Calendar.AddToDate(dt, unit, amount);
            NewDateTime.Set(worker.ActivityContext, newDt);
        }
    }
}
