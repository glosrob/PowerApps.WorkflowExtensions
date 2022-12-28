﻿using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Calendar
{
    /// <summary>
    /// Returns the number of days between two dates.
    /// </summary>
    public class DaysBetween : WorkflowServiceBase
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
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var firstDate = worker.ActivityContext.GetValue(FirstDate);
            var secondDate = worker.ActivityContext.GetValue(SecondDate);
            var answer = worker.Calendar.DaysBetween(secondDate, firstDate);
            Result.Set(worker.ActivityContext, answer);
        }
    }
}
