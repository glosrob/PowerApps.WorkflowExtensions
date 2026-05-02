using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Security
{
    /// <summary>
    /// Adds a User to a Team.
    /// </summary>
    public class AddUserToTeam : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the Team to add the User to.
        /// </summary>
        [RequiredArgument]
        [Input("Team")]
        [ReferenceTarget("team")]
        public InArgument<EntityReference> Team { get; set; }

        /// <summary>
        /// Gets or sets the User to add to the Team.
        /// </summary>
        [RequiredArgument]
        [Input("User")]
        [ReferenceTarget("systemuser")]
        public InArgument<EntityReference> User { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var user = worker.ActivityContext.GetValue(User);
            var team = worker.ActivityContext.GetValue(Team);
            worker.Security.AddUserToTeam(user, team);
        }
    }
}
