using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.TableGets
{
    /// <summary>
    /// Retrieves a Queue by its name.
    /// </summary>
    public class GetQueueByName : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the name to search for.
        /// </summary>
        [RequiredArgument]
        [Input("Name")]
        public InArgument<string> Name { get; set; }

        /// <summary>
        /// Gets or sets the Queue found.
        /// </summary>
        [Output("queue")]
        [ReferenceTarget("queue")]
        public OutArgument<EntityReference> Queue { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var name = worker.ActivityContext.GetValue(Name);
            var result = worker.TableGet.GetQueueByName(name);
            Queue.Set(worker.ActivityContext, result);
        }
    }
}
