using System;
using System.Collections.ObjectModel;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The XRM Plugin Assembly Class.
    /// An Assembly that contain alls the Plugin details.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Xrm"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
    public class XrmPluginAssembly
    {
        /// <summary>
        /// The Assembly Identifier Property.
        /// </summary>
        private Guid _assemblyId;

        /// <summary>
        /// The Assembly Identifier Property.
        /// </summary>
        public Guid AssemblyId
        {
            get
            {
                return _assemblyId;
            }
            set
            {
                _assemblyId = value;
            }
        }

        /// <summary>
        /// The Assembly's Name String Property.
        /// </summary>
        private string _name;

        /// <summary>
        /// The Assembly's Name String Property.
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
        /// The XRM Assembly Source Type Enumerator Property.
        /// </summary>
        private XrmAssemblySourceType _sourceType;

        /// <summary>
        /// The XRM Assembly Source Type Enumerator Property.
        /// </summary>
        public XrmAssemblySourceType SourceType
        {
            get 
            { 
                return _sourceType; 
            }
            set 
            {
                _sourceType = value; 
            }
        }

        /// <summary>
        /// The XRM Isolation Mode Enumerator Property.
        /// </summary>
        private XrmIsolationMode _isolationMode;

        /// <summary>
        /// The XRM Isolation Mode Enumerator Property.
        /// </summary>
        public XrmIsolationMode IsolationMode
        {
            get 
            { 
                return _isolationMode; 
            }
            set 
            { 
                _isolationMode = value; 
            }
        }

        /// <summary>
        /// The Culture String Property.
        /// </summary>
        private string _culture;

        /// <summary>
        /// The Culture String Property.
        /// </summary>
        public string Culture
        {
            get 
            { 
                return _culture; 
            }
            set 
            { 
                _culture = value; 
            }
        }

        /// <summary>
        /// The Public Key Token String Property.
        /// </summary>
        private string _publicKeyToken;

        /// <summary>
        /// The Public Key Token String Property.
        /// </summary>
        public string PublicKeyToken
        {
            get 
            { 
                return _publicKeyToken; 
            }
            set 
            { 
                _publicKeyToken = value; 
            }
        }

        /// <summary>
        /// The Version String Property.
        /// </summary>
        private string _version;

        /// <summary>
        /// The Version String Property.
        /// </summary>
        public string Version
        {
            get 
            { 
                return _version; 
            }
            set 
            { 
                _version = value; 
            }
        }

        /// <summary>
        /// The Description String Property.
        /// </summary>
        private string _description;

        /// <summary>
        /// The Description String Property.
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
        /// The Server File Name String Property.
        /// </summary>
        private string _serverFileName;

        /// <summary>
        /// The Server File Name String Property.
        /// </summary>
        public string ServerFileName
        {
            get 
            { 
                return _serverFileName; 
            }
            set 
            { 
                _serverFileName = value; 
            }
        }

        /// <summary>
        /// A Property containing a collection of Xrm Plugin.
        /// This collection will be the Plugins within the Assembly.
        /// </summary>
        private Collection<XrmPlugin> _plugins = new Collection<XrmPlugin>();

        /// <summary>
        /// A Property containing a collection of Xrm Plugin.
        /// This collection will be the Plugins within the Assembly.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugins")]
        public Collection<XrmPlugin> Plugins
        {
            get 
            { 
                return _plugins; 
            }
        }

        /// <summary>
        /// The SDK Version Version Property.
        /// </summary>
        private Version _sdkVersion;

        /// <summary>
        /// The SDK Version Version Property.
        /// </summary>
        public Version SdkVersion
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
        /// The Path String Property.
        /// The Path to the Assembly.
        /// </summary>
        private string _path;

        /// <summary>
        /// The Path String Property.
        /// The Path to the Assembly.
        /// </summary>
        public string Path
        {
            get 
            { 
                return _path; 
            }
            set 
            { 
                _path = value; 
            }
        }

        /// <summary>
        /// Boolean Property indicating if the Assembly is already registered in Dynamics CRM.
        /// </summary>
        private bool _exists;

        /// <summary>
        /// Boolean Property indicating if the Assembly is already registered in Dynamics CRM.
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
    }
}
