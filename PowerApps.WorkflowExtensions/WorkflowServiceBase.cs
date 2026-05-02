using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using PowerApps.WorkflowExtensions.Calendar;
using System.Activities;

namespace PowerApps.WorkflowExtensions
{
    /// <summary>
    /// Base class for all Workflows.
    /// </summary>
    public abstract class WorkflowServiceBase : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            var serviceFactory = context.GetExtension<IOrganizationServiceFactory>();
            var wfContext = context.GetExtension<IWorkflowContext>();
            var service = serviceFactory.CreateOrganizationService(wfContext.UserId);
            var tracingService = context.GetExtension<ITracingService>();

            var wfHelper = new WorkflowHelper(serviceFactory, service, tracingService, wfContext, context);
            ExecuteWf(wfHelper);
        }

        /// <summary>
        /// Override in the worflow implementation.
        /// </summary>
        /// <param name="worker">WorkflowHelper to access common Workflow classes.</param>
        public abstract void ExecuteWf(WorkflowHelper worker);
    }
}
