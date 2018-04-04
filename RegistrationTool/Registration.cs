using System.Collections.ObjectModel;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The Registration Class.
    /// The Registration Class contains all the information about an Assembly that needs to be registered in Dynamics CRM.
    /// The Assembly will included one or more Plugins.
    /// Each Plugin will include one or more Steps and Secure Configurations.
    /// Each Step will possibly include one or more Images.
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// The Assembly Path String Property.
        /// </summary>
        private string _assemblyPath;

        /// <summary>
        /// The Assembly Path String Property.
        /// </summary>
        public string AssemblyPath
        {
            get
            {
                return _assemblyPath;
            }
            set
            {
                _assemblyPath = value;
            }
        }

        /// <summary>
        /// The XRM Assembly Source Type Enumerator Property.
        /// </summary>
        private XrmAssemblySourceType _assemblySourceType;

        /// <summary>
        /// The XRM Assembly Source Type Enumerator Property.
        /// </summary>
        public XrmAssemblySourceType AssemblySourceType
        {
            get
            {
                return _assemblySourceType;
            }
            set
            {
                _assemblySourceType = value;
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
        /// A Collection of Plugin.
        /// </summary>
        private Collection<Plugin> _plugins = new Collection<Plugin>();

        /// <summary>
        /// A Collection of Plugin.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugins")]
        public Collection<Plugin> Plugins
        {
            get
            {
                return _plugins;
            }
        }


        /// <summary>
        /// Property containing the Solution's Unique Name to which the Assembly and its associations should be added.
        /// </summary>
        private string _solutionUniqueName;

        /// <summary>
        /// Property containing the Solution's Unique Name to which the Assembly and its associations should be added.
        /// </summary>
        public string SolutionUniqueName
        {
            get
            {
                return _solutionUniqueName;
            }
            set
            {
                _solutionUniqueName = value;
            }
        }
    }
}
