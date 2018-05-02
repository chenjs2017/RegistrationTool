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
        public string FilteringAttributes { get; set; }
        public string UnsecureConfiguration { get; set; }
        public string SecureConfiguration { get; set; }
        public string Name { get; set; }
        public XrmPluginStepMode Mode { get; set; }
        public int? Rank { get; set; }
        public XrmPluginStepInvocationSource InvocationSource { get; set; }
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
