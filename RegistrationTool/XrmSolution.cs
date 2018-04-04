using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceModel;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The Dynamics CRM Solution Class.
    /// 
    /// This class provides a constructor, properties and methods for manipulating solutions within Dynamics CRM.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Xrm")]
    public class XrmSolution
    {
        string XRMConnectionString;
        public XrmSolution(string connectionString)
        {
            XRMConnectionString = connectionString;
        }

        #region Solution Methods

        /// <summary>
        /// Method for creating a new publisher in Dynamics CRM.
        /// </summary>
        /// <param name="uniqueName">The publisher's unique name.</param>
        /// <param name="friendlyName">The publisher's friendly name.</param>
        /// <param name="supportingWebsiteUrl">The supporting web site URL.</param>
        /// <param name="customizationPrefix">The customisation prefix.</param>
        /// <param name="eMailAddress">The publisher's e-amil address.</param>
        /// <param name="description">The publisher's description.</param>
        /// <returns>A new publisher object containing the details of the new publisher.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "e"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "eMail")]
        public Publisher CreatePublisher(string uniqueName, string friendlyName, Uri supportingWebsiteUrl, string customizationPrefix, string eMailAddress, string description)
        {
            try
            {
                Publisher crmSdkPublisher = new Publisher();
                using (XrmService service = new XrmService(XRMConnectionString))
                {
                    if (supportingWebsiteUrl != null)
                    {
                        crmSdkPublisher = new Publisher
                        {
                            UniqueName = uniqueName,
                            FriendlyName = friendlyName,
                            SupportingWebsiteUrl = supportingWebsiteUrl.AbsoluteUri,
                            CustomizationPrefix = customizationPrefix,
                            EMailAddress = eMailAddress,
                            Description = description
                        };
                        QueryExpression queryPublisher = new QueryExpression
                        {
                            EntityName = Publisher.EntityLogicalName,
                            ColumnSet = new ColumnSet("publisherid", "customizationprefix"),
                            Criteria = new FilterExpression()
                        };
                        queryPublisher.Criteria.AddCondition("uniquename", ConditionOperator.Equal, crmSdkPublisher.UniqueName);
                        EntityCollection queryPublisherResults;
                        queryPublisherResults = service.RetrieveMultiple(queryPublisher);
                        Publisher SDKPublisherResults = null;
                        if (queryPublisherResults.Entities.Count > 0)
                        {
                            SDKPublisherResults = (Publisher)queryPublisherResults.Entities[0];
                            crmSdkPublisher.Id = (Guid)SDKPublisherResults.PublisherId;
                            crmSdkPublisher.CustomizationPrefix = SDKPublisherResults.CustomizationPrefix;
                        }
                        if (SDKPublisherResults == null)
                        {
                            crmSdkPublisher.Id = service.Create(crmSdkPublisher);
                        }
                    }
                }
                return crmSdkPublisher;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to create a new solution in Dynamics CRM.
        /// </summary>
        /// <param name="uniqueName">The unique name of the solution.</param>
        /// <param name="friendlyName">The friendly name of the solution.</param>
        /// <param name="publisherId">The identity of the publisher.</param>
        /// <param name="description">The description of the solution.</param>
        /// <param name="version">The version of the solution.</param>
        /// <returns>A new solution object containing the details of the new solution.</returns>
        public Solution CreateSolution(string uniqueName, string friendlyName, Guid publisherId, string description, string version)
        {
            try
            {
                Solution solution;
                using (XrmService service = new XrmService(XRMConnectionString))
                {
                    solution = new Solution
                    {
                        UniqueName = uniqueName,
                        FriendlyName = friendlyName,
                        PublisherId = new EntityReference(Publisher.EntityLogicalName, publisherId),
                        Description = description,
                        Version = version
                    };
                    QueryExpression querySampleSolution = new QueryExpression
                    {
                        EntityName = Solution.EntityLogicalName,
                        ColumnSet = new ColumnSet(),
                        Criteria = new FilterExpression()
                    };
                    querySampleSolution.Criteria.AddCondition("uniquename", ConditionOperator.Equal, solution.UniqueName);
                    EntityCollection querySampleSolutionResults = service.RetrieveMultiple(querySampleSolution);
                    Solution SampleSolutionResults = null;
                    if (querySampleSolutionResults.Entities.Count > 0)
                    {
                        SampleSolutionResults = (Solution)querySampleSolutionResults.Entities[0];
                        solution.Id = (Guid)SampleSolutionResults.SolutionId;
                    }
                    if (SampleSolutionResults == null)
                    {
                        solution.Id = service.Create(solution);
                    }
                    return solution;
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to retrieve a solution from Dynamics CRM.
        /// </summary>
        /// <param name="uniqueName">The unique name of the solution to retrieve.</param>
        /// <returns>A solution object containing the details of the retrieved solution.</returns>
        public Solution RetrieveSolution(string uniqueName)
        {
            try
            {
                Solution solution;
                using (XrmService service = new XrmService(XRMConnectionString))
                {
                    QueryExpression querySampleSolution = new QueryExpression
                    {
                        EntityName = Solution.EntityLogicalName,
                        ColumnSet = new ColumnSet(true),
                        Criteria = new FilterExpression()
                    };
                    querySampleSolution.Criteria.AddCondition("uniquename", ConditionOperator.Equal, uniqueName);
                    solution = (Solution)service.RetrieveMultiple(querySampleSolution).Entities[0];
                }
                return solution;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to delete a solution from Dynamics CRM.
        /// </summary>
        /// <param name="solution">The solution object containing the details of the solution to delete.</param>
        public void DeleteSolution(Entity solution)
        {
            try
            {
                using (XrmService service = new XrmService(XRMConnectionString))
                {
                    if (solution != null)
                    {
                        service.Delete(Solution.EntityLogicalName, solution.Id);
                    }
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded method to delete a solution from Dynamics CRM.
        /// </summary>
        /// <param name="solutionUniqueName">The unique name of the solution to delete from Dynamics CRM.</param>
        public void DeleteSolution(string solutionUniqueName)
        {
            try
            {
                using (XrmService service = new XrmService(XRMConnectionString))
                {
                    service.Delete(Solution.EntityLogicalName, GetSolutionIdByUniqueName(solutionUniqueName));
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to import a solution into Dynamics CRM.
        /// </summary>
        /// <param name="solutionFilePath">The path and file name of the file to import.</param>
        public void ImportSolution(string solutionFilePath)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes(solutionFilePath);
                ImportSolutionRequest importSolutionRequest = new ImportSolutionRequest()
                {
                    CustomizationFile = fileBytes
                };
                using (XrmService service = new XrmService(XRMConnectionString))
                {
                    service.Execute(importSolutionRequest);
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to export a solution from Dynamics CRM.
        /// </summary>
        /// <param name="outputDir">The path in which the exported solution file should be placed.</param>
        /// <param name="solutionUniqueName">The unique name of the solution to export.</param>
        /// <param name="managed">Should the solution being exported generate a managed or unmanaged solution file.</param>
        /// <returns>The file name as a string (not the path as that was an input parameter).</returns>
        public string ExportSolution(string outputDir, string solutionUniqueName, bool managed)
        {
            try
            {
                if (!string.IsNullOrEmpty(outputDir) && !outputDir.EndsWith(@"\", false, CultureInfo.CurrentCulture))
                {
                    outputDir += @"\";
                }
                string ManagedStatus;
                if (managed)
                {
                    ManagedStatus = "Managed";
                }
                else
                {
                    ManagedStatus = "UnManaged";
                }
                ExportSolutionRequest exportSolutionRequest = new ExportSolutionRequest();
                exportSolutionRequest.Managed = managed;
                exportSolutionRequest.SolutionName = solutionUniqueName;
                ExportSolutionResponse exportSolutionResponse;
                using (XrmService service = new XrmService(XRMConnectionString))
                {
                    exportSolutionResponse = (ExportSolutionResponse)service.Execute(exportSolutionRequest);
                }
                byte[] exportXml = exportSolutionResponse.ExportSolutionFile;
                string filename = solutionUniqueName + "_" + ManagedStatus + ".zip";
                File.WriteAllBytes(outputDir + filename, exportXml);
                return filename;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to roll back a solution.
        /// 
        /// This is method is used where a backup copy of the solution is first exported as a possible restoration option before another file is imported.
        /// </summary>
        /// <param name="uniqueName">The unique name of the solution to roll back.</param>
        /// <param name="solutionFullPath">The path and file name of the solution file to be imported in order to restore the previous state of the solution.</param>
        public void RollbackSolution(string uniqueName, string solutionFullPath)
        {
            try
            {
                DeleteSolution(uniqueName);
                ImportSolution(solutionFullPath);
                using (XrmService service = new XrmService(XRMConnectionString))
                {
                    service.Execute(new PublishAllXmlRequest());
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to retrieve a list of Dynamics CRM Solutions.
        /// </summary>
        /// <returns>A list object containing a collection of solution objects.</returns>
        public Collection<SolutionItem> RetrieveAllSolutions()
        {
            try
            {
                Collection<SolutionItem> solutions = new Collection<SolutionItem>();
                using (XrmService service = new XrmService(XRMConnectionString))
                {
                    OrganizationServiceContext ServerContext = service.OrganizationServiceContext;
                    var solutionQuery = from item in ServerContext.CreateQuery<Solution>()
                                        orderby item.Version ascending
                                        where item.IsVisible == true && item.UniqueName != "Default"
                                        // Do not get the base default solution
                                        select item;
                    foreach (var item in solutionQuery)
                    {
                        SolutionItem solution = new SolutionItem();
                        solution.UniqueName = item.UniqueName;
                        solution.Version = item.Version;
                        solution.FriendlyName = item.FriendlyName;
                        solution.IsManaged = item.IsManaged;
                        solutions.Add(solution);
                    }
                }
                return solutions;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to retrieve the solution identitifier by providing the solution's unique name.
        /// </summary>
        /// <param name="uniqueName">The solution's unique name.</param>
        /// <returns>The solution identifier.</returns>
        public Guid GetSolutionIdByUniqueName(string uniqueName)
        {
            try
            {
                Guid solutionQuery;
                using (XrmService service = new XrmService(XRMConnectionString))
                {
                    OrganizationServiceContext ServerContext = service.OrganizationServiceContext;
                    solutionQuery = (from item in ServerContext.CreateQuery<Solution>()
                                     where item.UniqueName == uniqueName
                                     select item.SolutionId.Value).Single<Guid>();
                }
                return solutionQuery;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to add a component to a solution.
        /// </summary>
        /// <param name="solutionComponentType">The component type.</param>
        /// <param name="componentId">The component's identifier.</param>
        /// <param name="solutionUniqueName">The solution's unique name.</param>
        /// <returns>The result of the execution.</returns>
        public AddSolutionComponentResponse AddComponentToSolution(SolutionComponentType solutionComponentType, Guid componentId, string solutionUniqueName)
        {
            try
            {
                AddSolutionComponentRequest addSolutionComponentRequest = new AddSolutionComponentRequest()
                {
                    ComponentType = (int)solutionComponentType,
                    ComponentId = componentId,
                    SolutionUniqueName = solutionUniqueName
                };
                using (XrmService service = new XrmService(XRMConnectionString))
                {
                    return (AddSolutionComponentResponse)service.Execute(addSolutionComponentRequest);
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        #endregion
    }
}
