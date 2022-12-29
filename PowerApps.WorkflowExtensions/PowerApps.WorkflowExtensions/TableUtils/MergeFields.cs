using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace PowerApps.WorkflowExtensions.TableUtils
{
    /// <summary>
    /// Merges field values from an entity into a text template.
    /// </summary>
    public class MergeFields : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the id of the entity to lookup values from.
        /// </summary>
        [Input("Entity Id")]
        [RequiredArgument]
        public InArgument<string> EntityId { get; set; }

        /// <summary>
        /// Gets or sets the logical name of the entity to lookup values from.
        /// </summary>
        [Input("Entity Logical Name")]
        [RequiredArgument]
        public InArgument<string> EntityLogicalName { get; set; }

        /// <summary>
        /// Gets or sets the template to merge values in to.
        /// </summary>
        [Input("Template")]
        public InArgument<string> Template { get; set; }

        /// <summary>
        /// Gets or sets the template with values merged in.
        /// </summary>
        [Output("Output")]
        public OutArgument<string> Output { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var entityId = worker.ActivityContext.GetValue(EntityId);
            var entityLogicalName = worker.ActivityContext.GetValue(EntityLogicalName);
            var template = worker.ActivityContext.GetValue(Template);

            var output = worker.TableUtils.MergeFields(entityLogicalName, Guid.Parse(entityId), template);
            worker.ActivityContext.SetValue(Output, output);
        }
    }
}
