using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.TableGets
{
    /// <summary>
    /// Retrieves a User by name.
    /// </summary>
    public class GetUserByName : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the name to search for.
        /// </summary>
        [RequiredArgument]
        [Input("Name")]
        public InArgument<string> Name { get; set; }

        /// <summary>
        /// Gets or sets the User found.
        /// </summary>
        [Output("User")]
        [ReferenceTarget("systemuser")]
        public OutArgument<EntityReference> User { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var name = worker.ActivityContext.GetValue(Name);
            var result = worker.TableGet.GetUserByName(name);
            User.Set(worker.ActivityContext, result);
        }
    }
}
