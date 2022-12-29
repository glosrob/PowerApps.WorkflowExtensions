using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace PowerApps.WorkflowExtensions.TableUtils
{
    /// <summary>
    /// Deletes a record.
    /// </summary>
    public class DeleteRecord : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the entity logical name.
        /// </summary>
        [Input("Entity Logical Name")]
        [RequiredArgument]
        public InArgument<string> EntityLogicalName { get; set; }

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        [Input("Entity ID")]
        public InArgument<string> EntityId { get; set; }

        // Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var entityLogicalName = worker.ActivityContext.GetValue(EntityLogicalName);
            var entityId = worker.ActivityContext.GetValue(EntityId);

            worker.TableUtils.DeleteRecord(entityLogicalName, Guid.Parse(entityId));
        }
    }
}
