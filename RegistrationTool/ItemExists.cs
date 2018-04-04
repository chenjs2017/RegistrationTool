using System;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The Item Exists Class.
    /// Use this Class to store the Properties of an Assembly, Plugin, Step or Image when they are already registered in Dynamics CRM or to provide a new Identifier and indicate that they are not registered in Dynamics CRM.
    /// </summary>
    public class ItemExists
    {
        public Guid ItemId { get; set; }
        public bool Exists { get; set; }
        internal Guid? SecureConfigId { get; set; }
    }
}
