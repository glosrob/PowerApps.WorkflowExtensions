using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.TableUtils
{
    /// <summary>
    /// Parses out the ID of a record from a Record URL property.
    /// </summary>
    public class GetRecordId : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the Record URL to parse the Id from.
        /// </summary>
        [Input("Record URL")]
        [RequiredArgument]
        public InArgument<string> RecordUrl { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Record.
        /// </summary>
        [Output("Record Id")]
        public OutArgument<string> RecordId { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var url = worker.ActivityContext.GetValue(RecordUrl);
            var result = worker.TableUtils.GetRecordId(url);
            RecordId.Set(worker.ActivityContext, result);
        }
    }
}
