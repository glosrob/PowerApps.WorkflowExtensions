using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Maths
{
    /// <summary>
    /// Adds two integers.
    /// </summary>
    public class AddIntegers : CodeActivity
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
        /// Gets or sets the outcome of adding the numbers.
        /// </summary>
        [Output("Result")]
        public OutArgument<int> Result { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        protected override void Execute(CodeActivityContext context)
        {
            var first = context.GetValue(FirstInteger);
            var second = context.GetValue(SecondInteger);
            var result = first + second;
            Result.Set(context, result);
        }
    }
}
