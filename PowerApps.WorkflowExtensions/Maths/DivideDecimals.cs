using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Maths
{
    /// <summary>
    /// Divides two decimals.
    /// </summary>
    public class DivideDecimals : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the first decimal.
        /// </summary>
        [RequiredArgument]
        [Input("First")]
        public InArgument<decimal> FirstDecimal { get; set; }

        /// <summary>
        /// Gets or sets the second decimal.
        /// </summary>
        [RequiredArgument]
        [Input("Second")]
        public InArgument<decimal> SecondDecimal { get; set; }

        /// <summary>
        /// Gets or sets the outcome of dividing the first number by the second number.
        /// </summary>
        [Output("Result")]
        public OutArgument<decimal> Result { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var first = worker.ActivityContext.GetValue(FirstDecimal);
            var second = worker.ActivityContext.GetValue(SecondDecimal);
            var result = worker.Maths.DivideDecimals(first, second);
            Result.Set(worker.ActivityContext, result);
        }
    }
}
