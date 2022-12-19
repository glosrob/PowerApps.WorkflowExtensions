using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Maths
{
    /// <summary>
    /// Adds two doubles.
    /// </summary>
    public class AddDoubles : CodeActivity
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
        /// Gets or sets the outcome of adding the numbers.
        /// </summary>
        [Output("Result")]
        public OutArgument<double> Result { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        protected override void Execute(CodeActivityContext context)
        {
            var first = context.GetValue(FirstDouble);
            var second = context.GetValue(SecondDouble);
            var result = first + second;
            Result.Set(context, result);
        }
    }
}
