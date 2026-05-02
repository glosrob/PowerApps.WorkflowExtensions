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
        /// Retrieves the Queue by its name.
        /// </summary>
        /// <param name="name">The name of the Queue to try to find.</param>
        /// <returns>The Queue with the name specified.</returns>
        public EntityReference GetQueueByName(string name)
        {
            return GetAnEnity("queue", "name", "queueid", name);
        }

        /// <summary>
        /// Retrieves the Account by its name.
        /// </summary>
        /// <param name="name">The name of the Account to try to find.</param>
        /// <returns>The Account with the name specified.</returns>
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
        /// Retrieves the Team by its name.
        /// </summary>
        /// <param name="name">The name of the Team to try to find.</param>
        /// <returns>The Team with the name specified.</returns>
        public EntityReference GetTeamByName(string name)
        {
            return GetAnEnity("team", "name", "teamid", name);
        }

        /// <summary>
        /// Retrieves the User by name.
        /// </summary>
        /// <param name="name">The name of the User to try to find.</param>
        /// <returns>The User with the name specified.</returns>
        public EntityReference GetUserByName(string name)
        {
            return GetAnEnity("systemuser", "fullname", "systemuserid", name);
        }

        /// <summary>
        /// Retrieves the Role by its name and Business Unit.
        /// </summary>
        /// <param name="name">The name of the Role to try to find.</param>
        /// <param name="bu">The business unit to use to find the Role.</param>
        /// <returns>The Role with the name specified.</returns>
        public EntityReference GetRoleByName(string name, EntityReference bu)
        {
            var query = new QueryExpression("role")
            {
                ColumnSet = new ColumnSet("name", "roleid"),
                NoLock = true
            };
            query.Criteria.AddCondition("name", ConditionOperator.Equal, name);
            query.Criteria.AddCondition("businessunitid", ConditionOperator.Equal, bu.Id);
            var results = Helper.Service.RetrieveMultiple(query);
            var entity = results.Entities.FirstOrDefault();
            return entity == null ? null : entity.ToEntityReference();
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
