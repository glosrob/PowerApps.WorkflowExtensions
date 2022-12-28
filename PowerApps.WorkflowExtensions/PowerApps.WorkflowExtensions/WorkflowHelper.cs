using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using PowerApps.WorkflowExtensions.Calendar;
using PowerApps.WorkflowExtensions.Maths;
using System.Activities;

namespace PowerApps.WorkflowExtensions
{
    /// <summary>
    /// Provides access to the common Workflow helpers.
    /// </summary>
    public class WorkflowHelper
    {
        // Constructor

        public WorkflowHelper(
            IOrganizationServiceFactory serviceFactory, 
            IOrganizationService service, 
            ITracingService tracingService, 
            IWorkflowContext wfContext, 
            CodeActivityContext context)
        {
            Factory = serviceFactory;
            Service = service;
            Trace = tracingService;
            WorkflowContext = wfContext;
            ActivityContext = context;

            Calendar = new CalendarExtensionSet(this);
            Maths = new MathsExtensionSet(this);
        }

        // Services

        public IOrganizationServiceFactory Factory { get; set; }
        public IWorkflowContext WorkflowContext { get; set; }
        public IOrganizationService Service { get; set; }
        public ITracingService Trace { get; set; }
        public CodeActivityContext ActivityContext { get; set; }

        // Workflows

        public CalendarExtensionSet Calendar { get; }

        public MathsExtensionSet Maths { get; }
    }
}
