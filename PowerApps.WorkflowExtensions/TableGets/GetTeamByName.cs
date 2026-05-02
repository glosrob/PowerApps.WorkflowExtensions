using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.TableGets
{
    /// <summary>
    /// Retrieves a Team by its name.
    /// </summary>
    public class GetTeamByName : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the name to search for.
        /// </summary>
        [RequiredArgument]
        [Input("Name")]
        public InArgument<string> Name { get; set; }

        /// <summary>
        /// Gets or sets the Team found.
        /// </summary>
        [Output("Team")]
        [ReferenceTarget("team")]
        public OutArgument<EntityReference> Team { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var name = worker.ActivityContext.GetValue(Name);
            var result = worker.TableGet.GetTeamByName(name);
            Team.Set(worker.ActivityContext, result);
        }
    }
}
