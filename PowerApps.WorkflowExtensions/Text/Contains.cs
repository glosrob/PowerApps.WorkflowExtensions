using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Text
{
    /// <summary>
    /// Whether text contains certain text.
    /// </summary>
    public class Contains : WorkflowServiceBase
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
        /// Gets or sets whether the to ignore casing.
        /// </summary>
        [Input("Ignore Case?")]
        public InArgument<bool> IgnoreCase { get; set; }

        /// <summary>
        /// Gets or sets whether the source contains the text to find.
        /// </summary>
        [Output("Output")]
        public OutArgument<bool> Output { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic for this workflow step.
        /// </summary>
        /// <param name="worker">Helper for accessing common workflow services.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var text = worker.ActivityContext.GetValue(Source);
            var ignore = worker.ActivityContext.GetValue(IgnoreCase);
            var find = worker.ActivityContext.GetValue(Find);
            var found = worker.Text.Contains(text, find, ignore);
            worker.ActivityContext.SetValue(Output, found);
        }
    }
}
