using System;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The XRM Secure Configuration Class.
    /// A Plugin has a Secure Configuration as it cannot have an Application or Web Configuration.
    /// Use the Secure Configuration rather than the Unsecure Configuration where credentials need to be stored.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Xrm")]
    public class XrmSecureConfiguration
    {
        /// <summary>
        /// The Secure Configuration Identifier Property.
        /// </summary>
        private Guid? _secureConfigurationId;

        /// <summary>
        /// The Secure Configuration Identifier Property.
        /// </summary>
        public Guid? SecureConfigurationId
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
        /// The Secure Configuration String Property.
        /// </summary>
        private string _secureConfiguration;

        /// <summary>
        /// The Secure Configuration String Property.
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
    }
}
