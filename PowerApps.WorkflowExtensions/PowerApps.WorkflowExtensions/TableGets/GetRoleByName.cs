using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.TableGets
{
    /// <summary>
    /// Retrieves a Role by its name.
    /// </summary>
    public class GetRoleByName : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the name to search for.
        /// </summary>
        [RequiredArgument]
        [Input("Name")]
        public InArgument<string> Name { get; set; }

        /// <summary>
        /// Gets or sets the BU.
        /// </summary>
        [RequiredArgument]
        [Input("Business Unit")]
        [ReferenceTarget("businessunit")]
        public InArgument<EntityReference> BusinessUnit { get; set; }

        /// <summary>
        /// Gets or sets the Role found.
        /// </summary>
        [Output("Role")]
        [ReferenceTarget("role")]
        public OutArgument<EntityReference> Role { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var name = worker.ActivityContext.GetValue(Name);
            var bu = worker.ActivityContext.GetValue(BusinessUnit);
            var result = worker.TableGet.GetRoleByName(name, bu);
            Role.Set(worker.ActivityContext, result);
        }
    }
}
