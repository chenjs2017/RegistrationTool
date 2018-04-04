namespace PluginRegistrationTool
{
    /// <summary>
    /// Solution Component Type Enumerator.
    /// </summary>
    public enum SolutionComponentType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Attachment.
        /// </summary>
        Attachment = 35,

        /// <summary>
        /// Attribute.
        /// </summary>
        Attribute = 2,
 
        /// <summary>
        /// Attribute Lookup Value.
        /// </summary>
        AttributeLookupValue = 5,
 
        /// <summary>
        /// Attribute Map.
        /// </summary>
        AttributeMap = 47,
 
        /// <summary>
        /// Attribute Picklist Value.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Picklist")]
        AttributePicklistValue = 4,
 
        /// <summary>
        /// Connection Role.
        /// </summary>
        ConnectionRole = 63,
 
        /// <summary>
        /// Contract Template.
        /// </summary>
        ContractTemplate = 37,
 
        /// <summary>
        /// Display String.
        /// </summary>
        DisplayString = 22,
  
        /// <summary>
        /// Display String Map.
        /// </summary>
        DisplayStringMap = 23,
  
        /// <summary>
        /// Duplicate Rule.
        /// </summary>
        DuplicateRule = 44,
  
        /// <summary>
        /// Duplicate Rule Condition.
        /// </summary>
        DuplicateRuleCondition = 45,
  
        /// <summary>
        /// Email Template.
        /// </summary>
        EmailTemplate = 36,
  
        /// <summary>
        /// Entity.
        /// </summary>
        Entity = 1,
 
        /// <summary>
        /// Entity Map.
        /// </summary>
        EntityMap = 46,
 
        /// <summary>
        /// Entity Relationship.
        /// </summary>
        EntityRelationship = 10,
 
        /// <summary>
        /// Entity Relationship Relationships.
        /// </summary>
        EntityRelationshipRelationships = 12,
 
        /// <summary>
        /// Entity Relationship Role.
        /// </summary>
        EntityRelationshipRole = 11,
  
        /// <summary>
        /// Field Permission.
        /// </summary>
        FieldPermission = 71,
 
        /// <summary>
        /// Field Security Profile.
        /// </summary>
        FieldSecurityProfile = 70,
  
        /// <summary>
        /// Form.
        /// </summary>
        Form = 24,
 
        /// <summary>
        /// KB Article Template.
        /// </summary>
        KBArticleTemplate = 38,
 
        /// <summary>
        /// Localized Label.
        /// </summary>
        LocalizedLabel = 7,
 
        /// <summary>
        /// Mail Merge Template.
        /// </summary>
        MailMergeTemplate = 39,
 
        /// <summary>
        /// Managed Property.
        /// </summary>
        ManagedProperty = 13,
 
        /// <summary>
        /// Option Set.
        /// </summary>
        OptionSet = 9,
 
        /// <summary>
        /// Organization.
        /// </summary>
        Organization = 25,
  
        /// <summary>
        /// Plugin Assembly.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
        PluginAssembly = 91,
  
        /// <summary>
        /// Plugin Type.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
        PluginType = 90,
 
        /// <summary>
        /// Relationship.
        /// </summary>
        Relationship = 3,
 
        /// <summary>
        /// Relationship Extra Condition.
        /// </summary>
        RelationshipExtraCondition = 8,
 
        /// <summary>
        /// Report.
        /// </summary>
        Report = 31,
 
        /// <summary>
        /// Report Category.
        /// </summary>
        ReportCategory = 33,

        /// <summary>
        /// Report Entity.
        /// </summary>
        ReportEntity = 32,

        /// <summary>
        /// Report Visibility.
        /// </summary>
        ReportVisibility = 34,
 
        /// <summary>
        /// Ribbon Command.
        /// </summary>
        RibbonCommand = 48,
 
        /// <summary>
        /// Ribbon Context Group.
        /// </summary>
        RibbonContextGroup = 49,
  
        /// <summary>
        /// Ribbon Customization.
        /// </summary>
        RibbonCustomization = 50,
  
        /// <summary>
        /// Ribbon Diff.
        /// </summary>
        RibbonDiff = 55,
 
        /// <summary>
        /// Ribbon Rule.
        /// </summary>
        RibbonRule = 52,
 
        /// <summary>
        /// Ribbon Tab To Command Map.
        /// </summary>
        RibbonTabToCommandMap = 53,
 
        /// <summary>
        /// Role.
        /// </summary>
        Role = 20,
 
        /// <summary>
        /// Role Privilege.
        /// </summary>
        RolePrivilege = 21,

        /// <summary>
        /// Saved Query.
        /// </summary>
        SavedQuery = 26,
 
        /// <summary>
        /// Saved Query Visualization.
        /// </summary>
        SavedQueryVisualization = 59,
 
        /// <summary>
        /// SDK Message Processing Step.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "SDK")]
        SDKMessageProcessingStep = 92,
 
        /// <summary>
        /// SDK Message Processing Step Image.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "SDK")]
        SDKMessageProcessingStepImage = 93,
  
        /// <summary>
        /// SDK Message Processing Step Secure Config.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "SDK")]
        SDKMessageProcessingStepSecureConfig = 94,
 
        /// <summary>
        /// Service Endpoint.
        /// </summary>
        ServiceEndpoint = 95,
 
        /// <summary>
        /// Site Map.
        /// </summary>
        SiteMap = 62,
 
        /// <summary>
        /// System Form.
        /// </summary>
        SystemForm = 60,
 
        /// <summary>
        /// View Attribute.
        /// </summary>
        ViewAttribute = 6,

        /// <summary>
        /// Web Resource.
        /// </summary>
        WebResource = 61,

        /// <summary>
        /// Workflow.
        /// </summary>
        Workflow = 29
    }
}
