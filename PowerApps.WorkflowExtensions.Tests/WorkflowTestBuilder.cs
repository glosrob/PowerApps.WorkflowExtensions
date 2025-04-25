using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using Moq;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;

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

        public Entity BuildEntity(string logicalName, string field, string prop)
        {
            var e = new Entity(logicalName);
            e.Attributes.Add(field, prop);
            e.Id = Guid.NewGuid();
            return e;
        }

        public Entity BuildEntity(string logicalName, Guid id, Dictionary<string, object> fields)
        {
            var e = new Entity(logicalName);
            foreach (var attr in fields)
            {
                e.Attributes.Add(attr.Key, attr.Value);
                e.FormattedValues.Add(attr.Key, attr.Value.ToString());
            }
            e.Id = id == Guid.Empty ? Guid.NewGuid() : id;
            return e;
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

        public WorkflowTestBuilder SetupCreate(string logicalName, Dictionary<string, object> fields)
        {
            var ent = new Entity(logicalName);
            foreach(var f in fields)
            {
                ent.Attributes.Add(f.Key, f.Value);
            }
            MockService
                .Setup(x => x.Create(It.Is<Entity>(y => y.LogicalName == logicalName && AttributeCollectionsMatch(y.Attributes, ent.Attributes))))
                .Returns(ent.Id == Guid.Empty ? Guid.NewGuid() : ent.Id);
            return this;
        }

        public WorkflowTestBuilder SetupDelete(string logicalName, Guid entityId)
        {
            MockService.Setup(x => x.Delete(logicalName, entityId));
            return this;
        }

        public WorkflowTestBuilder SetupRetrieve(string logicalName, Guid id, ColumnSet colSet, Entity entity)
        {
            MockService.Setup(x => x.Retrieve(logicalName, id, It.Is<ColumnSet>(y => ColumnSetsMatch(y, colSet))))
                       .Returns(entity);
            return this;
        }

        public WorkflowTestBuilder SetupFetchXMLQuery(string fetch, EntityCollection entities)
        {
            var query = new FetchExpression(fetch);
            MockService
                .Setup(x => x.RetrieveMultiple(It.Is<FetchExpression>(y => y.Query == fetch)))
                .Returns(entities);
            return this;
        } 

        public WorkflowTestBuilder SetupQueryExpressionForEntity(string entityLogicalName, EntityCollection entities)
        {
            var query = new QueryExpression(entityLogicalName);
            MockService
                .Setup(x => x.RetrieveMultiple(It.Is<QueryExpression>(y => y.EntityName == entityLogicalName)))
                .Returns(entities);
            return this;
        }

        public WorkflowTestBuilder SetupCalculateRollupRequest(string fieldName, string logicalName, Guid id, OrganizationResponse resp)
        {
            MockService.Setup(x => x.Execute(
                It.Is<CalculateRollupFieldRequest>(y => 
                    y.Target.Id == id && 
                    y.Target.LogicalName == logicalName && 
                    y.FieldName == fieldName)))
                .Returns(resp);
            return this;
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

        public WorkflowTestBuilder VerifyAllService()
        {
            MockService.VerifyAll();
            return this;
        }

        // Helpers

        private bool AttributeCollectionsMatch(AttributeCollection primary, AttributeCollection secondary)
        {
            if (primary.Count != secondary.Count)
            {
                return false;
            }

            foreach(var attr in primary)
            {
                var secondaryVal = secondary[attr.Key];
                var primaryVal = attr.Value;

                if (secondaryVal.GetType() != primaryVal.GetType())
                {
                    return false;
                }
                else if (primaryVal is EntityReference pEr && secondaryVal is EntityReference sEr)
                {
                    if (pEr.Id != sEr.Id || pEr.LogicalName != sEr.LogicalName)
                    {
                        return false;
                    }
                }
                else if (primaryVal is OptionSetValue pOs && secondaryVal is OptionSetValue sOs)
                {
                    if (pOs.Value != sOs.Value)
                    {
                        return false;
                    }
                }
                else if (primaryVal is Money pMon && secondaryVal is Money sMon)
                {
                    if (pMon.Value != sMon.Value)
                    {
                        return false;
                    }
                }
                else
                {
                    if (primaryVal.ToString() != secondaryVal.ToString())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ColumnSetsMatch(ColumnSet primary, ColumnSet secondary)
        {
            foreach(var col in primary.Columns)
            {
                if (!secondary.Columns.Any(x => x == col))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
