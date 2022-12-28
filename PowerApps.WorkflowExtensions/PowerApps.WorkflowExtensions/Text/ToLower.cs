using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Text
{
    /// <summary>
    /// Converts a string to all lowercase.
    /// </summary>
    public class ToLower : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the source text.
        /// </summary>
        [RequiredArgument]
        [Input("Source")]
        public InArgument<string> Source { get; set; }

        /// <summary>
        /// Gets or sets the output text.
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
            var output = worker.Text.ToLower(text);
            worker.ActivityContext.SetValue(Output, output);
        }
    }
}
