using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Maths
{
    /// <summary>
    /// Divides two integers.
    /// </summary>
    public class DivideIntegers : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the first integer.
        /// </summary>
        [RequiredArgument]
        [Input("First")]
        public InArgument<int> FirstInteger { get; set; }

        /// <summary>
        /// Gets or sets the second integer.
        /// </summary>
        [RequiredArgument]
        [Input("Second")]
        public InArgument<int> SecondInteger { get; set; }

        /// <summary>
        /// Gets or sets the outcome of dividing the first number by the second number.
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
            var result = worker.Maths.DivideIntegers(first, second);
            Result.Set(worker.ActivityContext, result);
        }
    }
}
