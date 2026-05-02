using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;

namespace PowerApps.WorkflowExtensions.Security
{
    /// <summary>
    /// Workflow extensions for maths related operations.
    /// </summary>
    public class SecurityExtensionSet : BaseExtensionSet
    {
        // Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="worker">The worker for this collection of workflow extensions.</param>
        public SecurityExtensionSet(WorkflowHelper worker): base(worker)
        {

        }

        // Workflows

        /// <summary>
        /// Adds a User to a Team.
        /// </summary>
        /// <param name="user">The User to add to the Team.</param>
        /// <param name="team">The Team to add the User to.</param>
        public void AddUserToTeam(EntityReference user, EntityReference team)
        {
            var req = new AddMembersTeamRequest
            {
                TeamId = team.Id,
                MemberIds = new Guid[] { user.Id }
            };
            Helper.Service.Execute(req);
        }

        /// <summary>
        /// Removes a User from a Team.
        /// </summary>
        /// <param name="user">The User to remove from a Team.</param>
        /// <param name="team">The Team the User will be removed from.</param>
        public void RemoveUserFromTeam(EntityReference user, EntityReference team)
        {
            var req = new RemoveMembersTeamRequest
            {
                TeamId = team.Id,
                MemberIds = new Guid[] { user.Id }
            };
            Helper.Service.Execute(req);
        }

        /// <summary>
        /// Adds a Role to a Team by name.
        /// </summary>
        /// <param name="role">The Role to add.</param>
        /// <param name="team">The Team to add the Role to.</param>
        public void AddRoleToTeam(EntityReference role, EntityReference team)
        {
            
        }

        /// <summary>
        /// Adds a Role to a User by name.
        /// </summary>
        /// <param name="role">The Role to add.</param>
        /// <param name="user">The Team to add the Role to.</param>
        public void AddRoleToUser(EntityReference role, EntityReference user)
        {

        }
    }
}
