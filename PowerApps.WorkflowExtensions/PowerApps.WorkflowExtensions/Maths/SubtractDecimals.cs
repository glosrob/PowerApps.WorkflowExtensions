using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Maths
{
    /// <summary>
    /// Subtracts two decimals.
    /// </summary>
    public class SubtractDecimals : CodeActivity
    {
        //Properties

        /// <summary>
        /// Gets or sets the first decimal.
        /// </summary>
        [RequiredArgument]
        [Input("First")]
        public InArgument<decimal> FirstDecimal { get; set; }

        /// <summary>
        /// Gets or sets the second decimall. This number will be subtracted from the first number.
        /// </summary>
        [RequiredArgument]
        [Input("Second")]
        public InArgument<decimal> SecondDecimal { get; set; }

        /// <summary>
        /// Gets or sets the outcome of subtracting the second number from the first number.
        /// </summary>
        [Output("Result")]
        public OutArgument<decimal> Result { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        protected override void Execute(CodeActivityContext context)
        {
            var first = context.GetValue(FirstDecimal);
            var second = context.GetValue(SecondDecimal);
            var result = first - second;
            Result.Set(context, result);
        }
    }
}
