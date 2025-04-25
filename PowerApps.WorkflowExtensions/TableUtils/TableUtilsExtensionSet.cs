using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PowerApps.WorkflowExtensions.TableUtils
{
    /// <summary>
    /// Workflow extensions for maths related operations.
    /// </summary>
    public class TableUtilsExtensionSet : BaseExtensionSet
    {
        // Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="worker">The worker for this collection of workflow extensions.</param>
        public TableUtilsExtensionSet(WorkflowHelper worker) : base(worker)
        {

        }

        // Workflows

        /// <summary>
        /// Forces a recalculation of of a rollup field.
        /// </summary>
        /// <param name="logicalName">The logical name of the entity to force the recalculation for.</param>
        /// <param name="recordId">The id of the entity to force the recalculation for.</param>
        /// <param name="fieldName">The field name to force the recalculation for.</param>
        public void CalculateRollupField(string logicalName, Guid recordId, string fieldName)
        {
            var req = new CalculateRollupFieldRequest
            {
                Target = new EntityReference(logicalName, recordId),
                FieldName = fieldName
            };
            Helper.Service.Execute(req);
        }

        /// <summary>
        /// Clones an existing entity.
        /// </summary>
        /// <param name="logicalName">The logical name of the entity to clone.</param>
        /// <param name="recordId">The id of the entity to clone.</param>
        /// <param name="fields">The list of fields to include in the clone operation.</param>
        public Guid Clone(string logicalName, Guid recordId, string fields)
        {
            var fieldCols = fields.Split(new string[]{ "," }, StringSplitOptions.RemoveEmptyEntries);
            var entity = Helper.Service.Retrieve(logicalName, recordId, new ColumnSet(fieldCols));

            var clone = new Entity(logicalName);
            foreach(var field in fieldCols)
            {
                var existingVal = entity.Contains(field) ? entity[field] : null;
                clone[field] = existingVal;
            }
            clone.Id = Helper.Service.Create(clone);
            return clone.Id;
        }

        /// <summary>
        /// Delete the given record.
        /// </summary>
        /// <param name="logicalName">The logicalname of the entity to delete.</param>
        /// <param name="recordId">The id of the entity to delete.</param>
        public void DeleteRecord(string logicalName, Guid recordId)
        {
            Helper.Service.Delete(logicalName, recordId);
        }

        /// <summary>
        /// Returns the number of records that match the FetchXML provided.
        /// </summary>
        /// <param name="fetchXml">The query to be executed.</param>
        /// <param name="id1">The first optional id to be merged into the query.</param>
        /// <param name="id2">The second optional id to be merged into the query.</param>
        /// <returns>The number of records that match the FetchXML provided.</returns>
        public int FetchXmlCount(string fetchXml, string id1, string id2)
        {
            // Setup the fetch
            var mergedFetch = fetchXml.Replace("[ID1]", id1);
            mergedFetch = mergedFetch.Replace("[ID2]", id2);

            // Count all pages
            var pageSize = 5000;
            var pageNo = 1;
            var count = 0;
            while (true)
            {
                var pageFetch = mergedFetch.Replace("<fetch", $"<fetch count='{pageSize}' page='{pageNo}' ");
                var results = Helper.Service.RetrieveMultiple(new FetchExpression(pageFetch));
                count += results.Entities.Count;
                if (results.Entities.Count < pageSize)
                {
                    /// less than a page means we are done paging
                    break;
                }
                pageNo++;
            }

            // Return the total count
            return count;
        }

        /// <summary>
        /// Gets a record id from the provided record URL.
        /// </summary>
        /// <param name="url">The URL to find the id from.</param>
        /// <returns>The id from the provided record URL.</returns>
        public string GetRecordId(string url)
        {
            var idRegex = new Regex("id=([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})");
            var idMatch = idRegex.Match(url);
            var id = idMatch.Groups[0].Value.Replace("id=", "");
            return id;
        }

        /// <summary>
        /// Merges field values from an entity into a text template.
        /// </summary>
        /// <param name="logicalName">The logicalname of the entity.</param>
        /// <param name="recordId">The id of the entity.</param>
        /// <param name="template">The template to merge field values in to.</param>
        /// <returns>The merged template.</returns>
        public string MergeFields(string logicalName, Guid recordId, string template)
        {
            // First, find all the placeholder fields so we know what to retrieve
            var regex = new Regex("\\[(.*?)\\]");
            var matches = regex.Matches(template);
            var fields = matches.Cast<Match>().Select(x => x.Value).ToArray();
            var fieldsFixed = new List<string>();
            foreach(var f in fields)
            {
                var fixedF = f.Replace("[", "").Replace("]", "");
                if (fixedF.Contains(":"))
                {
                    fixedF = fixedF.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[0];
                }
                fieldsFixed.Add(fixedF);
            }
            
            // Retrieve entity with fields
            var entity = Helper.Service.Retrieve(logicalName, recordId, new ColumnSet(fieldsFixed.ToArray()));

            // Replace placeholders with values
            var mergedTemplate = template;
            foreach(var field in fields)
            {
                var token = field.Replace("[", "").Replace("]", "");
                var val = string.Empty;
                if (token.Contains(":"))
                {
                    var split = token.IndexOf(":");
                    var fieldName = token.Substring(0, split);
                    var format = token.Substring(split + 1, token.Length - split - 1);
                    var date = entity.GetAttributeValue<DateTime>(fieldName);
                    val = date > DateTime.MinValue ? date.ToString(format) : string.Empty;
                }
                else
                {
                    val = entity.FormattedValues.ContainsKey(token) ? entity.FormattedValues[token] : string.Empty;
                }
                mergedTemplate = mergedTemplate.Replace($"{field}", val);
            }

            return mergedTemplate;
        }
    }
}
