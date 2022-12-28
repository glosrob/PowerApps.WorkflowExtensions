using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using Moq;
using System;
using System.Activities;
using System.Collections.Generic;

namespace PowerApps.WorkflowExtensions.Tests
{
    public class WorkflowTestBuilder
    {
        // Properties

        internal Mock<IWorkflowContext> MockWorkflowContext { get; set; }
        internal Mock<ITracingService> MockTrace { get; set; }
        internal Mock<IOrganizationServiceFactory> MockFactory { get; set; }
        internal Mock<IOrganizationService> MockService { get; set; }
        internal WorkflowInvoker Invoker { get; set; }

        // Methods

        public IDictionary<string, object> Invoke(Dictionary<string, object> inputs)
        {
            var outputs = Invoker.Invoke(inputs);
            return outputs;
        }

        public void SetupRetrieveMultiple(QueryBase query, EntityCollection entities)
        {
            MockService.Setup(x => x.RetrieveMultiple(query)).Returns(entities);
        }

        public void SetupRetrieveMultipleGeneric(EntityCollection entities)
        {
            MockService.Setup(x => x.RetrieveMultiple(It.IsAny<QueryBase>())).Returns(entities);
        }

        public void SetupRetrieve(string logicalName, Guid id, ColumnSet colSet, Entity entity)
        {
            MockService.Setup(x => x.Retrieve(logicalName, id, colSet)).Returns(entity);
        }

        public void SetupRetrieveGeneric(Entity entity)
        {
            MockService.Setup(x => x.Retrieve(It.IsAny<string>(), It.IsAny<Guid>(), It.IsAny<ColumnSet>())).Returns(entity);
        }

        public WorkflowTestBuilder SetupQueryExpressionForEntity(string entityLogicalName, EntityCollection entities)
        {
            var query = new QueryExpression(entityLogicalName);
            MockService
                .Setup(x => x.RetrieveMultiple(It.Is<QueryExpression>(y => y.EntityName == entityLogicalName)))
                .Returns(entities);
            return this;
        }

        public EntityCollection CollectionFromEntity(string entityLogicalName, string prop, string val)
        {
            var queue = new Entity(entityLogicalName, Guid.NewGuid())
            {
                Id = Guid.NewGuid()
            };
            queue.Attributes.Add(prop, val);
            var entities = new EntityCollection();
            entities.Entities.Add(queue);
            return entities;
        }

        public WorkflowTestBuilder Setup<T>() where T : Activity, new()
        {
            var mockRepo = new MockRepository(MockBehavior.Default);
            MockWorkflowContext = mockRepo.Create<IWorkflowContext>();
            MockTrace = mockRepo.Create<ITracingService>();
            MockFactory = mockRepo.Create<IOrganizationServiceFactory>();
            MockService = mockRepo.Create<IOrganizationService>();
            MockFactory.Setup(x => x.CreateOrganizationService(It.IsAny<Guid>())).Returns(MockService.Object);

            var target = new T();
            Invoker = new WorkflowInvoker(target);
            Invoker.Extensions.Add(() => MockWorkflowContext.Object);
            Invoker.Extensions.Add(() => MockTrace.Object);
            Invoker.Extensions.Add(() => MockFactory.Object);

            return this;
        }
    }
}
