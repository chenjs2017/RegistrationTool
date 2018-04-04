using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using PluginRegistrationTool;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace PluginRegistrationTool
{
    /// <summary>
    /// Registration Service Class.
    /// </summary>
    internal class RegistrationService
    {

        /// <summary>
        /// XRM Service.
        /// </summary>
        XrmService _xrmService;

        /// <summary>
        /// XRM Service.
        /// </summary>
        private XrmService xrmService
        {
            get
            {
                return _xrmService;
            }
            set
            {
                _xrmService = value;
            }
        }

        /// <summary>
        /// Id String.
        /// </summary>
        private string _idString;

        /// <summary>
        /// Id String.
        /// </summary>
        private string IdString
        {
            get
            {
                return _idString;
            }
            set
            {
                _idString = value;
            }
        }

        /// <summary>
        /// Result indicating success or failure.
        /// </summary>
        private bool _result;

        /// <summary>
        /// Result indicating success or failure.
        /// </summary>
        private bool Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        /// <summary>
        /// Method to retrieve the correct XRM Service with or without Credentials.
        /// </summary>
        /// <param name="xrmServerDetails">The Server Details.</param>
        /// <returns>The correct XRM Service.</returns>
        internal XrmService GetService(string xrmServerDetails)
        {
            return new XrmService(xrmServerDetails);
       }

        internal bool Unregister(string  xrmServerDetails, string entityLogicalName, Guid id, Collection<string> errors, SolutionComponentType solutionComponentType)
        {
            try
            {
                Result = false;
                using (xrmService = GetService(xrmServerDetails))
                {
                    try
                    {
                        if (solutionComponentType != SolutionComponentType.SDKMessageProcessingStepSecureConfig)
                        {
                            RetrieveDependenciesForDeleteRequest retrieveDependenciesForDeleteRequest = new RetrieveDependenciesForDeleteRequest();
                            retrieveDependenciesForDeleteRequest.ComponentType = (int)solutionComponentType;
                            retrieveDependenciesForDeleteRequest.ObjectId = id;
                            RetrieveDependenciesForDeleteResponse retrieveDependenciesForDeleteResponse = (RetrieveDependenciesForDeleteResponse)xrmService.Execute(retrieveDependenciesForDeleteRequest);
                            if (retrieveDependenciesForDeleteResponse.EntityCollection.Entities.Count == 0)
                            {
                                xrmService.Retrieve(entityLogicalName, id, new ColumnSet(true));
                                xrmService.Delete(entityLogicalName, id);
                            }
                            else
                            {
                                errors.Add(solutionComponentType.ToString() + " with id = " + id.ToString() + "exists!");
                            }
                        }
                        else
                        {
                            xrmService.Retrieve(entityLogicalName, id, new ColumnSet(true));
                            xrmService.Delete(entityLogicalName, id);
                        }
                    }
                    catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> e)
                    {
                        IdString = id.ToString().Trim();
                        IdString = IdString.Replace("{", string.Empty);
                        IdString = IdString.Replace("}", string.Empty);
                        if (e.Message == entityLogicalName + " With Id = " + id.ToString().Trim() + " Does Not Exist")
                        {
                            errors.Add(e.Message);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                Result = true;
                return Result;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }
    }
}
