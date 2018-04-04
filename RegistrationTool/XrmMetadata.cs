using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The Dynamics CRM Metadata Class.
    /// 
    /// This class provides various methods implementing metadata actions to customise Dynamics CRM.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Xrm")]
    public class XrmMetadata
    {
        string ConnectionString { get; set; }
        #region Constructors

        public XrmMetadata(string connString)
        {
            ConnectionString = connString;
       }

        #endregion


        #region Attribute Methods

        /// <summary>
        /// Method to create a new attribute in Dynamics CRM.
        /// </summary>
        /// <param name="attribute">The attribute metadata object containing the details of the new attribute to create.</param>
        /// <param name="entityLogicalName">The name of the entity in which to create the attribute.</param>
        /// <returns>A response object containing the details of the creation of the new attribute.</returns>
        public CreateAttributeResponse CreateAttribute(AttributeMetadata attribute, string entityLogicalName)
        {
            try
            {
                CreateAttributeResponse createAttributeResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    CreateAttributeRequest createAttributeRequest = new CreateAttributeRequest
                    {
                        EntityName = entityLogicalName,
                        Attribute = attribute
                    };
                    createAttributeResponse = (CreateAttributeResponse)service.Execute(createAttributeRequest);
                }
                return createAttributeResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded method to create a new attribute in Dynamics CRM.
        /// </summary>
        /// <param name="attribute">The attribute metadata object containing the details of the new attribute to create.</param>
        /// <param name="entityLogicalName">The name of the entity in which to create the attribute.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the creation of the new attribute.</returns>
        public CreateAttributeResponse CreateAttribute(AttributeMetadata attribute, string entityLogicalName, string solutionName)
        {
            try
            {
                CreateAttributeResponse createAttributeResponse;
                
                using (XrmService service = new XrmService(ConnectionString))
                {
                    CreateAttributeRequest createAttributeRequest = new CreateAttributeRequest
                    {
                        EntityName = entityLogicalName,
                        Attribute = attribute,
                        SolutionUniqueName = solutionName
                    };
                    createAttributeResponse = (CreateAttributeResponse)service.Execute(createAttributeRequest);
                }
                return createAttributeResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to retrieve an attribute from Dynamics CRM.
        /// </summary>
        /// <param name="attributeName">The name of the attribute to retrieve.</param>
        /// <param name="entityLogicalName">The name of the entity from which to retrieve the attribute.</param>
        /// <returns></returns>
        public RetrieveAttributeResponse RetrieveAttribute(string attributeName, string entityLogicalName)
        {
            try
            {
                RetrieveAttributeResponse retrieveAttributeResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    RetrieveAttributeRequest retrieveAttributeRequest = new RetrieveAttributeRequest
                    {
                        EntityLogicalName = entityLogicalName,
                        LogicalName = attributeName,
                        RetrieveAsIfPublished = true,
                    };
                    retrieveAttributeResponse = (RetrieveAttributeResponse)service.Execute(retrieveAttributeRequest);
                }
                return retrieveAttributeResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to update an attribute.
        /// </summary>
        /// <param name="attribute">The attribute metadata object containing the details of the update to be applied to the attribute.</param>
        /// <param name="entityLogicalName">The name of the entity containing the attribute to be updated.</param>
        /// <returns>A response object containing the details of the update attempt.</returns>
        public UpdateAttributeResponse UpdateAttribute(AttributeMetadata attribute, string entityLogicalName)
        {
            try
            {
                UpdateAttributeResponse updateAttributeResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    UpdateAttributeRequest updateAttributeRequest = new UpdateAttributeRequest
                    {
                        Attribute = attribute,
                        EntityName = entityLogicalName,
                        MergeLabels = false
                    };
                    updateAttributeResponse = (UpdateAttributeResponse)service.Execute(updateAttributeRequest);
                }
                return updateAttributeResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to update an attribute.
        /// </summary>
        /// <param name="attribute">The attribute metadata object containing the details of the update to be applied to the attribute.</param>
        /// <param name="entityLogicalName">The name of the entity containing the attribute to be updated.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the update attempt.</returns>
        public UpdateAttributeResponse UpdateAttribute(AttributeMetadata attribute, string entityLogicalName, string solutionName)
        {
            try
            {
                UpdateAttributeResponse updateAttributeResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    UpdateAttributeRequest updateAttributeRequest = new UpdateAttributeRequest
                    {
                        Attribute = attribute,
                        EntityName = entityLogicalName,
                        MergeLabels = false,
                        SolutionUniqueName = solutionName
                    };
                    updateAttributeResponse = (UpdateAttributeResponse)service.Execute(updateAttributeRequest);
                }
                return updateAttributeResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to delete an attribute.
        /// </summary>
        /// <param name="attributeName">The name of the attribute to delete.</param>
        /// <param name="entityLogicalName">The name of the entity to which the entity to delete belongs.</param>
        /// <returns>A response object containing the details of the delete attempt.</returns>
        public DeleteAttributeResponse DeleteAttribute(string attributeName, string entityLogicalName)
        {
            try
            {
                DeleteAttributeResponse deleteAttributeResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    DeleteAttributeRequest DeleteAttributeRequest = new DeleteAttributeRequest
                    {
                        EntityLogicalName = entityLogicalName,
                        LogicalName = attributeName
                    };
                    deleteAttributeResponse = (DeleteAttributeResponse)service.Execute(DeleteAttributeRequest);
                }
                return deleteAttributeResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to create a new boolean attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateAttributeResponse CreateBooleanAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode)
        {
            try
            {
                BooleanAttributeMetadata boolAttribute = new BooleanAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    OptionSet = new BooleanOptionSetMetadata(new OptionMetadata(new Label("True", languageCode), 1), new OptionMetadata(new Label("False", languageCode), 0))
                };
                return CreateAttribute(boolAttribute, entityLogicalName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to create a new boolean attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the update attempt.</returns>
        public CreateAttributeResponse CreateBooleanAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, string solutionName)
        {
            try
            {
                BooleanAttributeMetadata boolAttribute = new BooleanAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    OptionSet = new BooleanOptionSetMetadata(new OptionMetadata(new Label("True", languageCode), 1), new OptionMetadata(new Label("False", languageCode), 0))
                };
                return CreateAttribute(boolAttribute, entityLogicalName, solutionName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to create a new DateTime attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateAttributeResponse CreateDateTimeAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode)
        {
            try
            {
                DateTimeAttributeMetadata dtAttribute = new DateTimeAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    Format = DateTimeFormat.DateOnly,
                    ImeMode = ImeMode.Disabled
                };
                return CreateAttribute(dtAttribute, entityLogicalName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to create a new DateTime attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateAttributeResponse CreateDateTimeAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, string solutionName)
        {
            try
            {
                DateTimeAttributeMetadata dtAttribute = new DateTimeAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    Format = DateTimeFormat.DateOnly,
                    ImeMode = ImeMode.Disabled
                };
                return CreateAttribute(dtAttribute, entityLogicalName, solutionName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to create a new Decimal attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="maxValue">The maximum value of the attribute.</param>
        /// <param name="minValue">The minimum value of the attribute.</param>
        /// <param name="precision">The number of decimal places allowed.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateAttributeResponse CreateDecimalAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, decimal? maxValue, decimal? minValue, int? precision)
        {
            try
            {
                DecimalAttributeMetadata decimalAttribute = new DecimalAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    MaxValue = maxValue,
                    MinValue = minValue,
                    Precision = precision
                };
                return CreateAttribute(decimalAttribute, entityLogicalName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to create a new Decimal attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="maxValue">The maximum value of the attribute.</param>
        /// <param name="minValue">The minimum value of the attribute.</param>
        /// <param name="precision">The number of decimal places allowed.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateAttributeResponse CreateDecimalAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, decimal? maxValue, decimal? minValue, int? precision, string solutionName)
        {
            try
            {
                DecimalAttributeMetadata decimalAttribute = new DecimalAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    MaxValue = maxValue,
                    MinValue = minValue,
                    Precision = precision
                };
                return CreateAttribute(decimalAttribute, entityLogicalName, solutionName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to create a new Integer attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="maxValue">The maximum value of the attribute.</param>
        /// <param name="minValue">The minimum value of the attribute.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateAttributeResponse CreateIntegerAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, int? maxValue, int? minValue)
        {
            try
            {
                IntegerAttributeMetadata integerAttribute = new IntegerAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    Format = IntegerFormat.None,
                    MaxValue = maxValue,
                    MinValue = minValue
                };
                return CreateAttribute(integerAttribute, entityLogicalName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to create a new Integer attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="maxValue">The maximum value of the attribute.</param>
        /// <param name="minValue">The minimum value of the attribute.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateAttributeResponse CreateIntegerAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, int? maxValue, int? minValue, string solutionName)
        {
            try
            {
                IntegerAttributeMetadata integerAttribute = new IntegerAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    Format = IntegerFormat.None,
                    MaxValue = maxValue,
                    MinValue = minValue
                };
                return CreateAttribute(integerAttribute, entityLogicalName, solutionName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to create a new Memo attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="format">The format of the attribute.</param>
        /// <param name="imeMode">The IME mode of the attribute.</param>
        /// <param name="maxLength">The maximum length of the attribute.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateAttributeResponse CreateMemoAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, StringFormat? format, ImeMode? imeMode, int? maxLength)
        {
            try
            {
                MemoAttributeMetadata MemoAttribute = new MemoAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    Format = format,
                    ImeMode = imeMode,
                    MaxLength = maxLength
                };
                return CreateAttribute(MemoAttribute, entityLogicalName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to create a new Memo attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="format">The format of the attribute.</param>
        /// <param name="imeMode">The IME mode of the attribute.</param>
        /// <param name="maxLength">The maximum length of the attribute.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateAttributeResponse CreateMemoAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, StringFormat? format, ImeMode? imeMode, int? maxLength, string solutionName)
        {
            try
            {
                MemoAttributeMetadata MemoAttribute = new MemoAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    Format = format,
                    ImeMode = imeMode,
                    MaxLength = maxLength
                };
                return CreateAttribute(MemoAttribute, entityLogicalName, solutionName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to create a new Money attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="maxValue">The maximum value of the attribute.</param>
        /// <param name="minValue">The minimum value of the attribute.</param>
        /// <param name="precision">The number of decimal places allowed.</param>
        /// <param name="precisionSource">The source of the precision of the attribute.</param>
        /// <param name="imeMode">The IME mode of the attribute.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateAttributeResponse CreateMoneyAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, double? maxValue, double? minValue, int? precision, int? precisionSource, ImeMode? imeMode)
        {
            try
            {
                MoneyAttributeMetadata moneyAttribute = new MoneyAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    MaxValue = maxValue,
                    MinValue = minValue,
                    Precision = precision,
                    PrecisionSource = precisionSource,
                    ImeMode = imeMode
                };
                return CreateAttribute(moneyAttribute, entityLogicalName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to create a new Money attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="maxValue">The maximum value of the attribute.</param>
        /// <param name="minValue">The minimum value of the attribute.</param>
        /// <param name="precision">The number of decimal places allowed.</param>
        /// <param name="precisionSource">The source of the precision of the attribute.</param>
        /// <param name="imeMode">The IME mode of the attribute.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateAttributeResponse CreateMoneyAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, double? maxValue, double? minValue, int? precision, int? precisionSource, ImeMode? imeMode, string solutionName)
        {
            try
            {
                MoneyAttributeMetadata moneyAttribute = new MoneyAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    MaxValue = maxValue,
                    MinValue = minValue,
                    Precision = precision,
                    PrecisionSource = precisionSource,
                    ImeMode = imeMode
                };
                return CreateAttribute(moneyAttribute, entityLogicalName, solutionName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to create a new PickList attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="options">A dictionary of key/value pairs.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Picklist")]
        public CreateAttributeResponse CreatePicklistAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, Dictionary<string, int> options)
        {
            try
            {
                PicklistAttributeMetadata pickListAttribute = new PicklistAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    OptionSet = new OptionSetMetadata
                    {
                        IsGlobal = false,
                        OptionSetType = OptionSetType.Picklist,
                    }
                };
                if (options != null && options.Count != 0)
                {
                    foreach (var option in options)
                    {
                        pickListAttribute.OptionSet.Options.Add(new OptionMetadata(new Label(option.Key, languageCode), option.Value));
                    }
                } 
                return CreateAttribute(pickListAttribute, entityLogicalName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to create a new PickList attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="options">A dictionary of key/value pairs.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Picklist")]
        public CreateAttributeResponse CreatePicklistAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, Dictionary<string, int> options, string solutionName)
        {
            try
            {
                PicklistAttributeMetadata pickListAttribute = new PicklistAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    OptionSet = new OptionSetMetadata
                    {
                        IsGlobal = false,
                        OptionSetType = OptionSetType.Picklist,
                    }
                };
                if (options != null && options.Count != 0)
                {
                    foreach (var option in options)
                    {
                        pickListAttribute.OptionSet.Options.Add(new OptionMetadata(new Label(option.Key, languageCode), option.Value));
                    }
                }
                return CreateAttribute(pickListAttribute, entityLogicalName, solutionName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to create a new PickList attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="maxLength">The maximum length of the attribute.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateAttributeResponse CreateStringAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, int? maxLength)
        {
            try
            {
                StringAttributeMetadata stringAttribute = new StringAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    MaxLength = maxLength
                };
                return CreateAttribute(stringAttribute, entityLogicalName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to create a new PickList attribute.
        /// </summary>
        /// <param name="entityLogicalName">The name of the entity wherein the new attribute needs to be created.</param>
        /// <param name="schemaName">The unique name of the attribute to be created.</param>
        /// <param name="displayName">The display name of the attribute to be created.</param>
        /// <param name="requiredLevel">Should the attribute be mandatory within the entity?</param>
        /// <param name="description">The description of the attribute.</param>
        /// <param name="languageCode">The language code for the labels of the attribute.</param>
        /// <param name="maxLength">The maximum length of the attribute.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateAttributeResponse CreateStringAttribute(string entityLogicalName, string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, int? maxLength, string solutionName)
        {
            try
            {
                StringAttributeMetadata stringAttribute = new StringAttributeMetadata
                {
                    SchemaName = schemaName,
                    DisplayName = new Label(displayName, languageCode),
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel),
                    Description = new Label(description, languageCode),
                    MaxLength = maxLength
                };
                return CreateAttribute(stringAttribute, entityLogicalName, solutionName);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to create a new global option set.
        /// </summary>
        /// <param name="languageCode">The language code for the labels of the option set.</param>
        /// <param name="globalOptionSetName">The unique name of the global option set.</param>
        /// <param name="displayName">The display name of the global option set.</param>
        /// <param name="options">A dictionary of key/value pairs.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateOptionSetResponse CreateOptionSet(int languageCode, string globalOptionSetName, string displayName, Dictionary<string, int> options)
        {
            try
            {
                CreateOptionSetResponse createOptionSetResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    OptionSetMetadata optionSetMetadata = new OptionSetMetadata()
                    {
                        Name = globalOptionSetName,
                        DisplayName = new Label(displayName, languageCode),
                        IsGlobal = true,
                        OptionSetType = OptionSetType.Picklist,
                    };
                    if (options != null && options.Count != 0)
                    {
                        foreach (var option in options)
                        {
                            optionSetMetadata.Options.Add(new OptionMetadata(new Label(option.Key, languageCode), option.Value));
                        }
                    }
                    CreateOptionSetRequest createOptionSetRequest = new CreateOptionSetRequest
                    {
                        OptionSet = optionSetMetadata,
                    };
                    createOptionSetResponse = (CreateOptionSetResponse)service.Execute(createOptionSetRequest);
                }
                return createOptionSetResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to create a new global option set.
        /// </summary>
        /// <param name="languageCode">The language code for the labels of the option set.</param>
        /// <param name="globalOptionSetName">The unique name of the global option set.</param>
        /// <param name="displayName">The display name of the global option set.</param>
        /// <param name="options">A dictionary of key/value pairs.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateOptionSetResponse CreateOptionSet(int languageCode, string globalOptionSetName, string displayName, Dictionary<string, int> options, string solutionName)
        {
            try
            {
                CreateOptionSetResponse createOptionSetResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    OptionSetMetadata optionSetMetadata = new OptionSetMetadata()
                    {
                        Name = globalOptionSetName,
                        DisplayName = new Label(displayName, languageCode),
                        IsGlobal = true,
                        OptionSetType = OptionSetType.Picklist,
                    };
                    if (options != null && options.Count != 0)
                    {
                        foreach (var option in options)
                        {
                            optionSetMetadata.Options.Add(new OptionMetadata(new Label(option.Key, languageCode), option.Value));
                        }
                    }
                    CreateOptionSetRequest createOptionSetRequest = new CreateOptionSetRequest
                    {
                        OptionSet = optionSetMetadata,
                        SolutionUniqueName = solutionName
                    };
                    createOptionSetResponse = (CreateOptionSetResponse)service.Execute(createOptionSetRequest);
                }
                return createOptionSetResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to create a new one-to-many relationship.
        /// </summary>
        /// <param name="schemaName">The unique name of the lookup for the relationship.</param>
        /// <param name="displayName">The display name of the lookup for the relationship.</param>
        /// <param name="requiredLevel">Is the lookup for the relationship mandatory?</param>
        /// <param name="description">The description of the lookup for the relationship.</param>
        /// <param name="languageCode">The language code for the labels of the lookup for the relationship.</param>
        /// <param name="behavior">The behaviour of the associated menuof the lookup for the relationship.</param>
        /// <param name="group">The associated menu groupof the lookup for the relationship.</param>
        /// <param name="associatedMenuConfiguration">The associated menu configurationof the lookup for the relationship.</param>
        /// <param name="order">The order within the associated menu of the lookup for the relationship.</param>
        /// <param name="assign">Assign cascade option of the lookup for the relationship.</param>
        /// <param name="delete">Delete cascade option of the lookup for the relationship.</param>
        /// <param name="merge">Merge cascade option of the lookup for the relationship.</param>
        /// <param name="reparent">Reparent cascade option of the lookup for the relationship.</param>
        /// <param name="share">Share cascade option of the lookup for the relationship.</param>
        /// <param name="unshare">Unshare cascade option of the lookup for the relationship.</param>
        /// <param name="referencedEntity">The name of the referenced entity.</param>
        /// <param name="referencedAttribute">The name of the attribute being used as a key in the referenced entity.</param>
        /// <param name="referencingEntity">The name of the referencing entity.</param>
        /// <param name="relationshipSchemaName">The unique name of the relationship.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "unshare"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "reparent")]
        public CreateOneToManyResponse CreateOneToManyRelationship(string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, AssociatedMenuBehavior? behavior, AssociatedMenuGroup? group, string associatedMenuConfiguration, int? order, CascadeType assign, CascadeType delete, CascadeType merge, CascadeType reparent, CascadeType share, CascadeType unshare, string referencedEntity, string referencedAttribute, string referencingEntity, string relationshipSchemaName)
        {
            try
            {
                CreateOneToManyResponse createOneToManyResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    CreateOneToManyRequest createOneToManyRequest = new CreateOneToManyRequest()
                    {
                        Lookup = new LookupAttributeMetadata()
                        {
                            Description = new Label(description, languageCode),
                            DisplayName = new Label(displayName, languageCode),
                            LogicalName = schemaName,
                            SchemaName = schemaName,
                            RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel)
                        },
                        OneToManyRelationship = new OneToManyRelationshipMetadata()
                        {
                            AssociatedMenuConfiguration = new AssociatedMenuConfiguration()
                            {
                                Behavior = behavior,
                                Group = group,
                                Label = new Label(associatedMenuConfiguration, languageCode),
                                Order = order
                            },
                            CascadeConfiguration = new CascadeConfiguration()
                            {
                                Assign = assign,
                                Delete = delete,
                                Merge = merge,
                                Reparent = reparent,
                                Share = share,
                                Unshare = unshare
                            },
                            ReferencedEntity = referencedEntity,
                            ReferencedAttribute = referencedAttribute,
                            ReferencingEntity = referencingEntity,
                            SchemaName = relationshipSchemaName
                        }
                    };
                    createOneToManyResponse = (CreateOneToManyResponse)service.Execute(createOneToManyRequest);
                }
                return createOneToManyResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to create a new one-to-many relationship.
        /// </summary>
        /// <param name="schemaName">The unique name of the lookup for the relationship.</param>
        /// <param name="displayName">The display name of the lookup for the relationship.</param>
        /// <param name="requiredLevel">Is the lookup for the relationship mandatory?</param>
        /// <param name="description">The description of the lookup for the relationship.</param>
        /// <param name="languageCode">The language code for the labels of the lookup for the relationship.</param>
        /// <param name="behavior">The behaviour of the associated menuof the lookup for the relationship.</param>
        /// <param name="group">The associated menu groupof the lookup for the relationship.</param>
        /// <param name="associatedMenuConfiguration">The associated menu configurationof the lookup for the relationship.</param>
        /// <param name="order">The order within the associated menu of the lookup for the relationship.</param>
        /// <param name="assign">Assign cascade option of the lookup for the relationship.</param>
        /// <param name="delete">Delete cascade option of the lookup for the relationship.</param>
        /// <param name="merge">Merge cascade option of the lookup for the relationship.</param>
        /// <param name="reparent">Reparent cascade option of the lookup for the relationship.</param>
        /// <param name="share">Share cascade option of the lookup for the relationship.</param>
        /// <param name="unshare">Unshare cascade option of the lookup for the relationship.</param>
        /// <param name="referencedEntity">The name of the referenced entity.</param>
        /// <param name="referencedAttribute">The name of the attribute being used as a key in the referenced entity.</param>
        /// <param name="referencingEntity">The name of the referencing entity.</param>
        /// <param name="relationshipSchemaName">The unique name of the relationship.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "unshare"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "reparent")]
        public CreateOneToManyResponse CreateOneToManyRelationship(string schemaName, string displayName, AttributeRequiredLevel requiredLevel, string description, int languageCode, AssociatedMenuBehavior? behavior, AssociatedMenuGroup? group, string associatedMenuConfiguration, int? order, CascadeType assign, CascadeType delete, CascadeType merge, CascadeType reparent, CascadeType share, CascadeType unshare, string referencedEntity, string referencedAttribute, string referencingEntity, string relationshipSchemaName, string solutionName)
        {
            try
            {
                CreateOneToManyResponse createOneToManyResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    CreateOneToManyRequest createOneToManyRequest = new CreateOneToManyRequest()
                    {
                        Lookup = new LookupAttributeMetadata()
                        {
                            Description = new Label(description, languageCode),
                            DisplayName = new Label(displayName, languageCode),
                            LogicalName = schemaName,
                            SchemaName = schemaName,
                            RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel)
                        },
                        OneToManyRelationship = new OneToManyRelationshipMetadata()
                        {
                            AssociatedMenuConfiguration = new AssociatedMenuConfiguration()
                            {
                                Behavior = behavior,
                                Group = group,
                                Label = new Label(associatedMenuConfiguration, languageCode),
                                Order = order
                            },
                            CascadeConfiguration = new CascadeConfiguration()
                            {
                                Assign = assign,
                                Delete = delete,
                                Merge = merge,
                                Reparent = reparent,
                                Share = share,
                                Unshare = unshare
                            },
                            ReferencedEntity = referencedEntity,
                            ReferencedAttribute = referencedAttribute,
                            ReferencingEntity = referencingEntity,
                            SchemaName = relationshipSchemaName
                        },
                        SolutionUniqueName = solutionName
                    };
                    createOneToManyResponse = (CreateOneToManyResponse)service.Execute(createOneToManyRequest);
                }
                return createOneToManyResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to create a new many-to-many relationship.
        /// </summary>
        /// <param name="relationshipName">The unique name of the relationship.</param>
        /// <param name="languageCode">The language code for the labels of the relationship.</param>
        /// <param name="entity1Name">The unique name of the first entity in the relationship.</param>
        /// <param name="entity2Name">The unique name of the second entity in the relationship.</param>
        /// <param name="entity1DisplayName">The display name of the first entity in the relationship.</param>
        /// <param name="entity1IdName">The unique name of the attribute to be used as a key in the relationship from the first entity in the relationship.</param>
        /// <param name="entity2DisplayName">The display name of the second entity in the relationship.</param>
        /// <param name="entity2IdName">The unique name of the attribute to be used as a key in the relationship from the second entity in the relationship.</param>
        /// <param name="intersectEntityName">The name of the intersection entity that will be created for the relationship.</param>
        /// <param name="behavior1">The behaviour of the associated menu configuration of the first entity in the relationship.</param>
        /// <param name="group1">The group of the associated menu configuration of the first entity in the relationship.</param>
        /// <param name="order1">The order of the associated menu configuration of the first entity in the relationship.</param>
        /// <param name="behavior2">The behaviour of the associated menu configuration of the second entity in the relationship.</param>
        /// <param name="group2">The group of the associated menu configuration of the second entity in the relationship.</param>
        /// <param name="order2">The order of the associated menu configuration of the second entity in the relationship.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateManyToManyResponse CreateManyToManyRelationship(string relationshipName, int languageCode, string entity1Name, string entity2Name, string entity1DisplayName, string entity1IdName, string entity2DisplayName, string entity2IdName, string intersectEntityName, AssociatedMenuBehavior? behavior1, AssociatedMenuGroup? group1, int? order1, AssociatedMenuBehavior? behavior2, AssociatedMenuGroup? group2, int? order2)
        {
            try
            {
                CreateManyToManyResponse createManyToManyResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    CreateManyToManyRequest createManyToManyRequest = new CreateManyToManyRequest()
                    {
                        IntersectEntitySchemaName = relationshipName,
                        ManyToManyRelationship = new ManyToManyRelationshipMetadata
                        {
                            Entity1AssociatedMenuConfiguration = new AssociatedMenuConfiguration()
                            {
                                Behavior = behavior1,
                                Group = group1,
                                Label = new Label(entity1DisplayName, languageCode),
                                Order = order1
                            },
                            Entity1IntersectAttribute = entity1IdName,
                            Entity1LogicalName = entity1Name,
                            Entity2AssociatedMenuConfiguration = new AssociatedMenuConfiguration()
                            {
                                Behavior = behavior2,
                                Group = group2,
                                Label = new Label(entity2DisplayName, languageCode),
                                Order = order2
                            },
                            Entity2IntersectAttribute = entity2IdName,
                            Entity2LogicalName = entity2Name,
                            IntersectEntityName = intersectEntityName,
                            IsValidForAdvancedFind = true,
                            SchemaName = relationshipName,
                            SecurityTypes = SecurityTypes.None
                        }
                    };
                    createManyToManyResponse = (CreateManyToManyResponse)service.Execute(createManyToManyRequest);
                }
                return createManyToManyResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to create a new many-to-many relationship.
        /// </summary>
        /// <param name="relationshipName">The unique name of the relationship.</param>
        /// <param name="languageCode">The language code for the labels of the relationship.</param>
        /// <param name="entity1Name">The unique name of the first entity in the relationship.</param>
        /// <param name="entity2Name">The unique name of the second entity in the relationship.</param>
        /// <param name="entity1DisplayName">The display name of the first entity in the relationship.</param>
        /// <param name="entity1IdName">The unique name of the attribute to be used as a key in the relationship from the first entity in the relationship.</param>
        /// <param name="entity2DisplayName">The display name of the second entity in the relationship.</param>
        /// <param name="entity2IdName">The unique name of the attribute to be used as a key in the relationship from the second entity in the relationship.</param>
        /// <param name="intersectEntityName">The name of the intersection entity that will be created for the relationship.</param>
        /// <param name="behavior1">The behaviour of the associated menu configuration of the first entity in the relationship.</param>
        /// <param name="group1">The group of the associated menu configuration of the first entity in the relationship.</param>
        /// <param name="order1">The order of the associated menu configuration of the first entity in the relationship.</param>
        /// <param name="behavior2">The behaviour of the associated menu configuration of the second entity in the relationship.</param>
        /// <param name="group2">The group of the associated menu configuration of the second entity in the relationship.</param>
        /// <param name="order2">The order of the associated menu configuration of the second entity in the relationship.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateManyToManyResponse CreateManyToManyRelationship(string relationshipName, int languageCode, string entity1Name, string entity2Name, string entity1DisplayName, string entity1IdName, string entity2DisplayName, string entity2IdName, string intersectEntityName, AssociatedMenuBehavior? behavior1, AssociatedMenuGroup? group1, int? order1, AssociatedMenuBehavior? behavior2, AssociatedMenuGroup? group2, int? order2, string solutionName)
        {
            try
            {
                CreateManyToManyResponse createManyToManyResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    CreateManyToManyRequest createManyToManyRequest = new CreateManyToManyRequest()
                    {
                        IntersectEntitySchemaName = relationshipName,
                        ManyToManyRelationship = new ManyToManyRelationshipMetadata
                        {
                            Entity1AssociatedMenuConfiguration = new AssociatedMenuConfiguration()
                            {
                                Behavior = behavior1,
                                Group = group1,
                                Label = new Label(entity1DisplayName, languageCode),
                                Order = order1
                            },
                            Entity1IntersectAttribute = entity1IdName,
                            Entity1LogicalName = entity1Name,
                            Entity2AssociatedMenuConfiguration = new AssociatedMenuConfiguration()
                            {
                                Behavior = behavior2,
                                Group = group2,
                                Label = new Label(entity2DisplayName, languageCode),
                                Order = order2
                            },
                            Entity2IntersectAttribute = entity2IdName,
                            Entity2LogicalName = entity2Name,
                            IntersectEntityName = intersectEntityName,
                            IsValidForAdvancedFind = true,
                            SchemaName = relationshipName,
                            SecurityTypes = SecurityTypes.None
                        },
                        SolutionUniqueName = solutionName
                    };
                    createManyToManyResponse = (CreateManyToManyResponse)service.Execute(createManyToManyRequest);
                }
                return createManyToManyResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to delete a one-to-many relationship.
        /// </summary>
        /// <param name="relationshipName">The name of the relationship to delete.</param>
        /// <returns>A response object containing the details of the delete attempt.</returns>
        public DeleteRelationshipResponse DeleteOneToManyRelationship(string relationshipName)
        {
            try
            {
                DeleteRelationshipResponse deleteRelationshipResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    DeleteRelationshipRequest deleteRelationshipRequest = new DeleteRelationshipRequest
                    {
                        Name = relationshipName
                    };
                    deleteRelationshipResponse = (DeleteRelationshipResponse)service.Execute(deleteRelationshipRequest);
                }
                return deleteRelationshipResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to delete a many-to-many relationship.
        /// </summary>
        /// <param name="relationshipName">The name of the relationship to delete.</param>
        /// <param name="entityName">The name of the intersection entity of the relationship to be deleted.</param>
        /// <returns>A response object containing the details of the delete attempt.</returns>
        public DeleteManyToManyRelationshipResponse DeleteManyToManyRelationship(string relationshipName, string entityName)
        {
            try
            {
                DeleteEntityResponse deleteEntityResponse = new DeleteEntityResponse();
                DeleteRelationshipResponse deleteRelationshipResponse = new DeleteRelationshipResponse();
                if (!string.IsNullOrEmpty(entityName))
                {
                using (XrmService service = new XrmService(ConnectionString))
                    {
                        DeleteRelationshipRequest deleteRelationshipRequest = new DeleteRelationshipRequest
                        {
                            Name = relationshipName
                        };
                        DeleteEntityRequest deleteEntityRequest = new DeleteEntityRequest
                        {
                            LogicalName = entityName.ToLower(CultureInfo.CurrentCulture)
                        };
                        deleteEntityResponse = (DeleteEntityResponse)service.Execute(deleteEntityRequest);
                        deleteRelationshipResponse = (DeleteRelationshipResponse)service.Execute(deleteRelationshipRequest);
                    }
                }
                DeleteManyToManyRelationshipResponse deleteManyToManyRelationshipResponse = new DeleteManyToManyRelationshipResponse();
                deleteManyToManyRelationshipResponse.DeleteEntityResponse = deleteEntityResponse;
                deleteManyToManyRelationshipResponse.DeleteRelationshipResponse = deleteRelationshipResponse;
                return deleteManyToManyRelationshipResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to delete an option set
        /// </summary>
        /// <param name="optionSetName">The name of the option set to delete.</param>
        /// <returns>A response object containing the details of the delete attempt.</returns>
        public DeleteOptionSetResponse DeleteOptionSet(string optionSetName)
        {
            try
            {
                DeleteOptionSetResponse deleteOptionSetResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    DeleteOptionSetRequest deleteOptionSetRequest = new DeleteOptionSetRequest
                    {
                        Name = optionSetName
                    };
                    deleteOptionSetResponse = (DeleteOptionSetResponse)service.Execute(deleteOptionSetRequest);
                }
                return deleteOptionSetResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        #endregion

        #region Entity Methods

        /// <summary>
        /// Method to create a new entity.
        /// </summary>
        /// <param name="languageCode">The language code for the labels of the entity.</param>
        /// <param name="entityName">The unique name of the entity to create.</param>
        /// <param name="entityDisplayName">The display name of the entity to create.</param>
        /// <param name="entityDisplayCollectionName">The plural display name of the entity to create.</param>
        /// <param name="entityDescription">The description of the entity to create.</param>
        /// <param name="primaryAttributeSchemaName">The unique name of the primary attribute of the entity to be created.</param>
        /// <param name="primaryAttributeDisplayName">The display name of the primary attribute of the entity to be created.</param>
        /// <param name="primaryAttributeDescription">The description of the primary attribute of the entity to be created.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateEntityResponse CreateEntity(int languageCode, string entityName, string entityDisplayName, string entityDisplayCollectionName, string entityDescription, string primaryAttributeSchemaName, string primaryAttributeDisplayName, string primaryAttributeDescription)
        {
            try
            {
                CreateEntityResponse createEntityResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    CreateEntityRequest createEntityRequest = new CreateEntityRequest
                    {
                        Entity = new EntityMetadata
                        {
                            SchemaName = entityName,
                            DisplayName = new Label(entityDisplayName, 1033),
                            DisplayCollectionName = new Label(entityDisplayCollectionName, languageCode),
                            Description = new Label(entityDescription, 1033),
                            OwnershipType = OwnershipTypes.UserOwned,
                            IsActivity = false,
                        },
                        PrimaryAttribute = new StringAttributeMetadata
                        {
                            SchemaName = primaryAttributeSchemaName,
                            RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                            MaxLength = 100,
                            Format = StringFormat.Text,
                            DisplayName = new Label(primaryAttributeDisplayName, languageCode),
                            Description = new Label(primaryAttributeDescription, languageCode)
                        }
                    };
                    createEntityResponse = (CreateEntityResponse)service.Execute(createEntityRequest);
                }
                return createEntityResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to create a new entity.
        /// </summary>
        /// <param name="languageCode">The language code for the labels of the entity.</param>
        /// <param name="entityName">The unique name of the entity to create.</param>
        /// <param name="entityDisplayName">The display name of the entity to create.</param>
        /// <param name="entityDisplayCollectionName">The plural display name of the entity to create.</param>
        /// <param name="entityDescription">The description of the entity to create.</param>
        /// <param name="primaryAttributeSchemaName">The unique name of the primary attribute of the entity to be created.</param>
        /// <param name="primaryAttributeDisplayName">The display name of the primary attribute of the entity to be created.</param>
        /// <param name="primaryAttributeDescription">The description of the primary attribute of the entity to be created.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        /// <returns>A response object containing the details of the create attempt.</returns>
        public CreateEntityResponse CreateEntity(int languageCode, string entityName, string entityDisplayName, string entityDisplayCollectionName, string entityDescription, string primaryAttributeSchemaName, string primaryAttributeDisplayName, string primaryAttributeDescription, string solutionName)
        {
            try
            {
                CreateEntityResponse createEntityResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    CreateEntityRequest createEntityRequest = new CreateEntityRequest
                    {
                        Entity = new EntityMetadata
                        {
                            SchemaName = entityName,
                            DisplayName = new Label(entityDisplayName, 1033),
                            DisplayCollectionName = new Label(entityDisplayCollectionName, languageCode),
                            Description = new Label(entityDescription, 1033),
                            OwnershipType = OwnershipTypes.UserOwned,
                            IsActivity = false,
                        },
                        PrimaryAttribute = new StringAttributeMetadata
                        {
                            SchemaName = primaryAttributeSchemaName,
                            RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                            MaxLength = 100,
                            Format = StringFormat.Text,
                            DisplayName = new Label(primaryAttributeDisplayName, languageCode),
                            Description = new Label(primaryAttributeDescription, languageCode)
                        },
                        SolutionUniqueName = solutionName
                    };
                    createEntityResponse = (CreateEntityResponse)service.Execute(createEntityRequest);
                }
                return createEntityResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to retrieve an entity.
        /// </summary>
        /// <param name="entityName">The name of the entity to retrieve.</param>
        /// <returns>The retrieved entity metadata.</returns>
        public EntityMetadata RetrieveEntity(string entityName)
        {
            try
            {
                RetrieveEntityResponse retrieveEntityResponse;
                using (XrmService service = new XrmService(ConnectionString))
                {
                    RetrieveEntityRequest retrieveBankAccountEntityRequest = new RetrieveEntityRequest
                    {
                        EntityFilters = EntityFilters.Entity,
                        LogicalName = entityName
                    };
                    retrieveEntityResponse = (RetrieveEntityResponse)service.Execute(retrieveBankAccountEntityRequest);
                }
                return retrieveEntityResponse.EntityMetadata;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to update an entity.
        /// </summary>
        /// <param name="entity">The entity metadata object containing the details of the updates to be made to the entity.</param>
        public void UpdateEntity(EntityMetadata entity)
        {
            try
            {
                UpdateEntityRequest updateBankAccountRequest = new UpdateEntityRequest
                {
                    Entity = entity,
                    HasNotes = true
                };
                using (XrmService service = new XrmService(ConnectionString))
                {
                    service.Execute(updateBankAccountRequest);
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded Method to update an entity.
        /// </summary>
        /// <param name="entity">The entity metadata object containing the details of the updates to be made to the entity.</param>
        /// <param name="solutionName">The name of the solution in which to create the customisation.</param>
        public void UpdateEntity(EntityMetadata entity, string solutionName)
        {
            try
            {
                UpdateEntityRequest updateBankAccountRequest = new UpdateEntityRequest
                {
                    Entity = entity,
                    HasNotes = true,
                    SolutionUniqueName = solutionName
                };
                using (XrmService service = new XrmService(ConnectionString))
                {
                    service.Execute(updateBankAccountRequest);
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to delete an entity.
        /// </summary>
        /// <param name="entityName">The name of the entity to delete.</param>
        /// <returns>A response object containing the details of the delete attempt.</returns>
        public DeleteEntityResponse DeleteEntity(string entityName)
        {
            try
            {
                DeleteEntityResponse deleteEntityResponse;
                DeleteEntityRequest request = new DeleteEntityRequest()
                {
                    LogicalName = entityName,
                };
                using (XrmService service = new XrmService(ConnectionString))
                {
                    deleteEntityResponse = (DeleteEntityResponse)service.Execute(request);
                }
                return deleteEntityResponse;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        #endregion
    }
}
