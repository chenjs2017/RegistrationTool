using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using PluginRegistrationTool;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The Step Helper Class.
    /// </summary>
    internal class StepHelper
    {
        #region Properties

        /// <summary>
        /// Registration Service.
        /// </summary>
        private RegistrationService _registrationService = new RegistrationService();

        /// <summary>
        /// Registration Service.
        /// </summary>
        private RegistrationService RegistrationService
        {
            get
            {
                return _registrationService;
            }
        }

        /// <summary>
        /// Image Helper.
        /// </summary>
        private ImageHelper _imageHelper = new ImageHelper();

        /// <summary>
        /// Image Helper.
        /// </summary>
        private ImageHelper ImageHelper
        {
            get
            {
                return _imageHelper;
            }
        }

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
        /// Impersonating User Id.
        /// </summary>
        private Guid _impersonatingUserId;

        /// <summary>
        /// Impersonating User Id.
        /// </summary>
        private Guid ImpersonatingUserId
        {
            get
            {
                return _impersonatingUserId;
            }
            set
            {
                _impersonatingUserId = value;
            }
        }

        /// <summary>
        /// Query System User.
        /// </summary>
        private QueryByAttribute _querySystemUser;

        /// <summary>
        /// Query System User.
        /// </summary>
        private QueryByAttribute QuerySystemUser
        {
            get
            {
                return _querySystemUser;
            }
            set
            {
                _querySystemUser = value;
            }
        }

        /// <summary>
        /// System User Entity Collection.
        /// </summary>
        private EntityCollection _systemUserEntityCollection;

        /// <summary>
        /// System User Entity Collection.
        /// </summary>
        private EntityCollection SystemUserEntityCollection
        {
            get
            {
                return _systemUserEntityCollection;
            }
            set
            {
                _systemUserEntityCollection = value;
            }
        }

        /// <summary>
        /// User.
        /// </summary>
        private SystemUser _user;

        /// <summary>
        /// User.
        /// </summary>
        private SystemUser User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
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
        /// SDK Message Processing Step.
        /// </summary>
        private SdkMessageProcessingStep _sdkMessageProcessingStep;

        /// <summary>
        /// SDK Message Processing Step.
        /// </summary>
        private SdkMessageProcessingStep SdkMessageProcessingStep
        {
            get
            {
                return _sdkMessageProcessingStep;
            }
            set
            {
                _sdkMessageProcessingStep = value;
            }
        }

        /// <summary>
        /// SDK Message Entity Id.
        /// </summary>
        private Guid sdkMessageEntityId;

        /// <summary>
        /// SDK Message Entity Id.
        /// </summary>
        private Guid SdkMessageEntityId
        {
            get
            {
                return sdkMessageEntityId;
            }
            set
            {
                sdkMessageEntityId = value;
            }
        }

        /// <summary>
        /// XRM Metadata.
        /// </summary>
        private XrmMetadata xrmMetadata;

        /// <summary>
        /// XRM Metadata.
        /// </summary>
        private XrmMetadata XrmMetadata
        {
            get
            {
                return xrmMetadata;
            }
            set
            {
                xrmMetadata = value;
            }
        }

        /// <summary>
        /// Primary Entity Metadata.
        /// </summary>
        private EntityMetadata primaryEntityMetadata;

        /// <summary>
        /// Primary Entity Metadata.
        /// </summary>
        private EntityMetadata PrimaryEntityMetadata
        {
            get
            {
                return primaryEntityMetadata;
            }
            set
            {
                primaryEntityMetadata = value;
            }
        }

        /// <summary>
        /// Secondary Entity Metadata.
        /// </summary>
        private EntityMetadata secondaryEntityMetadata;

        /// <summary>
        /// Secondary Entity Metadata.
        /// </summary>
        private EntityMetadata SecondaryEntityMetadata
        {
            get
            {
                return secondaryEntityMetadata;
            }
            set
            {
                secondaryEntityMetadata = value;
            }
        }

        /// <summary>
        /// Query SDK Message Filter.
        /// </summary>
        private QueryExpression querySdkMessageFilter;

        /// <summary>
        /// Query SDK Message Filter.
        /// </summary>
        private QueryExpression QuerySdkMessageFilter
        {
            get
            {
                return querySdkMessageFilter;
            }
            set
            {
                querySdkMessageFilter = value;
            }
        }

        /// <summary>
        /// SDK Message Filter Entity Collection
        /// </summary>
        private EntityCollection sdkMessageFilterEntityCollection;

        /// <summary>
        /// SDK Message Filter Entity Collection
        /// </summary>
        private EntityCollection SdkMessageFilterEntityCollection
        {
            get
            {
                return sdkMessageFilterEntityCollection;
            }
            set
            {
                sdkMessageFilterEntityCollection = value;
            }
        }

        /// <summary>
        /// SDK Message Id.
        /// </summary>
        private Guid _sdkMessageId;

        /// <summary>
        /// SDK Message Id.
        /// </summary>
        private Guid SdkMessageId
        {
            get
            {
                return _sdkMessageId;
            }
            set
            {
                _sdkMessageId = value;
            }
        }

        /// <summary>
        /// Query SDK Message.
        /// </summary>
        private QueryByAttribute _querySdkMessage;

        /// <summary>
        /// Query SDK Message.
        /// </summary>
        private QueryByAttribute QuerySdkMessage
        {
            get
            {
                return _querySdkMessage;
            }
            set
            {
                _querySdkMessage = value;
            }
        }

        /// <summary>
        /// SDK Message Entity Collection.
        /// </summary>
        private EntityCollection _sdkMessageEntityCollection;

        /// <summary>
        /// SDK Message Entity Collection.
        /// </summary>
        private EntityCollection SdkMessageEntityCollection
        {
            get
            {
                return _sdkMessageEntityCollection;
            }
            set
            {
                _sdkMessageEntityCollection = value;
            }
        }

        /// <summary>
        /// SDK Message.
        /// </summary>
        private SdkMessage _sdkMessage;

        /// <summary>
        /// SDK Message.
        /// </summary>
        private SdkMessage SdkMessage
        {
            get
            {
                return _sdkMessage;
            }
            set
            {
                _sdkMessage = value;
            }
        }

        /// <summary>
        /// SDK Message Filter.
        /// </summary>
        private SdkMessageFilter sdkMessageFilter;

        /// <summary>
        /// SDK Message Filter.
        /// </summary>
        private SdkMessageFilter SdkMessageFilter
        {
            get
            {
                return sdkMessageFilter;
            }
            set
            {
                sdkMessageFilter = value;
            }
        }

        /// <summary>
        /// Secure Configuration Id.
        /// </summary>
        private Guid? _secureConfigurationId;

        /// <summary>
        /// Secure Configuration Id.
        /// </summary>
        private Guid? SecureConfigurationId
        {
            get
            {
                return _secureConfigurationId;
            }
            set
            {
                _secureConfigurationId = value;
            }
        }

        /// <summary>
        /// XRM Metadata.
        /// </summary>
        private XrmSolution xrmSolution;

        /// <summary>
        /// XRM Metadata.
        /// </summary>
        private XrmSolution XrmSolution
        {
            get
            {
                return xrmSolution;
            }
            set
            {
                xrmSolution = value;
            }
        }

        #endregion

        #region Step Methods

        /// <summary>
        /// Add Step to Solution Method.
        /// </summary>
        /// <param name="registrationCollection">Registration Collection.</param>
        /// <param name="registration">Registration.</param>
        /// <param name="step">Step.</param>
        internal void AddStepToSolution(AssemblyRegistration registrationCollection, Registration registration, XrmPluginStep step)
        {
            if (!string.IsNullOrEmpty(registration.SolutionUniqueName) && step.StepId.HasValue)
            {
                XrmSolution = new XrmSolution(registrationCollection.ConnectionString);
                XrmSolution.AddComponentToSolution(SolutionComponentType.SDKMessageProcessingStep, step.StepId.Value, registration.SolutionUniqueName);
            }
        }

        /// <summary>
        /// Method to retrieve Steps according to the Registration Object.
        /// </summary>
        /// <param name="plugin">The Registration Object, which indicates which Steps to retrieve.</param>
        /// <param name="xrmPlugin">The Plugin Object to populate with the Steps retrieved.</param>
        /// <param name="pluginName">The Name of the Plugin for which to retrieve Steps.</param>
        /// <param name="pluginExists">An object containing the Identifier of the Plugin and if the Plugin exists.</param>
        internal XrmPlugin GetPluginSteps(string xrmServerDetails, Plugin plugin, XrmPlugin xrmPlugin, string pluginName, ItemExists pluginExists)
        {
            try
            {
                foreach (PluginStep step in plugin.Steps)
                {
                    if (plugin.PluginName == pluginName)
                    {
                        XrmPluginStep xrmPluginStep = new XrmPluginStep();
                        xrmPluginStep.PluginId = pluginExists.ItemId;
                        if (!string.IsNullOrEmpty(step.Name))
                        {
                            xrmPluginStep.Name = step.Name;
                        }
                        else
                        {
                            xrmPluginStep.Name = pluginName + ": " + step.PluginMessage + " of " + step.PrimaryEntity;
                            if (!string.IsNullOrEmpty(step.SecondaryEntity))
                            {
                                xrmPluginStep.Name += " and " + step.SecondaryEntity;
                            }
                        }
                        if (!string.IsNullOrEmpty(step.Description))
                        {
                            xrmPluginStep.Description = step.Description;
                        }
                        else
                        {
                            xrmPluginStep.Description = xrmPluginStep.Name;
                        }
                        using (xrmService = RegistrationService.GetService(xrmServerDetails))
                        {
                            xrmPluginStep.MessageEntityId = GetSdkMessageEntityId(xrmServerDetails, step, xrmService);
                            xrmPluginStep.MessageId = GetSdkMessageId(step, xrmService);
                            xrmPluginStep.ImpersonatingUserId = GetImpersonatingUserId(step, xrmService);
                            ItemExists stepDetails = GetStepId(step, xrmPluginStep, xrmService);
                            xrmPluginStep.StepId = stepDetails.ItemId;
                            xrmPluginStep.Exists = stepDetails.Exists;
                            if (!string.IsNullOrEmpty(step.SecureConfiguration))
                            {
                                xrmPluginStep.SecureConfiguration = new XrmSecureConfiguration();
                                xrmPluginStep.SecureConfiguration.SecureConfiguration = step.SecureConfiguration;
                                xrmPluginStep.SecureConfiguration.SecureConfigurationId = stepDetails.SecureConfigId;
                            }
                        }
                        xrmPluginStep.UnsecureConfiguration = step.UnsecureConfiguration;
                        xrmPluginStep.Mode = step.Mode;
                        xrmPluginStep.Rank = step.Rank;
                        xrmPluginStep.InvocationSource = step.InvocationSource;
                        xrmPluginStep.Stage = step.Stage;
                        xrmPluginStep.Deployment = step.Deployment;
                        xrmPluginStep = ImageHelper.GetRegistrationImages(xrmServerDetails, step, xrmPluginStep);
                        xrmPlugin.Steps.Add(xrmPluginStep);
                    }
                }
                return xrmPlugin;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to Register a step.
        /// </summary>
        /// <param name="xrmPluginStep">The Step to Register.</param>
        /// <returns>The Identifier of the Registered Step.</returns>
        internal Guid RegisterStep(string xrmServerDetails, XrmPluginStep xrmPluginStep)
        {
            try
            {
                using (xrmService = RegistrationService.GetService(xrmServerDetails))
                {
                    SdkMessageProcessingStep sdkMessageProcessingStep = GetPluginStep(xrmPluginStep);
                    return xrmService.Create(sdkMessageProcessingStep);
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to Update a Step.
        /// </summary>
        /// <param name="xrmPluginStep">The Step to Update.</param>
        /// <returns>Result.</returns>
        internal bool UpdateStep(string xrmServerDetails, XrmPluginStep xrmPluginStep)
        {
            try
            {
                Result = false;
                using (xrmService = RegistrationService.GetService(xrmServerDetails))
                {
                    SdkMessageProcessingStep sdkMessageProcessingStep = GetPluginStep(xrmPluginStep);
                    AddSecureConfigIfMissing(xrmPluginStep, sdkMessageProcessingStep);
                    xrmService.Update(sdkMessageProcessingStep);
                }
                Result = true;
                return Result;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to Unregister a Step.
        /// </summary>
        /// <param name="xrmPluginStep">The Step to Unregister.</param>
        /// <returns>Result.</returns>
        internal bool UnregisterStep(string xrmServerDetails, XrmPluginStep xrmPluginStep, Collection<string> errors, SolutionComponentType solutionComponentType)
        {
            try
            {
                Result = RegistrationService.Unregister(xrmServerDetails, SdkMessageProcessingStep.EntityLogicalName, xrmPluginStep.StepId.Value, errors, solutionComponentType);
                return Result;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to add the Secure Configuration on update of the Plugin Step if missing.
        /// </summary>
        /// <param name="xrmPluginStep">The Plugin Step.</param>
        /// <param name="sdkMessageProcessingStep">The SDK Message Processing Step.</param>
        private void AddSecureConfigIfMissing(XrmPluginStep xrmPluginStep, SdkMessageProcessingStep sdkMessageProcessingStep)
        {
            if (xrmPluginStep.SecureConfiguration != null && xrmPluginStep.SecureConfiguration.SecureConfigurationId.HasValue)
            {
                QueryByAttribute queryByAttribute = new QueryByAttribute(SdkMessageProcessingStepSecureConfig.EntityLogicalName)
                {
                    ColumnSet = new ColumnSet(true),
                };
                queryByAttribute.Attributes.Add("sdkmessageprocessingstepsecureconfigid");
                queryByAttribute.Values.Add(sdkMessageProcessingStep.SdkMessageProcessingStepSecureConfigId.Id);
                if (xrmService.RetrieveMultiple(queryByAttribute).Entities.Count == 0)
                {
                    SdkMessageProcessingStepSecureConfig sdkMessageProcessingStepSecureConfig = new SdkMessageProcessingStepSecureConfig();
                    sdkMessageProcessingStepSecureConfig.SdkMessageProcessingStepSecureConfigId = xrmPluginStep.SecureConfiguration.SecureConfigurationId;
                    sdkMessageProcessingStepSecureConfig.SecureConfig = xrmPluginStep.SecureConfiguration.SecureConfiguration;
                    xrmService.Create(sdkMessageProcessingStepSecureConfig);
                }
            }
        }

        /// <summary>
        /// Method to verify if a Step is already Registered in Dynamics CRM.
        /// </summary>
        /// <param name="step">The Step to verify.</param>
        /// <param name="xrmPluginStep">The Step to populate.</param>
        /// <param name="service">The XRM Service.</param>
        /// <returns>An object containing the details of the verification, including a new Step Identifier if the Step isn't Registered.</returns>
        private ItemExists GetStepId(PluginStep step, XrmPluginStep xrmPluginStep, XrmService service)
        {
            try
            {
                ItemExists stepDetails = new ItemExists();
                stepDetails.SecureConfigId = new Guid?();
                stepDetails.ItemId = new Guid();
                stepDetails.Exists = false;
                QueryByAttribute querySdkProcessingStepMessage = new QueryByAttribute(SdkMessageProcessingStep.EntityLogicalName);
                querySdkProcessingStepMessage.ColumnSet = new ColumnSet(true);
                querySdkProcessingStepMessage.AddAttributeValue("name", xrmPluginStep.Name);
                EntityCollection sdkMessageProcessingStepEntityCollection = service.RetrieveMultiple(querySdkProcessingStepMessage);
                if (sdkMessageProcessingStepEntityCollection.Entities.Count != 0)
                {
                    foreach (Entity entity in sdkMessageProcessingStepEntityCollection.Entities)
                    {
                        SdkMessageProcessingStep sdkMessageProcessingStep = (SdkMessageProcessingStep)entity;
                        if (sdkMessageProcessingStep.SdkMessageProcessingStepId.HasValue)
                        {
                            stepDetails.ItemId = sdkMessageProcessingStep.SdkMessageProcessingStepId.Value;
                            stepDetails.Exists = true;
                        }
                        else
                        {
                            stepDetails.ItemId = Guid.NewGuid();
                            stepDetails.Exists = false;
                        }
                        stepDetails.SecureConfigId = GetSecureConfigId(step, service, stepDetails.SecureConfigId, sdkMessageProcessingStep);
                    }
                }
                else
                {
                    stepDetails.ItemId = Guid.NewGuid();
                    stepDetails.Exists = false;
                    if (!string.IsNullOrEmpty(step.SecureConfiguration))
                    {
                        stepDetails.SecureConfigId = Guid.NewGuid();
                    }
                }
                return stepDetails;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to populate the Dynamics CRM Step Object from the XRM Step Object.
        /// </summary>
        /// <param name="xrmPluginStep">The XRM Step Object from whence to retrieve the Dynamics CRM Step Object.</param>
        /// <returns>The Dynamics CRM Step Object.</returns>
        private SdkMessageProcessingStep GetPluginStep(XrmPluginStep xrmPluginStep)
        {
            try
            {
                SdkMessageProcessingStep = new SdkMessageProcessingStep();
                if (xrmPluginStep.SecureConfiguration != null && !string.IsNullOrEmpty(xrmPluginStep.SecureConfiguration.SecureConfiguration))
                {
                    SdkMessageProcessingStepSecureConfig sdkMessageProcessingStepSecureConfig = new SdkMessageProcessingStepSecureConfig();
                    sdkMessageProcessingStepSecureConfig.SdkMessageProcessingStepSecureConfigId = xrmPluginStep.SecureConfiguration.SecureConfigurationId;
                    sdkMessageProcessingStepSecureConfig.SecureConfig = xrmPluginStep.SecureConfiguration.SecureConfiguration;
                    SdkMessageProcessingStep.SdkMessageProcessingStepSecureConfigId = new EntityReference();
                    SdkMessageProcessingStep.SdkMessageProcessingStepSecureConfigId.LogicalName = SdkMessageProcessingStepSecureConfig.EntityLogicalName;
                    SdkMessageProcessingStep.SdkMessageProcessingStepSecureConfigId.Id = xrmPluginStep.SecureConfiguration.SecureConfigurationId.Value;
                    Relationship relationship = new Relationship(XrmPluginStep.RelationshipStepToSecureConfig);
                    Entity entity = new Entity();
                    entity = (Entity)sdkMessageProcessingStepSecureConfig;
                    EntityCollection entityCollection = new EntityCollection();
                    entityCollection.Entities.Add(entity);
                    SdkMessageProcessingStep.RelatedEntities[relationship] = entityCollection;
                }
                SdkMessageProcessingStep.Configuration = xrmPluginStep.UnsecureConfiguration;
                if (xrmPluginStep.ServiceBusConfigurationId == Guid.Empty)
                {
                    SdkMessageProcessingStep.EventHandler = new EntityReference(PluginType.EntityLogicalName, xrmPluginStep.PluginId);
                }
                else
                {
                    SdkMessageProcessingStep.EventHandler = new EntityReference(ServiceEndpoint.EntityLogicalName, xrmPluginStep.ServiceBusConfigurationId);
                }
                SdkMessageProcessingStep.Name = xrmPluginStep.Name;
                SdkMessageProcessingStep.SdkMessageProcessingStepId = xrmPluginStep.StepId;
                SdkMessageProcessingStep.Mode = new OptionSetValue();
                SdkMessageProcessingStep.Mode.Value = (int)xrmPluginStep.Mode;
                SdkMessageProcessingStep.Rank = xrmPluginStep.Rank;
                if (xrmPluginStep.InvocationSource != null)
                {
#pragma warning disable 0612
                    SdkMessageProcessingStep.InvocationSource = new OptionSetValue((int)xrmPluginStep.InvocationSource);
#pragma warning restore 0612
                }
                SdkMessageProcessingStep.SdkMessageId = new EntityReference();
                SdkMessageProcessingStep.SdkMessageId.LogicalName = SdkMessage.EntityLogicalName;
                SdkMessageProcessingStep.SdkMessageFilterId = new EntityReference();
                SdkMessageProcessingStep.SdkMessageFilterId.LogicalName = SdkMessageFilter.EntityLogicalName;
                if (xrmPluginStep.MessageId == Guid.Empty)
                {
                    SdkMessageProcessingStep.SdkMessageId = null;
                }
                else
                {
                    SdkMessageProcessingStep.SdkMessageId.Id = xrmPluginStep.MessageId;
                }
                if (xrmPluginStep.MessageEntityId == Guid.Empty)
                {
                    SdkMessageProcessingStep.SdkMessageFilterId = null;
                }
                else
                {
                    SdkMessageProcessingStep.SdkMessageFilterId.Id = xrmPluginStep.MessageEntityId;
                }
                SdkMessageProcessingStep.ImpersonatingUserId = new EntityReference();
                SdkMessageProcessingStep.ImpersonatingUserId.LogicalName = SystemUser.EntityLogicalName;
                if (xrmPluginStep.ImpersonatingUserId != Guid.Empty)
                {
                    SdkMessageProcessingStep.ImpersonatingUserId.Id = xrmPluginStep.ImpersonatingUserId;
                }
                else
                {
                    SdkMessageProcessingStep.ImpersonatingUserId = null;
                }
                SdkMessageProcessingStep.Stage = new OptionSetValue();
                SdkMessageProcessingStep.Stage.Value = (int)xrmPluginStep.Stage;
                SdkMessageProcessingStep.SupportedDeployment = new OptionSetValue();
                SdkMessageProcessingStep.SupportedDeployment.Value = (int)xrmPluginStep.Deployment;
                if (string.IsNullOrEmpty(xrmPluginStep.FilteringAttributes))
                {
                    SdkMessageProcessingStep.FilteringAttributes = string.Empty;
                }
                else
                {
                    SdkMessageProcessingStep.FilteringAttributes = xrmPluginStep.FilteringAttributes;
                }
                SdkMessageProcessingStep.AsyncAutoDelete = xrmPluginStep.DeleteAsyncOperationIfSuccessful;
                SdkMessageProcessingStep.Description = xrmPluginStep.Description;
                return SdkMessageProcessingStep;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to retrieve the Secure Configuration Identifier.
        /// </summary>
        /// <param name="step">The XRM Step Object.</param>
        /// <param name="service">The XRM Service.</param>
        /// <param name="secureConfigurationId">The Secure Configuration Identifier.</param>
        /// <param name="sdkMessageProcessingStep">The Dynamics CRM Step Object.</param>
        /// <returns>The Secure Configuration Identifier.</returns>
        private Guid? GetSecureConfigId(PluginStep step, XrmService service, Guid? secureConfigurationId, SdkMessageProcessingStep sdkMessageProcessingStep)
        {
            try
            {
                if (!string.IsNullOrEmpty(step.SecureConfiguration))
                {
                    if (sdkMessageProcessingStep.SdkMessageProcessingStepSecureConfigId != null)
                    {
                        SecureConfigurationId = sdkMessageProcessingStep.SdkMessageProcessingStepSecureConfigId.Id;
                    }
                    else
                    {
                        SecureConfigurationId = Guid.NewGuid();
                    }
                }
                else
                {
                    if (sdkMessageProcessingStep.SdkMessageProcessingStepSecureConfigId != null)
                    {
                        service.Delete(SdkMessageProcessingStepSecureConfig.EntityLogicalName, sdkMessageProcessingStep.SdkMessageProcessingStepSecureConfigId.Id);
                    }
                }
                secureConfigurationId = SecureConfigurationId;
                return secureConfigurationId;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to retrieve the Impersonating User Identifier.
        /// </summary>
        /// <param name="step">The Step Object containing the user account details.</param>
        /// <param name="service">The XRM Service.</param>
        /// <returns>The Impersonating User Identifier.</returns>
        private Guid GetImpersonatingUserId(PluginStep step, XrmService service)
        {
            try
            {
                ImpersonatingUserId = new Guid();
                QuerySystemUser = new QueryByAttribute(SystemUser.EntityLogicalName);
                QuerySystemUser.AddAttributeValue("domainname", step.ImpersonatingUserDomainName);
                SystemUserEntityCollection = service.RetrieveMultiple(QuerySystemUser);
                foreach (Entity entity in SystemUserEntityCollection.Entities)
                {
                    User = (SystemUser)entity;
                    if (User.SystemUserId.HasValue)
                    {
                        ImpersonatingUserId = User.SystemUserId.Value;
                    }
                    else
                    {
                        throw new ArgumentException("The user could not be found!");
                    }
                }
                return ImpersonatingUserId;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to retrieve the SDK Message Identifier.
        /// </summary>
        /// <param name="step">The Step Object.</param>
        /// <param name="service">The XRM Service.</param>
        /// <returns>The SDK Message Identifier.</returns>
        private Guid GetSdkMessageId(PluginStep step, XrmService service)
        {
            try
            {
                SdkMessageId = new Guid();
                QuerySdkMessage = new QueryByAttribute(SdkMessage.EntityLogicalName);
                QuerySdkMessage.AddAttributeValue("name", step.PluginMessage);
                SdkMessageEntityCollection = service.RetrieveMultiple(QuerySdkMessage);
                foreach (Entity entity in SdkMessageEntityCollection.Entities)
                {
                    SdkMessage = (SdkMessage)entity;
                    if (SdkMessage.SdkMessageId.HasValue)
                    {
                        SdkMessageId = SdkMessage.SdkMessageId.Value;
                    }
                    else
                    {
                        throw new ArgumentException("The message could not be found!");
                    }
                }
                return SdkMessageId;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to retrieve the SDK Message Filter Identifier.
        /// </summary>
        /// <param name="registration">The Registration Object.</param>
        /// <param name="step">The Step Object</param>
        /// <param name="service">The XRM Service.</param>
        /// <returns>The SDK Message Filter Identifier.</returns>
        private Guid GetSdkMessageEntityId(string xrmServerDetails, PluginStep step, XrmService service)
        {
            try
            {
                SdkMessageEntityId = new Guid();
                XrmMetadata = new XrmMetadata(xrmServerDetails);
                PrimaryEntityMetadata = XrmMetadata.RetrieveEntity(step.PrimaryEntity);
                SecondaryEntityMetadata = new EntityMetadata();
                if (!string.IsNullOrEmpty(step.SecondaryEntity))
                {
                    SecondaryEntityMetadata = XrmMetadata.RetrieveEntity(step.SecondaryEntity);
                }
                if (PrimaryEntityMetadata.MetadataId.HasValue)
                {
                    QuerySdkMessageFilter = new QueryExpression
                    {
                        EntityName = SdkMessageFilter.EntityLogicalName,
                        ColumnSet = new ColumnSet("sdkmessagefilterid"),
                        Criteria = new FilterExpression()
                    };
                    QuerySdkMessageFilter.Criteria.AddCondition("sdkmessageidname", ConditionOperator.Equal, step.PluginMessage);
                    QuerySdkMessageFilter.Criteria.AddCondition("primaryobjecttypecode", ConditionOperator.Equal, PrimaryEntityMetadata.ObjectTypeCode);
                    if (SecondaryEntityMetadata.MetadataId.HasValue)
                    {
                        QuerySdkMessageFilter.Criteria.AddCondition("secondaryobjecttypecode", ConditionOperator.Equal, SecondaryEntityMetadata.ObjectTypeCode);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(step.SecondaryEntity))
                        {
                            throw new ArgumentException("The secondary entity could not be found!");
                        }
                    }
                    SdkMessageFilterEntityCollection = service.RetrieveMultiple(QuerySdkMessageFilter);
                    foreach (Entity entity in SdkMessageFilterEntityCollection.Entities)
                    {
                        SdkMessageFilter = (SdkMessageFilter)entity;
                        if (SdkMessageFilter.SdkMessageFilterId.HasValue)
                        {
                            SdkMessageEntityId = SdkMessageFilter.SdkMessageFilterId.Value;
                        }
                        else
                        {
                            throw new ArgumentException("The message filter could not be found!");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("The primary entity could not be found!");
                }
                return SdkMessageEntityId;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to Unregister a Secure Configuration.
        /// Unfortunately, the Secure Configuration is not automatically Unregistered when a Step is Unregistered.
        /// </summary>
        /// <param name="xrmSecureConfiguration">The Secure Configuration to Unregister.</param>
        /// <returns>Result.</returns>
        internal bool UnregisterSecureConfiguration(string xrmServerDetails, XrmSecureConfiguration xrmSecureConfiguration, Collection<string> errors, SolutionComponentType solutionComponentType)
        {
            try
            {
                Result = RegistrationService.Unregister(xrmServerDetails, SdkMessageProcessingStepSecureConfig.EntityLogicalName, xrmSecureConfiguration.SecureConfigurationId.Value, errors, solutionComponentType);
                return Result;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        #endregion
    }
}
