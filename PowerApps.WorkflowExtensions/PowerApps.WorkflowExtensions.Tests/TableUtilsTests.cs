using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using PowerApps.WorkflowExtensions.TableUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PowerApps.WorkflowExtensions.Tests
{
    /// <summary>
    /// Tests the Table Utils helpers.
    /// </summary>
    public class TableUtilsTests
    {
        [Fact]
        public void CalculateRollupField()
        {
            // Arrange
            var id = Guid.NewGuid();
            var inputs = new Dictionary<string, object>
            {
                { "EntityLogicalName", "contact" },
                { "EntityId", id.ToString() },
                { "FieldName", "foo_field" }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<CalculateRollupField>()
                   .SetupCalculateRollupRequest("foo_field", "contact", id, new OrganizationResponse());

            // Act
            builder.Invoke(inputs);

            // Assert
            builder.VerifyAllService();
        }

        [Fact]
        public void DeleteRecord()
        {
            // Arrange
            var id = Guid.NewGuid();
            var inputs = new Dictionary<string, object>
            {
                { "EntityLogicalName", "contact" },
                { "EntityId", id.ToString() }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<DeleteRecord>()
                   .SetupDelete("contact", id);

            // Act
            builder.Invoke(inputs);

            // Assert
            builder.VerifyAllService();
        }

        [Fact]
        public void FetchXML_Single_Pages()
        {
            // Arrange
            var fetch = "<fetch nolock='true'>" +
                "<entity name='contact'>" +
                "<attribute name='fullname' />" +
                "<attribute name='contactid' />" +
                "<filter type='or'>" +
                "<condition name='contactid' operator='eq' value='[ID1]' />" +
                "<condition name='contactid' operator='eq' value='[ID2]' />" +
                "</filter>" +
                "</entity>" +
                "</fetch>";
            var id1 = Guid.NewGuid().ToString();
            var id2 = Guid.NewGuid().ToString();
            var mergedFetch = fetch.Replace("[ID1]", id1);
            mergedFetch = mergedFetch.Replace("[ID2]", id2);
            mergedFetch = mergedFetch.Replace("<fetch", "<fetch count='5000' page='1' ");

            var inputs = new Dictionary<string, object>
            {
                { "FetchXML", fetch },
                { "IdPlaceholder", id1 },
                { "AltIdPlaceholder", id2 }
            };
            var builder = new WorkflowTestBuilder();
            var results = builder.CollectionFromEntity("contact", "fullname", "Example Contact 1");
            results.Entities.Add(builder.BuildEntity("contact", "fullname", "Example Contact 1"));
            builder
                .Setup<FetchXMLCount>()
                .SetupFetchXMLQuery(mergedFetch, results);

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(results.Entities.Count, int.Parse(outputs["Results"].ToString()));
            builder.VerifyAllService();
        }

        [Fact]
        public void FetchXML_Multiple_Pages()
        {
            // Arrange
            var fetch = "<fetch nolock='true'>" +
                "<entity name='contact'>" +
                "<attribute name='fullname' />" +
                "<attribute name='contactid' />" +
                "<filter type='or'>" +
                "<condition name='contactid' operator='eq' value='[ID1]' />" +
                "<condition name='contactid' operator='eq' value='[ID2]' />" +
                "</filter>" +
                "</entity>" +
                "</fetch>";
            var id1 = Guid.NewGuid().ToString();
            var id2 = Guid.NewGuid().ToString();
            var mergedFetch = fetch.Replace("[ID1]", id1);
            mergedFetch = mergedFetch.Replace("[ID2]", id2);
            mergedFetch = mergedFetch.Replace("<fetch", "<fetch count='5000' page='1' ");

            var mergedFetch2 = fetch.Replace("[ID1]", id1);
            mergedFetch2 = mergedFetch2.Replace("[ID2]", id2);
            mergedFetch2 = mergedFetch2.Replace("<fetch", "<fetch count='5000' page='2' ");

            var inputs = new Dictionary<string, object>
            {
                { "FetchXML", fetch },
                { "IdPlaceholder", id1 },
                { "AltIdPlaceholder", id2 }
            };
            var builder = new WorkflowTestBuilder();
            var results = builder.CollectionFromEntity("contact", "fullname", "Example Contact 1");
            for (var ctr = 2; ctr < 5001; ctr++)
            {
                results.Entities.Add(builder.BuildEntity("contact", "fullname", $"Example Contact {ctr}"));
            }
            var results2 = builder.CollectionFromEntity("contact", "fullname", "Example Contact 5001");
            builder
                .Setup<FetchXMLCount>()
                .SetupFetchXMLQuery(mergedFetch, results)
                .SetupFetchXMLQuery(mergedFetch2, results2);

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(results.Entities.Count + results2.Entities.Count, int.Parse(outputs["Results"].ToString()));
            builder.VerifyAllService();
        }

        [Fact]
        public void GetRecordId()
        {
            // Arrange
            var id = Guid.NewGuid();
            var url = $"https://crm.crm11.dynamics.com:443/main.aspx?etc=2&id={id}e&histKey=745696753&newWindow=true&pagetype=entityrecord";
            var inputs = new Dictionary<string, object>
            {
                { "RecordUrl", url }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<GetRecordId>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(id.ToString(), outputs["RecordId"]);
            builder.VerifyAllService();
        }

        [Fact]
        public void CloneRecord_Simple()
        {
            // Arrange
            var id = Guid.NewGuid();
            var otherId = Guid.NewGuid();

            // - Setup all fields for fake entity that will be cloned
            var builder = new WorkflowTestBuilder();
            var fields = Fields(otherId);
            var contact = builder.BuildEntity("contact", id, fields);

            // - Setup inputs for the workflow
            var inputs = new Dictionary<string, object>
            {
                { "EntityLogicalName", "contact" },
                { "EntityId", id.ToString() },
                { "Fields", string.Join(",", fields.Select(x => x.Key)) }
            };

            // - Setup service events
            builder.Setup<CloneRecord>()
                   .SetupRetrieve("contact", id, new ColumnSet(fields.Select(x => x.Key).ToArray()), contact)
                   .SetupCreate("contact", fields);

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.NotEqual(id.ToString(), outputs["NewRecordId"]);
            builder.VerifyAllService();
        }

        [Fact]
        public void CloneRecord_Ignores_Other_Fields()
        {
            // Arrange
            var id = Guid.NewGuid();
            var otherId = Guid.NewGuid();

            // - Setup all fields for fake entity that will be cloned
            var builder = new WorkflowTestBuilder();
            var fields = Fields(otherId);
            var contact = builder.BuildEntity("contact", id, fields);

            // - Setup inputs for the workflow
            var inputs = new Dictionary<string, object>
            {
                { "EntityLogicalName", "contact" },
                { "EntityId", id.ToString() },
                { "Fields", string.Join(",", FieldListWithoutIgnoreMe.Select(x => x)) }
            };

            // - Setup service events
            builder.Setup<CloneRecord>()
                   .SetupRetrieve("contact", id, new ColumnSet(FieldListWithoutIgnoreMe), contact)
                   .SetupCreate("contact", FieldsWithoutIgnoreMe(otherId));

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.NotEqual(id.ToString(), outputs["NewRecordId"]);
            builder.VerifyAllService();
        }

        [Fact]
        public void MergeFields_Simple()
        {
            // Arrange
            var template = "foobar foo [foo_bar] [foo_foobar] foobar.";
            var expectedOutput = "foobar foo Test Test2 foobar.";

            var id = Guid.NewGuid();
            var logicalName = $"contact";
            var inputs = new Dictionary<string, object>
            {
                { "EntityId", id.ToString() },
                { "EntityLogicalName", logicalName },
                { "Template", template }
            };
            var entityFields = new Dictionary<string, object>
            {
                { "foo_bar", "Test" },
                { "foo_foobar", "Test2" }
            };
            var builder = new WorkflowTestBuilder();
            var entity = builder.BuildEntity(logicalName, id, entityFields);
            builder.Setup<MergeFields>()
                   .SetupRetrieve(logicalName, id, new ColumnSet("foo_bar", "foo_foobar"), entity);

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expectedOutput, outputs["Output"]);
            builder.VerifyAllService();
        }

        [Fact]
        public void MergeFields_Field_Multiple_Times()
        {
            // Arrange
            var template = "foobar foo [foo_bar] [foo_bar] [foo_bar] [foo_foobar] foobar.";
            var expectedOutput = "foobar foo Test Test Test Test2 foobar.";

            var id = Guid.NewGuid();
            var logicalName = $"contact";
            var inputs = new Dictionary<string, object>
            {
                { "EntityId", id.ToString() },
                { "EntityLogicalName", logicalName },
                { "Template", template }
            };
            var entityFields = new Dictionary<string, object>
            {
                { "foo_bar", "Test" },
                { "foo_foobar", "Test2" }
            };
            var builder = new WorkflowTestBuilder();
            var entity = builder.BuildEntity(logicalName, id, entityFields);
            builder.Setup<MergeFields>()
                   .SetupRetrieve(logicalName, id, new ColumnSet("foo_bar", "foo_foobar"), entity);

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expectedOutput, outputs["Output"]);
            builder.VerifyAllService();
        }

        [Fact]
        public void MergeFields_Date_Field_Formatting()
        {
            // Arrange
            var template = "foobar foo [foo_bar] [foo_foobar] foobar [foo_date:dd MMMM yyyy H:mm].";
            var expectedOutput = "foobar foo Test Test2 foobar 29 December 2022 9:00.";

            var id = Guid.NewGuid();
            var logicalName = $"contact";
            var inputs = new Dictionary<string, object>
            {
                { "EntityId", id.ToString() },
                { "EntityLogicalName", logicalName },
                { "Template", template }
            };
            var entityFields = new Dictionary<string, object>
            {
                { "foo_bar", "Test" },
                { "foo_foobar", "Test2" },
                { "foo_date", new DateTime(2022, 12, 29, 9, 0, 0) }
            };
            var builder = new WorkflowTestBuilder();
            var entity = builder.BuildEntity(logicalName, id, entityFields);
            builder.Setup<MergeFields>()
                   .SetupRetrieve(logicalName, id, new ColumnSet("foo_bar", "foo_foobar", "foo_date"), entity);

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expectedOutput, outputs["Output"]);
            builder.VerifyAllService();
        }

        // Helpers

        private Dictionary<string, object> Fields(Guid id) => new Dictionary<string, object>
        {
            { "fullname", "Foo Bar" },
            { "foo_optionset", "Foo Bar" },
            { "foo_lookup", new EntityReference("foo_entity", id) },
            { "foo_currency", new Money(100.50M) },
            { "foo_number", 1 },
            { "foo_bool", true },
            { "foo_ignoreme", "Test" }
        };

        private Dictionary<string, object> FieldsWithoutIgnoreMe(Guid id) => new Dictionary<string, object>
        {
            { "fullname", "Foo Bar" },
            { "foo_optionset", "Foo Bar" },
            { "foo_lookup", new EntityReference("foo_entity", id) },
            { "foo_currency", new Money(100.50M) },
            { "foo_number", 1 },
            { "foo_bool", true }
        };

        private string[] FieldListWithoutIgnoreMe => new string[] { "fullname","foo_optionset","foo_lookup","foo_currency","foo_number","foo_bool" };
    }
}
