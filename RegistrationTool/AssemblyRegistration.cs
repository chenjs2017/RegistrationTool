using System.Collections.ObjectModel;

namespace PluginRegistrationTool
{
    public class AssemblyRegistration
    {
        public string ConnectionString { get; set; }
        public Collection<Registration> Registrations { get; set; }
        public bool Ignore { get; set; }
        
    }
}
