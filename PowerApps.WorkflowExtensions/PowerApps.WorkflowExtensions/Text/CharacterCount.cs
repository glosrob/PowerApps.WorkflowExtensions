using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Text
{
    /// <summary>
    /// Gets the number of characters in text.
    /// </summary>
    public class CharacterCount : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the source text.
        /// </summary>
        [RequiredArgument]
        [Input("Source")]
        public InArgument<string> Source { get; set; }

        /// <summary>
        /// Gets or sets the length of the text.
        /// </summary>
        [Output("Output")]
        public OutArgument<int> Output { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic for this workflow step.
        /// </summary>
        /// <param name="worker">Helper for accessing common workflow services.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var text = worker.ActivityContext.GetValue(Source);
            var count = worker.Text.CharacterCount(text);
            worker.ActivityContext.SetValue(Output, count);
        }
    }
}
