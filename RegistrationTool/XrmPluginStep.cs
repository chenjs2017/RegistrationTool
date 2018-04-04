using System;
using System.Collections.ObjectModel;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The XRM Plugin Step Class.
    /// A Plugin can have multiple Steps that define when the Plugin is triggered.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Xrm"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
    public class XrmPluginStep
    {
        /// <summary>
        /// Constant String for the Name of the Relationship between the Step and the Secure Configuration.
        /// </summary>
        public const string RelationshipStepToSecureConfig = "sdkmessageprocessingstepsecureconfigid_sdkmessageprocessingstep";

        /// <summary>
        /// The Plugin Identifier Property.
        /// This links the Step to its Plugin.
        /// </summary>
        private Guid _pluginId;

        /// <summary>
        /// The Plugin Identifier Property.
        /// This links the Step to its Plugin.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
        public Guid PluginId
        {
            get
            {
                return _pluginId;
            }
            set
            {
                _pluginId = value;
            }
        }

        /// <summary>
        /// The Unsecure Configuration String Property.
        /// As the Plugin cannot use an Application or Web Configuration, an Unsecure Configuration can be used.
        /// Use the Unsecure Configuration when no credentials are being stored.
        /// </summary>
        private string _unsecureConfiguration;

        /// <summary>
        /// The Unsecure Configuration String Property.
        /// As the Plugin cannot use an Application or Web Configuration, an Unsecure Configuration can be used.
        /// Use the Unsecure Configuration when no credentials are being stored.
        /// </summary>
        public string UnsecureConfiguration
        {
            get
            {
                return _unsecureConfiguration;
            }
            set
            {
                _unsecureConfiguration = value;
            }
        }

        /// <summary>
        /// The Secure Configuration String Property.
        /// As the Plugin cannot use an Application or Web Configuration, a Secure Configuration can be used.
        /// Use the Secure Configuration when credentials are being stored.
        /// </summary>
        private XrmSecureConfiguration _secureConfiguration;

        /// <summary>
        /// The Secure Configuration String Property.
        /// As the Plugin cannot use an Application or Web Configuration, a Secure Configuration can be used.
        /// Use the Secure Configuration when credentials are being stored.
        /// </summary>
        public XrmSecureConfiguration SecureConfiguration
        {
            get
            {
                return _secureConfiguration;
            }
            set
            {
                _secureConfiguration = value;
            }
        }

        /// <summary>
        /// The Step Identifier Property.
        /// </summary>
        private Guid? _stepId;

        /// <summary>
        /// The Step Identifier Property.
        /// </summary>
        public Guid? StepId
        {
            get
            {
                return _stepId;
            }
            set
            {
                _stepId = value;
            }
        }

        /// <summary>
        /// The Service Bus Configuration Identifier Property.
        /// </summary>
        private Guid _serviceBusConfigurationId;

        /// <summary>
        /// The Service Bus Configuration Identifier Property.
        /// </summary>
        public Guid ServiceBusConfigurationId
        {
            get
            {
                return _serviceBusConfigurationId;
            }
            set
            {
                _serviceBusConfigurationId = value;
            }
        }

        /// <summary>
        /// The Step's Name String Property.
        /// </summary>
        private string _name;

        /// <summary>
        /// The Step's Name String Property.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// The XRM Plugin Step Mode Enumerator Property.
        /// </summary>
        private XrmPluginStepMode _mode;

        /// <summary>
        /// The XRM Plugin Step Mode Enumerator Property.
        /// </summary>
        public XrmPluginStepMode Mode
        {
            get
            {
                return _mode;
            }
            set
            {
                _mode = value;
            }
        }

        /// <summary>
        /// The Step's Rank Integer Property.
        /// </summary>
        private int? _rank;

        /// <summary>
        /// The Step's Rank Integer Property.
        /// </summary>
        public int? Rank
        {
            get
            {
                return _rank;
            }
            set
            {
                _rank = value;
            }
        }

        /// <summary>
        /// The nullable XRM Plugin Step Invocation Source Enumerator Property.
        /// </summary>
        private XrmPluginStepInvocationSource? _invocationSource;

        /// <summary>
        /// The nullable XRM Plugin Step Invocation Source Enumerator Property.
        /// </summary>
        public XrmPluginStepInvocationSource? InvocationSource
        {
            get
            {
                return _invocationSource;
            }
            set
            {
                _invocationSource = value;
            }
        }

        /// <summary>
        /// The SDK Message Identifier Property.
        /// </summary>
        private Guid _messageId;

        /// <summary>
        /// The SDK Message Identifier Property.
        /// </summary>
        public Guid MessageId
        {
            get
            {
                return _messageId;
            }
            set
            {
                _messageId = value;
            }
        }

        /// <summary>
        /// The SDK Message Entity Identifier Property.
        /// </summary>
        private Guid _messageEntityId;

        /// <summary>
        /// The SDK Message Entity Identifier Property.
        /// </summary>
        public Guid MessageEntityId
        {
            get
            {
                return _messageEntityId;
            }
            set
            {
                _messageEntityId = value;
            }
        }

        /// <summary>
        /// The Impersonating User Identifier Property.
        /// </summary>
        private Guid _impersonatingUserId;

        /// <summary>
        /// The Impersonating User Identifier Property.
        /// </summary>
        public Guid ImpersonatingUserId
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
        /// The XRM Plugin Step Stage Enumerator Property.
        /// </summary>
        private XrmPluginStepStage _stage;

        public XrmPluginStepStage Stage
        {
            get
            {
                return _stage;
            }
            set
            {
                _stage = value;
            }
        }

        /// <summary>
        /// The XRM Plugin Step Deployment Enumerator Property.
        /// </summary>
        private XrmPluginStepDeployment _deployment;

        /// <summary>
        /// The XRM Plugin Step Deployment Enumerator Property.
        /// </summary>
        public XrmPluginStepDeployment Deployment
        {
            get
            {
                return _deployment;
            }
            set
            {
                _deployment = value;
            }
        }

        /// <summary>
        /// The Filtering Attributes String Property.
        /// </summary>
        private string _filteringAttributes;

        /// <summary>
        /// The Filtering Attributes String Property.
        /// </summary>
        public string FilteringAttributes
        {
            get
            {
                return _filteringAttributes;
            }
            set
            {
                _filteringAttributes = value;
            }
        }

        /// <summary>
        /// Boolean Property to indicate if the Asynchronous Operation should be deleted after success.
        /// </summary>
        private bool _deleteAsyncOperationIfSuccessful;

        /// <summary>
        /// Boolean Property to indicate if the Asynchronous Operation should be deleted after success.
        /// </summary>
        public bool DeleteAsyncOperationIfSuccessful
        {
            get
            {
                return _deleteAsyncOperationIfSuccessful;
            }
            set
            {
                _deleteAsyncOperationIfSuccessful = value;
            }
        }

        /// <summary>
        /// The Step's Description String Property.
        /// </summary>
        private string _description;

        /// <summary>
        /// The Step's Description String Property.
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /// <summary>
        /// Boolean Property indicating if the Step is already registered in Dynamics CRM.
        /// </summary>
        private bool _exists;

        /// <summary>
        /// Boolean Property indicating if the Step is already registered in Dynamics CRM.
        /// </summary>
        public bool Exists
        {
            get
            {
                return _exists;
            }
            set
            {
                _exists = value;
            }
        }

        /// <summary>
        /// Property providing a collection of Images linked to the Step.
        /// </summary>
        private Collection<XrmPluginImage> _images = new Collection<XrmPluginImage>();

        /// <summary>
        /// Property providing a collection of Images linked to the Step.
        /// </summary>
        public Collection<XrmPluginImage> Images
        {
            get
            {
                return _images;
            }
        }
    }
}
