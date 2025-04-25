using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace PowerApps.WorkflowExtensions.TableUtils
{
    /// <summary>
    /// Forces the recalculation of a rollup field.
    /// </summary>
    public class CalculateRollupField : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the entity logical name.
        /// </summary>
        [RequiredArgument]
        [Input("Entity Logical Name")]
        public InArgument<string> EntityLogicalName { get; set; }

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        [RequiredArgument]
        [Input("Entity Id")]
        public InArgument<string> EntityId { get; set; }

        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        [RequiredArgument]
        [Input("Name")]
        public InArgument<string> FieldName { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var entityLogicalName = worker.ActivityContext.GetValue(EntityLogicalName);
            var entityId = worker.ActivityContext.GetValue(EntityId);
            var fieldName = worker.ActivityContext.GetValue(FieldName);
            worker.TableUtils.CalculateRollupField(entityLogicalName, Guid.Parse(entityId), fieldName);
        }
    }
}
