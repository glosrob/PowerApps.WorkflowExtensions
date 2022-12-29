using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace PowerApps.WorkflowExtensions.TableUtils
{
    /// <summary>
    /// Clones an entity using only the fields provided.
    /// </summary>
    public class CloneRecord : WorkflowServiceBase
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

        /// <summary>
        /// Gets or sets the fields to be cloned.
        /// </summary>
        [Input("Fields (comma separated list of fields to clone)")]
        public InArgument<string> Fields { get; set; }

        /// <summary>
        /// Gets or sets the id of the newly cloned record.
        /// </summary>
        [Input("New Record Id")]
        public OutArgument<string> NewRecordId { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var entityLogicalName = worker.ActivityContext.GetValue(EntityLogicalName);
            var entityId = worker.ActivityContext.GetValue(EntityId);
            var fields = worker.ActivityContext.GetValue(Fields);

            var results = worker.TableUtils.Clone(entityLogicalName, Guid.Parse(entityId), fields);
            worker.ActivityContext.SetValue(NewRecordId, results.ToString());
        }
    }
}
