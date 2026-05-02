using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Text
{
    /// <summary>
    /// Replaces all occurences of some text.
    /// </summary>
    public class Replace : WorkflowServiceBase
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
        /// Implements the business logic for this workflow step.
        /// </summary>
        /// <param name="worker">Helper for accessing common workflow services.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var text = worker.ActivityContext.GetValue(Source);
            var find = worker.ActivityContext.GetValue(Find);
            var replace = worker.ActivityContext.GetValue(ReplaceWith);
            var output = worker.Text.Replace(text, find, replace);
            worker.ActivityContext.SetValue(Output, output);
        }
    }
}
