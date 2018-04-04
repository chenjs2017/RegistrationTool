using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ServiceModel;
using PluginRegistrationTool;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The Plugin and CWA Helper Class.
    /// </summary>
    internal class PluginHelper
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
            set
            {
                _registrationService = value;
            }
        }

        /// <summary>
        /// Step Helper.
        /// </summary>
        private StepHelper _stepHelper = new StepHelper();

        /// <summary>
        /// Step Helper.
        /// </summary>
        private StepHelper StepHelper
        {
            get
            {
                return _stepHelper;
            }
            set
            {
                _stepHelper = value;
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
        /// Image Exception Error Message.
        /// </summary>
        private string _imageExceptionErrorMessage;

        /// <summary>
        /// Image Exception Error Message.
        /// </summary>
        private string ImageExceptionErrorMessage
        {
            get
            {
                return _imageExceptionErrorMessage;
            }
            set
            {
                _imageExceptionErrorMessage = value;
            }
        }

        /// <summary>
        /// Attribute CSV.
        /// </summary>
        private string _attributeCSV;

        /// <summary>
        /// Attribute CSV.
        /// </summary>
        private string AttributeCSV
        {
            get
            {
                return _attributeCSV;
            }
            set
            {
                _attributeCSV = value;
            }
        }

        /// <summary>
        /// Image Details.
        /// </summary>
        private ItemExists _imageDetails;

        /// <summary>
        /// Image Details.
        /// </summary>
        private ItemExists ImageDetails
        {
            get
            {
                return _imageDetails;
            }
            set
            {
                _imageDetails = value;
            }
        }

        /// <summary>
        /// Query SDK Message Processing Step Image.
        /// </summary>
        private QueryExpression _querySdkMessageProcessingStepImage;

        /// <summary>
        /// Query SDK Message Processing Step Image.
        /// </summary>
        private QueryExpression QuerySdkMessageProcessingStepImage
        {
            get
            {
                return _querySdkMessageProcessingStepImage;
            }
            set
            {
                _querySdkMessageProcessingStepImage = value;
            }
        }

        /// <summary>
        /// SDK Message Processing Step Image Entity Collection.
        /// </summary>
        private EntityCollection _sdkMessageProcessingStepImageEntityCollection;

        /// <summary>
        /// SDK Message Processing Step Image Entity Collection.
        /// </summary>
        private EntityCollection SdkMessageProcessingStepImageEntityCollection
        {
            get
            {
                return _sdkMessageProcessingStepImageEntityCollection;
            }
            set
            {
                _sdkMessageProcessingStepImageEntityCollection = value;
            }
        }

        /// <summary>
        /// SDK Message Processing Step Image.
        /// </summary>
        private SdkMessageProcessingStepImage _sdkMessageProcessingStepImage;

        /// <summary>
        /// SDK Message Processing Step Image.
        /// </summary>
        private SdkMessageProcessingStepImage SdkMessageProcessingStepImage
        {
            get
            {
                return _sdkMessageProcessingStepImage;
            }
            set
            {
                _sdkMessageProcessingStepImage = value;
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
        /// Message Property Name.
        /// </summary>
        private string _messagePropertyName;

        /// <summary>
        /// Message Property Name.
        /// </summary>
        private string MessagePropertyName
        {
            get
            {
                return _messagePropertyName;
            }
            set
            {
                _messagePropertyName = value;
            }
        }

        /// <summary>
        /// Plugin Assembly.
        /// </summary>
        private PluginAssembly _pluginAssembly;

        /// <summary>
        /// Plugin Assembly.
        /// </summary>
        private PluginAssembly PluginAssembly
        {
            get
            {
                return _pluginAssembly;
            }
            set
            {
                _pluginAssembly = value;
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
        /// Plugin Type.
        /// </summary>
        private PluginType _pluginType;

        /// <summary>
        /// Plugin Type.
        /// </summary>
        private PluginType PluginType
        {
            get
            {
                return _pluginType;
            }
            set
            {
                _pluginType = value;
            }
        }

        /// <summary>
        /// XRM Assembly.
        /// </summary>
        private ItemExists _xrmAssembly;

        /// <summary>
        /// XRM Assembly.
        /// </summary>
        private ItemExists XrmAssembly
        {
            get
            {
                return _xrmAssembly;
            }
            set
            {
                _xrmAssembly = value;
            }
        }

        /// <summary>
        /// Assembly Query.
        /// </summary>
        private QueryByAttribute _assemblyQuery;

        /// <summary>
        /// Assembly Query.
        /// </summary>
        private QueryByAttribute AssemblyQuery
        {
            get
            {
                return _assemblyQuery;
            }
            set
            {
                _assemblyQuery = value;
            }
        }

        /// <summary>
        /// Assembly Query Results.
        /// </summary>
        private EntityCollection _assemblyQueryResults;

        /// <summary>
        /// Assembly Query Results.
        /// </summary>
        private EntityCollection AssemblyQueryResults
        {
            get
            {
                return _assemblyQueryResults;
            }
            set
            {
                _assemblyQueryResults = value;
            }
        }

        /// <summary>
        /// Plugin.
        /// </summary>
        private ItemExists _plugin;

        /// <summary>
        /// Plugin.
        /// </summary>
        private ItemExists Plugin
        {
            get
            {
                return _plugin;
            }
            set
            {
                _plugin = value;
            }
        }

        /// <summary>
        /// Query Registration Plugin Id.
        /// </summary>
        private QueryByAttribute _queryRegistrationPluginId;

        /// <summary>
        /// Query Registration Plugin Id.
        /// </summary>
        private QueryByAttribute QueryRegistrationPluginId
        {
            get
            {
                return _queryRegistrationPluginId;
            }
            set
            {
                _queryRegistrationPluginId = value;
            }
        }

        /// <summary>
        /// Results Registration Plugin Id.
        /// </summary>
        private EntityCollection _resultsRegistrationPluginId;

        /// <summary>
        /// Results Registration Plugin Id.
        /// </summary>
        private EntityCollection ResultsRegistrationPluginId
        {
            get
            {
                return _resultsRegistrationPluginId;
            }
            set
            {
                _resultsRegistrationPluginId = value;
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
        /// SDK Version.
        /// </summary>
        private Version _sdkVersion;

        /// <summary>
        /// SDK Version.
        /// </summary>
        private Version SdkVersion
        {
            get
            {
                return _sdkVersion;
            }
            set
            {
                _sdkVersion = value;
            }
        }

        /// <summary>
        /// XRM Type.
        /// </summary>
        private Type _xrmType;

        /// <summary>
        /// XRM Type.
        /// </summary>
        private Type XrmType
        {
            get
            {
                return _xrmType;
            }
            set
            {
                _xrmType = value;
            }
        }

        /// <summary>
        /// V4 Type.
        /// </summary>
        private Type _v4Type;

        /// <summary>
        /// V4 Type.
        /// </summary>
        private Type V4Type
        {
            get
            {
                return _v4Type;
            }
            set
            {
                _v4Type = value;
            }
        }

        /// <summary>
        /// Dynamic.
        /// </summary>
        private dynamic _dynamic;

        /// <summary>
        /// Dynamic.
        /// </summary>
        private dynamic Dynamic
        {
            get
            {
                return _dynamic;
            }
            set
            {
                _dynamic = value;
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
        /// Assembly Registration.
        /// </summary>
        private AssemblyRegistration _assemblyRegistration;

        /// <summary>
        /// Assembly Registration.
        /// </summary>
        public AssemblyRegistration AssemblyRegistration
        {
            get
            {
                return _assemblyRegistration;
            }
            set
            {
                _assemblyRegistration = value;
            }
        }

        #endregion

        #region Plugin Methods

        /// <summary>
        /// Method to populate the Plugins according to the Registration Object.
        /// </summary>
        /// <param name="registration">The Registration Object indicating which Plugins to retrieve.</param>
        /// <param name="xrmPluginAssembly">The Assembly object to populate.</param>
        /// <param name="assembly">The Assembly from whence to extract Assembly Details.</param>
        /// <param name="defaultGroupName">The Default Group Name String Property.</param>
        internal XrmPluginAssembly GetRegistrationPlugins(string xrmServerDetails, Registration registration, XrmPluginAssembly xrmPluginAssembly, Assembly assembly, string defaultGroupName)
        {
            try
            {
                foreach (Type type in assembly.GetExportedTypes())
                {
                    if (type.IsAbstract || !type.IsClass)
                    {
                        continue;
                    }
                    foreach (Plugin plugin in registration.Plugins)
                    {
                        if (type.FullName == plugin.PluginName)
                        {
                            XrmPluginType xrmPluginType = XrmPluginType.Plugin;
                            XrmPluginIsolatable xrmPluginIsolatable = XrmPluginIsolatable.Unknown;
                            string workflowGroupName = defaultGroupName;
                            string pluginName = type.FullName;
                            Version sdkVersion = GetSdkVersion(type, ref xrmPluginType, ref xrmPluginIsolatable, ref workflowGroupName, ref pluginName);
                            if (sdkVersion != null)
                            {
                                xrmPluginAssembly.SdkVersion = new Version(sdkVersion.Major, sdkVersion.Minor);
                                XrmPlugin xrmPlugin = new XrmPlugin();
                                xrmPlugin.TypeName = type.FullName;
                                xrmPlugin.Name = pluginName;
                                xrmPlugin.PluginType = xrmPluginType;
                                ItemExists pluginExists = GetRegistrationPluginId(pluginName, xrmServerDetails);
                                xrmPlugin.PluginId = pluginExists.ItemId;
                                xrmPlugin.FriendlyName = pluginExists.ItemId.ToString();
                                xrmPlugin.Exists = pluginExists.Exists;
                                xrmPlugin.AssemblyId = xrmPluginAssembly.AssemblyId;
                                xrmPlugin.AssemblyName = xrmPluginAssembly.Name;
                                xrmPlugin.Isolatable = xrmPluginIsolatable;
                                if (xrmPluginType == XrmPluginType.WorkflowActivity && !string.IsNullOrWhiteSpace(workflowGroupName))
                                {
                                    xrmPlugin.WorkflowActivityGroupName = workflowGroupName;
                                }
                                xrmPlugin = StepHelper.GetPluginSteps(xrmServerDetails, plugin, xrmPlugin, pluginName, pluginExists);
                                xrmPluginAssembly.Plugins.Add(xrmPlugin);
                            }
                        }
                    }
                }
                return xrmPluginAssembly;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to Register a Plugin.
        /// </summary>
        /// <param name="xrmPlugin">The Plugin to Register.</param>
        /// <returns>The Identifier of the newly Registered Plugin.</returns>
        internal Guid RegisterPlugin(string xrmServerDetails, XrmPlugin xrmPlugin, Collection<string> errors)
        {
            try
            {
                using (xrmService = RegistrationService.GetService(xrmServerDetails))
                {
                    PluginType pluginType = GetPluginType(xrmPlugin);
                    return xrmService.Create(pluginType);
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> e)
            {
                if (e.Message == "Plug-in assembly does not contain the required types or assembly content cannot be updated.")
                {
                    errors.Add("Attempt to register a Type in the Assembly failed because it is not a Plugin. Type is: " + xrmPlugin.Name);
                    return Guid.Empty;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Method to Update a Plugin Registration.
        /// </summary>
        /// <param name="xrmPlugin">The Plugin to Update.</param>
        /// <returns>Result.</returns>
        internal bool UpdatePlugin(string xrmServerDetails, XrmPlugin xrmPlugin)
        {
            try
            {
                Result = false;
                using (xrmService = RegistrationService.GetService(xrmServerDetails))
                {
                    PluginType pluginType = GetPluginType(xrmPlugin);
                    xrmService.Update(pluginType);
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
        /// Method to Unregister a Plugin.
        /// </summary>
        /// <param name="xrmPlugin">The Plugin to Unregister.</param>
        /// <returns>Result.</returns>
        internal bool UnregisterPlugin(string xrmServerDetails, XrmPlugin xrmPlugin, Collection<string> errors, SolutionComponentType solutionComponentType)
        {
            try
            {
                Result = RegistrationService.Unregister(xrmServerDetails, PluginType.EntityLogicalName, xrmPlugin.PluginId, errors, solutionComponentType);
                return Result;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to retrieve the Plugins from the Assembly Object.
        /// </summary>
        /// <param name="xrmPlugin">The Plugin Assembly Object.</param>
        /// <returns>The Dynamics CRM Plugin.</returns>
        private PluginType GetPluginType(XrmPlugin xrmPlugin)
        {
            try
            {
                PluginType = new PluginType()
                {
                    PluginTypeId = xrmPlugin.PluginId,
                    PluginAssemblyId = new EntityReference()
                    {
                        LogicalName = PluginAssembly.EntityLogicalName,
                        Id = xrmPlugin.AssemblyId
                    },
                    TypeName = xrmPlugin.TypeName,
                    FriendlyName = xrmPlugin.FriendlyName,
                    Name = xrmPlugin.Name,
                    Description = xrmPlugin.Description,
                    WorkflowActivityGroupName = xrmPlugin.WorkflowActivityGroupName
                };
                return PluginType;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to retrieve the Version of the Plugin Assembly
        /// </summary>
        /// <param name="xrmPluginAssembly">The Plugin Assembly from whence to retrieve the Version.</param>
        /// <param name="type">The Assembly Type being interrogated.</param>
        /// <param name="xrmPluginType">The Plugin Type Enumerator.</param>
        /// <param name="xrmPluginIsolatable">The Plugin Isolatable Enumerator.</param>
        /// <param name="workflowGroupName">The CWA Name.</param>
        /// <param name="pluginName">The Plugin Name.</param>
        /// <returns></returns>
        private Version GetSdkVersion(Type type, ref XrmPluginType xrmPluginType, ref XrmPluginIsolatable xrmPluginIsolatable, ref string workflowGroupName, ref string pluginName)
        {
            try
            {
                SdkVersion = null;
                XrmType = type.GetInterface(typeof(IPlugin).FullName);
                V4Type = type.GetInterface("Microsoft.Crm.Sdk.IPlugin");
                if (XrmType != null)
                {
                    xrmPluginType = XrmPluginType.Plugin;
                    xrmPluginIsolatable = XrmPluginIsolatable.Yes;
                    SdkVersion = XrmType.Assembly.GetName().Version;
                }
                else if (V4Type != null)
                {
                    xrmPluginType = XrmPluginType.Plugin;
                    xrmPluginIsolatable = XrmPluginIsolatable.No;
                    SdkVersion = new Version(4, 0);
                }
                else if (type.IsSubclassOf(typeof(System.Activities.Activity)) || type.IsSubclassOf(typeof(System.Activities.Activity)))
                {
                    xrmPluginType = XrmPluginType.WorkflowActivity;
                    xrmPluginIsolatable = XrmPluginIsolatable.No;
                    SdkVersion = new Version();
                    if (type.IsSubclassOf(typeof(System.Activities.Activity)))
                    {
                        foreach (Attribute attribute in type.GetCustomAttributes(true))
                        {
                            if (attribute != null && (attribute.GetType().FullName == "Microsoft.Crm.Workflow.CrmWorkflowActivityAttribute"))
                            {
                                Dynamic = attribute;
                                workflowGroupName = Dynamic.GroupName;
                                pluginName = Dynamic.Name;
                                break;
                            }
                        }
                    }
                }
                return SdkVersion;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        private ItemExists GetRegistrationPluginId(string pluginName, string xrmServerDetails)
        {
            using (xrmService = RegistrationService.GetService(xrmServerDetails))
            {
                Plugin = new ItemExists();
                QueryRegistrationPluginId = new QueryByAttribute(PluginType.EntityLogicalName);
                QueryRegistrationPluginId.ColumnSet = new ColumnSet();
                QueryRegistrationPluginId.AddAttributeValue("typename", pluginName);
                ResultsRegistrationPluginId = xrmService.RetrieveMultiple(QueryRegistrationPluginId);
                if (ResultsRegistrationPluginId.Entities != null && ResultsRegistrationPluginId.Entities.Count > 0)
                {
                    Plugin.ItemId = ResultsRegistrationPluginId.Entities[0].Id;
                    Plugin.Exists = true;
                }
                else
                {
                    Plugin.ItemId = Guid.NewGuid();
                    Plugin.Exists = false;
                }
                return Plugin;
            }
        }

        #endregion
    }
}
