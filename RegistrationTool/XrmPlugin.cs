using System;
using System.Collections.ObjectModel;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The XRM Plugin Class.
    /// Contains the details of the Plugin as well as the linked Steps.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Xrm"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
    public class XrmPlugin
    {
        /// <summary>
        /// The Plugin Identifier Property.
        /// </summary>
        private Guid _pluginId;

        /// <summary>
        /// The Plugin Identifier Property.
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
        /// The Assembly Identifier Property.
        /// Indicates the Assembly to which the Plugin belongs.
        /// </summary>
        private Guid _AssemblyId;

        /// <summary>
        /// The Assembly Identifier Property.
        /// Indicates the Assembly to which the Plugin belongs.
        /// </summary>
        public Guid AssemblyId
        {
            get
            {
                return _AssemblyId;
            }
            set
            {
                _AssemblyId = value;
            }
        }

        /// <summary>
        /// The Assembly Name String Property.
        /// The Name of the Assembly to which the Plugin belongs.
        /// </summary>
        private string _assemblyName;

        /// <summary>
        /// The Assembly Name String Property.
        /// The Name of the Assembly to which the Plugin belongs.
        /// </summary>
        public string AssemblyName
        {
            get
            {
                return _assemblyName;
            }
            set
            {
                _assemblyName = value;
            }
        }
        
        /// <summary>
        /// String Property indicating the Type of the Plugin from the Assembly.
        /// </summary>
        private string _typeName;

        /// <summary>
        /// String Property indicating the Type of the Plugin from the Assembly.
        /// </summary>
        public string TypeName
        {
            get
            {
                return _typeName;
            }
            set
            {
                _typeName = value;
            }
        }

        /// <summary>
        /// String Property that actually contains the Identifier of the Plugin as a String.
        /// A deceptive property.
        /// </summary>
        private string _friendlyName;

        /// <summary>
        /// String Property that actually contains the Identifier of the Plugin as a String.
        /// A deceptive property.
        /// </summary>
        public string FriendlyName
        {
            get
            {
                return _friendlyName;
            }
            set
            {
                _friendlyName = value;
            }
        }

        /// <summary>
        /// The Plugin Name String Property.
        /// </summary>
        private string _name;

        /// <summary>
        /// The Plugin Name String Property.
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
        /// The Plugin Description String Property.
        /// </summary>
        private string _description;

        /// <summary>
        /// The Plugin Description String Property.
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
        /// The Workflow Activity Group Name String Property.
        /// This is only set when the Plugin is actually a Custom Workflow Activitiy (CWA).
        /// </summary>
        private string _workflowActivityGroupName;

        /// <summary>
        /// The Workflow Activity Group Name String Property.
        /// This is only set when the Plugin is actually a Custom Workflow Activitiy (CWA).
        /// </summary>
        public string WorkflowActivityGroupName
        {
            get
            {
                return _workflowActivityGroupName;
            }
            set
            {
                _workflowActivityGroupName = value;
            }
        }

        /// <summary>
        /// The XRM Plugin Type Enumerator Property.
        /// </summary>
        private XrmPluginType _pluginType;

        /// <summary>
        /// The XRM Plugin Type Enumerator Property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
        public XrmPluginType PluginType
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
        /// The XRM Plugin Isolatable Enumerator Property.
        /// </summary>
        private XrmPluginIsolatable _isolatable;

        /// <summary>
        /// The XRM Plugin Isolatable Enumerator Property.
        /// </summary>
        public XrmPluginIsolatable Isolatable
        {
            get
            {
                return _isolatable;
            }
            set
            {
                _isolatable = value;
            }
        }

        /// <summary>
        /// Boolean Property indicating if the Plugin is already registered in Dynamics CRM.
        /// </summary>
        private bool _exists;

        /// <summary>
        /// Boolean Property indicating if the Plugin is already registered in Dynamics CRM.
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
        /// A Property containing a Collection of Steps linked to the Plugin.
        /// </summary>
        private Collection<XrmPluginStep> _steps = new Collection<XrmPluginStep>();

        /// <summary>
        /// A Property containing a Collection of Steps linked to the Plugin.
        /// </summary>
        public Collection<XrmPluginStep> Steps
        {
            get
            {
                return _steps;
            }
        }
    }
}
