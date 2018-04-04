using System.Collections.ObjectModel;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The PluginStep Class.
    /// Provide all the information concerning a Step to be registered in Dynamics CRM.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
    public class PluginStep
    {
        /// <summary>
        /// The Unsecure String Property.
        /// </summary>
        private string _unsecureConfiguration;

        /// <summary>
        /// The Unsecure String Property.
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
        /// The Secure String Property.
        /// </summary>
        private string _secureConfiguration;

        /// <summary>
        /// The Secure String Property.
        /// </summary>
        public string SecureConfiguration
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
        /// The Step's Name Property.
        /// </summary>
        private string _name;

        /// <summary>
        /// The Step's Name Property.
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
        /// The XRM Plugin Step Invocation Source Enumerator Property.
        /// </summary>
        private XrmPluginStepInvocationSource _invocationSource;

        /// <summary>
        /// The XRM Plugin Step Invocation Source Enumerator Property.
        /// </summary>
        public XrmPluginStepInvocationSource InvocationSource
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
        /// The Message String Property.
        /// </summary>
        private string _pluginMessage;

        /// <summary>
        /// The Message String Property.
        /// The Message against which the step should be registered.
        /// Note that this is case sensitive.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
        public string PluginMessage
        {
            get
            {
                return _pluginMessage;
            }
            set
            {
                _pluginMessage = value;
            }
        }

        /// <summary>
        /// The Primary Entity String Property.
        /// </summary>
        private string _primaryEntity;

        /// <summary>
        /// The Primary Entity String Property.
        /// The Primary Entity against which the step should be registered.
        /// Note that this is case sensitive and should all be lower case!
        /// </summary>
        public string PrimaryEntity
        {
            get
            {
                return _primaryEntity;
            }
            set
            {
                _primaryEntity = value;
            }
        }

        /// <summary>
        /// The Secondary Entity String Property.
        /// </summary>
        private string _secondaryEntity;

        /// <summary>
        /// The Secondary Entity String Property.
        /// The Secondary Entity against which the step should be registered.
        /// Note that this is case sensitive and should all be lower case!
        /// </summary>
        public string SecondaryEntity
        {
            get
            {
                return _secondaryEntity;
            }
            set
            {
                _secondaryEntity = value;
            }
        }

        /// <summary>
        /// The Impersonating User Domain Name String Property.
        /// </summary>
        private string _impersonatingUserDomainName;

        /// <summary>
        /// The Impersonating User Domain Name String Property.
        /// The domain account to use for impersonation for the plugin step. Please note that this is case sensitive!
        /// If Dynamics CRM has the account as <b>DOMAIN\User</b> and <b>Domain\User</b> is specified, no match will be found!
        /// Check Dynamics CRM to get the correct case sensitivity of the account.
        /// </summary>
        public string ImpersonatingUserDomainName
        {
            get
            {
                return _impersonatingUserDomainName;
            }
            set
            {
                _impersonatingUserDomainName = value;
            }
        }

        /// <summary>
        /// The XRM Plugin Step Stage Enumerator Property.
        /// </summary>
        private XrmPluginStepStage _stage;

        /// <summary>
        /// The XRM Plugin Step Stage Enumerator Property.
        /// </summary>
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
        /// The Step Description String Property.
        /// </summary>
        private string _description;

        /// <summary>
        /// The Step Description String Property.
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
        /// The Property containing the Collection of Images linked to the Step.
        /// </summary>
        private Collection<Image> _images = new Collection<Image>();

        /// <summary>
        /// The Property containing the Collection of Images linked to the Step.
        /// </summary>
        public Collection<Image> Images
        {
            get
            {
                return _images;
            }
        }
    }
}
