using Microsoft.Xrm.Sdk;
using PowerApps.WorkflowExtensions.TableGets;
using System;
using System.Collections.Generic;
using Xunit;

namespace PowerApps.WorkflowExtensions.Tests
{
    /// <summary>
    /// Tests the Table Get helpers.
    /// </summary>
    public class TableGetsTests
    {
        [Fact]
        public void GetQueueByName_Exists()
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Name", "FooBar" }
            };
            var builder = new WorkflowTestBuilder();
            var results = builder.CollectionFromEntity("queue", "name", "FooBar");
            builder
                .Setup<GetQueueByName>()
                .SetupQueryExpressionForEntity("queue", results);

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            var result = outputs["Queue"] as EntityReference;
            Assert.Equal(results[0].Id, result.Id);
        }

        [Fact]
        public void GetQueueByName_Does_Not_Exist()
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Name", "FooBar" }
            };
            var builder = new WorkflowTestBuilder();
            builder
                .Setup<GetQueueByName>()
                .SetupQueryExpressionForEntity("queue", new EntityCollection());

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            var result = outputs["Queue"] as EntityReference;
            Assert.Null(result);
        }

        [Fact]
        public void GetAccountByName_Exists()
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Name", "FooBar" }
            };
            var builder = new WorkflowTestBuilder();
            var results = builder.CollectionFromEntity("account", "name", "FooBar");
            builder
                .Setup<GetAccountByName>()
                .SetupQueryExpressionForEntity("account", results);

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            var result = outputs["Account"] as EntityReference;
            Assert.Equal(results[0].Id, result.Id);
        }

        [Fact]
        public void GetAccountByName_Does_Not_Exist()
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Name", "FooBar" }
            };
            var builder = new WorkflowTestBuilder();
            builder
                .Setup<GetAccountByName>()
                .SetupQueryExpressionForEntity("account", new EntityCollection());

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            var result = outputs["Account"] as EntityReference;
            Assert.Null(result);
        }

        [Fact]
        public void GetContactByName_Exists()
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Name", "FooBar" }
            };
            var builder = new WorkflowTestBuilder();
            var results = builder.CollectionFromEntity("contact", "fullname", "FooBar");
            builder
                .Setup<GetContactByName>()
                .SetupQueryExpressionForEntity("contact", results);

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            var result = outputs["Contact"] as EntityReference;
            Assert.Equal(results[0].Id, result.Id);
        }

        [Fact]
        public void GetContactByName_Does_Not_Exist()
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Name", "FooBar" }
            };
            var builder = new WorkflowTestBuilder();
            builder
                .Setup<GetContactByName>()
                .SetupQueryExpressionForEntity("contact", new EntityCollection());

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            var result = outputs["Contact"] as EntityReference;
            Assert.Null(result);
        }

        [Fact]
        public void GetUserByName_Exists()
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Name", "Test Name" }
            };
            var builder = new WorkflowTestBuilder();
            var results = builder.CollectionFromEntity("systemuser", "fullname", "Test Name");
            builder
                .Setup<GetUserByName>()
                .SetupQueryExpressionForEntity("systemuser", results);

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            var result = outputs["User"] as EntityReference;
            Assert.Equal(results[0].Id, result.Id);
        }

        [Fact]
        public void GetUserByName_Does_Not_Exist()
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Name", "Does not exist" }
            };
            var builder = new WorkflowTestBuilder();
            builder
                .Setup<GetUserByName>()
                .SetupQueryExpressionForEntity("systemuser", new EntityCollection());

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            var result = outputs["User"] as EntityReference;
            Assert.Null(result);
        }

        [Fact]
        public void GetRoleByName_Exists()
        {
            // Arrange
            var builder = new WorkflowTestBuilder();
            var buRef = new EntityReference("businessunit", Guid.NewGuid());
            var inputs = new Dictionary<string, object>
            {
                { "Name", "Test Role" },
                { "BusinessUnit", buRef }
            };
            var results = builder.CollectionFromEntity("role", "name", "Test Role");
            builder
                .Setup<GetRoleByName>()
                .SetupQueryExpressionForEntity("role", results);

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            var result = outputs["Role"] as EntityReference;
            Assert.Equal(results[0].Id, result.Id);
        }

        [Fact]
        public void GetRoleByName_Does_Not_Exist()
        {
            // Arrange
            var buRef = new EntityReference("businessunit", Guid.NewGuid());
            var inputs = new Dictionary<string, object>
            {
                { "Name", "Test Role" },
                { "BusinessUnit", buRef }
            };
            var builder = new WorkflowTestBuilder();
            builder
                .Setup<GetRoleByName>()
                .SetupQueryExpressionForEntity("role", new EntityCollection());

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            var result = outputs["Role"] as EntityReference;
            Assert.Null(result);
        }

        [Fact]
        public void GetTeamByName_Exists()
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Name", "FooBar" }
            };
            var builder = new WorkflowTestBuilder();
            var results = builder.CollectionFromEntity("team", "name", "FooBar");
            builder
                .Setup<GetTeamByName>()
                .SetupQueryExpressionForEntity("team", results);

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            var result = outputs["Team"] as EntityReference;
            Assert.Equal(results[0].Id, result.Id);
        }

        [Fact]
        public void GetTeamByName_Does_Not_Exist()
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Name", "FooBar" }
            };
            var builder = new WorkflowTestBuilder();
            builder
                .Setup<GetTeamByName>()
                .SetupQueryExpressionForEntity("team", new EntityCollection());

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            var result = outputs["Team"] as EntityReference;
            Assert.Null(result);
        }
    }
}
