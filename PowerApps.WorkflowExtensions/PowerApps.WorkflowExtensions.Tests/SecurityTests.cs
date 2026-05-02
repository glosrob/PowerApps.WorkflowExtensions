using PowerApps.WorkflowExtensions.Security;
using PowerApps.WorkflowExtensions.Text;
using System.Collections.Generic;
using Xunit;

namespace PowerApps.WorkflowExtensions.Tests
{
    /// <summary>
    /// Tests the Security helpers.
    /// </summary>
    public class SecurityTests
    {
        [Fact]
        public void AddUserToTeam()
        {
            // Arrange
            var builder = new WorkflowTestBuilder();
            var user = builder.BuildEntity("systemuser", "fullname", "Test User");
            var team = builder.BuildEntity("team", "name", "Test Team");
            builder.Setup<AddUserToTeam>()
                   .SetupAddUserToTeamRequest(user, team);
            var inputs = new Dictionary<string, object>
            {
                { "Team", team.ToEntityReference() },
                { "User", user.ToEntityReference() }
            };

            // Act
            builder.Invoke(inputs);

            // Assert
            builder.VerifyAllService();
        }

        [Fact]
        public void RemoveUserFromTeam()
        {
            // Arrange
            var builder = new WorkflowTestBuilder();
            var user = builder.BuildEntity("systemuser", "fullname", "Test User");
            var team = builder.BuildEntity("team", "name", "Test Team");
            builder.Setup<RemoveUserFromTeam>()
                   .SetupRemoveUserFromTeamRequest(user, team);
            var inputs = new Dictionary<string, object>
            {
                { "Team", team.ToEntityReference() },
                { "User", user.ToEntityReference() }
            };

            // Act
            builder.Invoke(inputs);

            // Assert
            builder.VerifyAllService();
        }
    }
}
