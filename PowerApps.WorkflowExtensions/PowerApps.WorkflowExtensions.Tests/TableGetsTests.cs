using Microsoft.Xrm.Sdk;
using PowerApps.WorkflowExtensions.TableGets;
using PowerApps.WorkflowExtensions.Tests;
using System.Collections.Generic;
using Xunit;

namespace PowerApps.WorkfowExtensionsTests
{
    /// <summary>
    /// Tests the Text helpers.
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
        public void GetQueueByName_Does_Not_Exists()
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
        public void GetAccountByName_Does_Not_Exists()
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
        public void GetContactByName_Does_Not_Exists()
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
        public void GetTeamByName_Does_Not_Exists()
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
