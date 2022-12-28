using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Maths
{
    /// <summary>
    /// Subtracts two integers.
    /// </summary>
    public class SubtractIntegers : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the first integer.
        /// </summary>
        [RequiredArgument]
        [Input("First")]
        public InArgument<int> FirstInteger { get; set; }

        /// <summary>
        /// Gets or sets the second integer. This number will be subtracted from the first number.
        /// </summary>
        [RequiredArgument]
        [Input("Second")]
        public InArgument<int> SecondInteger { get; set; }

        /// <summary>
        /// Gets or sets the outcome of subtracting the second number from the first number.
        /// </summary>
        [Output("Result")]
        public OutArgument<int> Result { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var first = worker.ActivityContext.GetValue(FirstInteger);
            var second = worker.ActivityContext.GetValue(SecondInteger);
            var result = worker.Maths.SubtractIntegers(first, second);
            Result.Set(worker.ActivityContext, result);
        }
    }
}
