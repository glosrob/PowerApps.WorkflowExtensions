using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Security
{
    /// <summary>
    /// Adds a Role to a Team.
    /// </summary>
    public class AddRoleToTeam : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the name to search for.
        /// </summary>
        [RequiredArgument]
        [Input("Role")]
        [ReferenceTarget("role")]
        public InArgument<EntityReference> Role { get; set; }

        /// <summary>
        /// Gets or sets the name to search for.
        /// </summary>
        [RequiredArgument]
        [Input("Team")]
        [ReferenceTarget("team")]
        public InArgument<EntityReference> Team { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var role = worker.ActivityContext.GetValue(Role);
            var team = worker.ActivityContext.GetValue(Team);
            worker.Security.AddRoleToTeam(role, team);
        }
    }
}
