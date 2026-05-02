using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.Security
{
    /// <summary>
    /// Adds a Role to a User.
    /// </summary>
    public class AddRoleToUser : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the name of the Role to add.
        /// </summary>
        [RequiredArgument]
        [Input("Role")]
        [ReferenceTarget("role")]
        public InArgument<EntityReference> Role { get; set; }

        /// <summary>
        /// Gets or sets the User to add to the Roel to.
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
            var role = worker.ActivityContext.GetValue(Role);
            var user = worker.ActivityContext.GetValue(User);
            worker.Security.AddRoleToUser(role, user);
        }
    }
}
