using Microsoft.Xrm.Sdk.Messages;

namespace PluginRegistrationTool
{
    public class DeleteManyToManyRelationshipResponse
    {
        public DeleteEntityResponse DeleteEntityResponse { get; set; }
        public DeleteRelationshipResponse DeleteRelationshipResponse { get; set; }
        
    }
}
