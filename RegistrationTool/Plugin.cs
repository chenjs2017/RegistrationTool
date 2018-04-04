using System.Collections.ObjectModel;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The Plugin Class.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
    public class Plugin
    {
        /// <summary>
        /// The Plugin Name String Property.
        /// </summary>
        private string _pluginName;

        /// <summary>
        /// The Plugin Name String Property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
        public string PluginName
        {
            get
            {
                return _pluginName;
            }
            set
            {
                _pluginName = value;
            }
        }

        /// <summary>
        /// Property containing a Collection of Steps to be registered.
        /// The Steps are not included in the Assembly, only the Plugins, and the Steps must be explicitly included.
        /// Each Step will contain Secure Configuration information and Images, if applicable.
        /// </summary>
        private Collection<PluginStep> _steps = new System.Collections.ObjectModel.Collection<PluginStep>();

        /// <summary>
        /// Property containing a Collection of Steps to be registered.
        /// The Steps are not included in the Assembly, only the Plugins, and the Steps must be explicitly included.
        /// Each Step will contain Secure Configuration information and Images, if applicable.
        /// </summary>
        public Collection<PluginStep> Steps
        {
            get
            {
                return _steps;
            }
        }
    }
}
