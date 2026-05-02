using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace PowerApps.WorkflowExtensions.TableUtils
{
    /// <summary>
    /// Counts records returned by Fetch XML.
    /// </summary>
    public class FetchXMLCount : WorkflowServiceBase
    {
        //Properties

        /// <summary>
        /// Gets or sets the Fetch to execute.
        /// </summary>
        [Input("Fetch XML")]
        [RequiredArgument]
        public InArgument<string> FetchXML { get; set; }

        /// <summary>
        /// Gets or sets an optional value that will replace an [ID1] placeholder.
        /// </summary>
        [Input("ID Value")]
        public InArgument<string> IdPlaceholder { get; set; }

        /// <summary>
        /// Gets or sets an optional value that will replace an [ID2] placeholder.
        /// </summary>
        [Input("Alt. ID Value")]
        public InArgument<string> AltIdPlaceholder { get; set; }

        /// <summary>
        /// Gets or sets the number of records found for the query provided.
        /// </summary>
        [Output("Count")]
        public OutArgument<int> Results { get; set; }

        //Methods

        /// <summary>
        /// Implements the business logic of this class.
        /// </summary>
        /// <param name="context">The context at the time this helper was invoked.</param>
        public override void ExecuteWf(WorkflowHelper worker)
        {
            var fetchXml = worker.ActivityContext.GetValue(FetchXML);
            var idPlaceHolder = worker.ActivityContext.GetValue(IdPlaceholder);
            var altIdPlaceHolder = worker.ActivityContext.GetValue(AltIdPlaceholder);
            
            var results = worker.TableUtils.FetchXmlCount(fetchXml, idPlaceHolder, altIdPlaceHolder);
            worker.ActivityContext.SetValue(Results, results);
        }
    }
}
