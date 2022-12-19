using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Maths
{
    /// <summary>
    /// Replaces all occurences of some text.
    /// </summary>
    public class Replace : CodeActivity
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
        /// Gets or sets the text to replace the found text with.
        /// </summary>
        [RequiredArgument]
        [Input("ReplaceWith")]
        public InArgument<string> ReplaceWith { get; set; }

        /// <summary>
        /// Gets or sets the text with all text replaced.
        /// </summary>
        [Output("Output")]
        public OutArgument<string> Output { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        protected override void Execute(CodeActivityContext context)
        {
            var source = context.GetValue(Source);
            var find = context.GetValue(Find);
            var replaceWith = context.GetValue(ReplaceWith);
            var outcome = source.Replace(find, replaceWith);
            Output.Set(context, outcome);
        }
    }
}
