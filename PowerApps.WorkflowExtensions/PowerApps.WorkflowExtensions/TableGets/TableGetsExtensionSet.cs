using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;

namespace PowerApps.WorkflowExtensions.TableGets
{
    /// <summary>
    /// Workflow extensions for maths related operations.
    /// </summary>
    public class TableGetsExtensionSet : BaseExtensionSet
    {
        // Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="worker">The worker for this collection of workflow extensions.</param>
        public TableGetsExtensionSet(WorkflowHelper worker): base(worker)
        {

        }

        // Workflows

        /// <summary>
        /// Retrieves the Account by its name.
        /// </summary>
        /// <param name="name">The name of the Account to try to find.</param>
        /// <returns>The Account with the name specified.</returns>
        public EntityReference GetQueueByName(string name)
        {
            return GetAnEnity("queue", "name", "queueid", name);
        }

        /// <summary>
        /// Retrieves the Queue by its name.
        /// </summary>
        /// <param name="name">The name of the Queue to try to find.</param>
        /// <returns>The Queue with the name specified.</returns>
        public EntityReference GetAccountByName(string name)
        {
            return GetAnEnity("account", "name", "contactid", name);
        }

        /// <summary>
        /// Retrieves the Contact by its name.
        /// </summary>
        /// <param name="name">The name of the Contact to try to find.</param>
        /// <returns>The Contact with the name specified.</returns>
        public EntityReference GetContactByName(string name)
        {
            return GetAnEnity("contact", "fullname", "contactid", name);
        }

        /// <summary>
        /// Retrieves the Contact by its name.
        /// </summary>
        /// <param name="name">The name of the Contact to try to find.</param>
        /// <returns>The Contact with the name specified.</returns>
        public EntityReference GetTeamByName(string name)
        {
            return GetAnEnity("team", "name", "teamid", name);
        }

        // Helpers

        private EntityReference GetAnEnity(string logicalName, string nameProp, string idProp, string nameVal)
        {
            var query = new QueryExpression(logicalName)
            {
                ColumnSet = new ColumnSet(nameProp, idProp),
                NoLock = true
            };
            query.Criteria.AddCondition(nameProp, ConditionOperator.Equal, nameVal);
            var results = Helper.Service.RetrieveMultiple(query);
            var entity = results.Entities.FirstOrDefault();
            return entity == null ? null : entity.ToEntityReference();
        }
    }
}
