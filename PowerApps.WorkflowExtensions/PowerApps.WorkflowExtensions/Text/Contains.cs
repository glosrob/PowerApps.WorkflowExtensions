using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Maths
{
    /// <summary>
    /// Whether text contains certain text.
    /// </summary>
    public class Contains : CodeActivity
    {
        //Properties

        /// <summary>
        /// Gets or sets the source text.
        /// </summary>
        [RequiredArgument]
        [Input("Source")]
        public InArgument<string> Source { get; set; }

        /// <summary>
        /// Gets or sets the text to find.
        /// </summary>
        [RequiredArgument]
        [Input("Find")]
        public InArgument<string> Find { get; set; }

        /// <summary>
        /// Gets or sets whether the source contains the text to find.
        /// </summary>
        [Output("Output")]
        public OutArgument<bool> Output { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        protected override void Execute(CodeActivityContext context)
        {
            var source = context.GetValue(Source);
            var find = context.GetValue(Find);
            Output.Set(context, source.Contains(find));
        }
    }
}
