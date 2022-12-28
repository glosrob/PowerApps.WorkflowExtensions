﻿using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Maths
{
    /// <summary>
    /// Divides two doubles.
    /// </summary>
    public class DivideDoubles : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the first double.
        /// </summary>
        [RequiredArgument]
        [Input("First")]
        public InArgument<double> FirstDouble { get; set; }

        /// <summary>
        /// Gets or sets the second double.
        /// </summary>
        [RequiredArgument]
        [Input("Second")]
        public InArgument<double> SecondDouble { get; set; }

        /// <summary>
        /// Gets or sets the outcome of dividing the first number by the second number.
        /// </summary>
        [Output("Result")]
        public OutArgument<double> Result { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var first = worker.ActivityContext.GetValue(FirstDouble);
            var second = worker.ActivityContext.GetValue(SecondDouble);
            var result = worker.Maths.DivideDoubles(first, second);
            Result.Set(worker.ActivityContext, result);
        }
    }
}
