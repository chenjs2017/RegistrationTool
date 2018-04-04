using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using PluginRegistrationTool;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The Image Helper Class.
    /// </summary>
    internal class ImageHelper
    {
        #region Properties

        /// <summary>
        /// Registration Service.
        /// </summary>
        private RegistrationService _registrationService = new RegistrationService();

        /// <summary>
        /// Registration Service.
        /// </summary>
        private RegistrationService RegistrationService
        {
            get
            {
                return _registrationService;
            }
        }

        /// <summary>
        /// XRM Service.
        /// </summary>
        XrmService _xrmService;

        /// <summary>
        /// XRM Service.
        /// </summary>
        private XrmService xrmService
        {
            get
            {
                return _xrmService;
            }
            set
            {
                _xrmService = value;
            }
        }

        /// <summary>
        /// Image Exception Error Message.
        /// </summary>
        private string _imageExceptionErrorMessage;

        /// <summary>
        /// Image Exception Error Message.
        /// </summary>
        private string ImageExceptionErrorMessage
        {
            get
            {
                return _imageExceptionErrorMessage;
            }
            set
            {
                _imageExceptionErrorMessage = value;
            }
        }

        /// <summary>
        /// Attribute CSV.
        /// </summary>
        private string _attributeCSV;

        /// <summary>
        /// Attribute CSV.
        /// </summary>
        private string AttributeCSV
        {
            get
            {
                return _attributeCSV;
            }
            set
            {
                _attributeCSV = value;
            }
        }

        /// <summary>
        /// Image Details.
        /// </summary>
        private ItemExists _imageDetails;

        /// <summary>
        /// Image Details.
        /// </summary>
        private ItemExists ImageDetails
        {
            get
            {
                return _imageDetails;
            }
            set
            {
                _imageDetails = value;
            }
        }

        /// <summary>
        /// Query SDK Message Processing Step Image.
        /// </summary>
        private QueryExpression _querySdkMessageProcessingStepImage;

        /// <summary>
        /// Query SDK Message Processing Step Image.
        /// </summary>
        private QueryExpression QuerySdkMessageProcessingStepImage
        {
            get
            {
                return _querySdkMessageProcessingStepImage;
            }
            set
            {
                _querySdkMessageProcessingStepImage = value;
            }
        }

        /// <summary>
        /// SDK Message Processing Step Image Entity Collection.
        /// </summary>
        private EntityCollection _sdkMessageProcessingStepImageEntityCollection;

        /// <summary>
        /// SDK Message Processing Step Image Entity Collection.
        /// </summary>
        private EntityCollection SdkMessageProcessingStepImageEntityCollection
        {
            get
            {
                return _sdkMessageProcessingStepImageEntityCollection;
            }
            set
            {
                _sdkMessageProcessingStepImageEntityCollection = value;
            }
        }

        /// <summary>
        /// SDK Message Processing Step Image.
        /// </summary>
        private SdkMessageProcessingStepImage _sdkMessageProcessingStepImage;

        /// <summary>
        /// SDK Message Processing Step Image.
        /// </summary>
        private SdkMessageProcessingStepImage SdkMessageProcessingStepImage
        {
            get
            {
                return _sdkMessageProcessingStepImage;
            }
            set
            {
                _sdkMessageProcessingStepImage = value;
            }
        }

        /// <summary>
        /// Message Property Name.
        /// </summary>
        private string _messagePropertyName;

        /// <summary>
        /// Message Property Name.
        /// </summary>
        private string MessagePropertyName
        {
            get
            {
                return _messagePropertyName;
            }
            set
            {
                _messagePropertyName = value;
            }
        }

        /// <summary>
        /// Result indicating success or failure.
        /// </summary>
        private bool _result;

        /// <summary>
        /// Result indicating success or failure.
        /// </summary>
        private bool Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        #endregion

        #region Image Methods

        /// <summary>
        /// Method to retrieve the list of Images specified in the Registration Object linked to the Step object and populate the XRM Plugin Step accordingly.
        /// </summary>
        /// <param name="registration">The Registration Object.</param>
        /// <param name="step">The Step Object.</param>
        /// <param name="xrmPluginStep">The XRM Plugin Step Object.</param>
        internal XrmPluginStep GetRegistrationImages(string xrmServerDetails, PluginStep step, XrmPluginStep xrmPluginStep)
        {
            try
            {
                foreach (Image image in step.Images)
                {
                    ValidateImage(step, image);
                    XrmPluginImage xrmPluginImage = new XrmPluginImage();
                    using (xrmService = RegistrationService.GetService(xrmServerDetails))
                    {
                        string attributeCSV = GetAttributeCSV(new XrmMetadata(xrmServerDetails), image, step.PrimaryEntity);
                        ItemExists imageDetails = GetImageId(xrmPluginStep, image, xrmService, attributeCSV);
                        xrmPluginImage.ImageId = imageDetails.ItemId;
                        xrmPluginImage.Exists = imageDetails.Exists;
                        xrmPluginImage.StepId = xrmPluginStep.StepId;
                        xrmPluginImage.ImageType = image.ImageType;
                        if (!string.IsNullOrEmpty(attributeCSV))
                        {
                            xrmPluginImage.Attributes = attributeCSV;
                        }
                        xrmPluginImage.EntityAlias = image.EntityAlias;
                        xrmPluginImage.MessageProperty = image.MessageProperty;
                        if (image.Merge.HasValue)
                        {
                            xrmPluginImage.MessagePropertyName = GetMessagePropertyName(step.PluginMessage, image.Merge.Value);
                        }
                        else
                        {
                            xrmPluginImage.MessagePropertyName = GetMessagePropertyName(step.PluginMessage);
                        }
                        xrmPluginStep.Images.Add(xrmPluginImage);
                    }
                }
                return xrmPluginStep;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to Register an Image.
        /// </summary>
        /// <param name="xrmPluginImage">The Image to Register.</param>
        /// <returns>The newly Registered Image Identifier.</returns>
        internal Guid RegisterImage(string xrmServerDetails, XrmPluginImage xrmPluginImage)
        {
            try
            {
                using (xrmService = RegistrationService.GetService(xrmServerDetails))
                {
                    SdkMessageProcessingStepImage sdkMessageProcessingStepImage = GetPluginImage(xrmPluginImage);
                    return xrmService.Create(sdkMessageProcessingStepImage);
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to Update an Image Registration.
        /// </summary>
        /// <param name="xrmPluginImage">The Image to Update.</param>
        /// <returns>Result.</returns>
        internal bool UpdateImage(string  xrmServerDetails, XrmPluginImage xrmPluginImage)
        {
            try
            {
                Result = false;
                using (xrmService = RegistrationService.GetService(xrmServerDetails))
                {
                    SdkMessageProcessingStepImage sdkMessageProcessingStepImage = GetPluginImage(xrmPluginImage);
                    xrmService.Update(sdkMessageProcessingStepImage);
                }
                Result = true;
                return Result;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to Unregister an Image.
        /// </summary>
        /// <param name="xrmPluginImage">The Image to Unregister.</param>
        /// <returns>Result.</returns>
        internal bool UnregisterImage(string xrmServerDetails, XrmPluginImage xrmPluginImage, Collection<string> errors, SolutionComponentType solutionComponentType)
        {
            try
            {
                Result = RegistrationService.Unregister(xrmServerDetails, SdkMessageProcessingStepImage.EntityLogicalName, xrmPluginImage.ImageId.Value, errors, solutionComponentType);
                return Result;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to populate a Dynamics CRM Image from a XRM Image and retrieve it.
        /// </summary>
        /// <param name="xrmPluginImage">The ZRM Image providing the details.</param>
        /// <returns>The Dynamics CRM Image.</returns>
        private SdkMessageProcessingStepImage GetPluginImage(XrmPluginImage xrmPluginImage)
        {
            try
            {
                SdkMessageProcessingStepImage = new SdkMessageProcessingStepImage();
                if (!string.IsNullOrEmpty(xrmPluginImage.Attributes))
                {
                    SdkMessageProcessingStepImage.Attributes1 = xrmPluginImage.Attributes;
                }
                SdkMessageProcessingStepImage.EntityAlias = xrmPluginImage.EntityAlias;
                SdkMessageProcessingStepImage.SdkMessageProcessingStepImageId = xrmPluginImage.ImageId;
                SdkMessageProcessingStepImage.Name = xrmPluginImage.MessageProperty;
                SdkMessageProcessingStepImage.MessagePropertyName = xrmPluginImage.MessagePropertyName;
                SdkMessageProcessingStepImage.SdkMessageProcessingStepId = new EntityReference(SdkMessageProcessingStep.EntityLogicalName, xrmPluginImage.StepId.Value);
                SdkMessageProcessingStepImage.ImageType = new OptionSetValue((int)xrmPluginImage.ImageType);
                return SdkMessageProcessingStepImage;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to verify if the Image is already registered in Dynamics CRM.
        /// </summary>
        /// <param name="xrmPluginStep">The XRM Step Object.</param>
        /// <param name="image">The Image Object.</param>
        /// <param name="service">The XRM Service.</param>
        /// <param name="attributeCSV">A CSV of Attributes.</param>
        /// <returns>An Object containing the details of the verification. If the Image deosn't already exists, a new Image Identifier is returned.</returns>
        private ItemExists GetImageId(XrmPluginStep xrmPluginStep, Image image, XrmService service, string attributeCSV)
        {
            try
            {
                ImageDetails = new ItemExists();
                QuerySdkMessageProcessingStepImage = new QueryExpression(SdkMessageProcessingStepImage.EntityLogicalName)
                {
                    ColumnSet = new ColumnSet("sdkmessageprocessingstepimageid"),
                    Criteria = new FilterExpression()
                };
                QuerySdkMessageProcessingStepImage.Criteria.AddCondition("entityalias", ConditionOperator.Equal, image.EntityAlias);
                QuerySdkMessageProcessingStepImage.Criteria.AddCondition("imagetype", ConditionOperator.Equal, (int)image.ImageType);
                if (!string.IsNullOrEmpty(attributeCSV))
                {
                    QuerySdkMessageProcessingStepImage.Criteria.AddCondition("attributes", ConditionOperator.Equal, attributeCSV);
                }
                QuerySdkMessageProcessingStepImage.Criteria.AddCondition("name", ConditionOperator.Equal, image.MessageProperty);
                QuerySdkMessageProcessingStepImage.Criteria.AddCondition("sdkmessageprocessingstepid", ConditionOperator.Equal, xrmPluginStep.StepId);
                SdkMessageProcessingStepImageEntityCollection = service.RetrieveMultiple(QuerySdkMessageProcessingStepImage);
                if (SdkMessageProcessingStepImageEntityCollection.Entities.Count != 0)
                {
                    foreach (Entity entity in SdkMessageProcessingStepImageEntityCollection.Entities)
                    {
                        SdkMessageProcessingStepImage = (SdkMessageProcessingStepImage)entity;
                        if (SdkMessageProcessingStepImage.SdkMessageProcessingStepImageId.HasValue)
                        {
                            ImageDetails.ItemId = SdkMessageProcessingStepImage.SdkMessageProcessingStepImageId.Value;
                            ImageDetails.Exists = true;
                        }
                        else
                        {
                            ImageDetails.ItemId = Guid.NewGuid();
                            ImageDetails.Exists = false;
                        }
                    }
                }
                else
                {
                    ImageDetails.ItemId = Guid.NewGuid();
                    ImageDetails.Exists = false;
                }
                return ImageDetails;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to validate the Image before Registration.
        /// In certain circumstances, Dynamics CRM will not allow the Registration of an Image.
        /// </summary>
        /// <param name="step">The Step Object.</param>
        /// <param name="image">The Image Object.</param>
        private void ValidateImage(PluginStep step, Image image)
        {
            try
            {
                if (image.ImageType == XrmImageType.PreImage)
                {
                    if (step.PluginMessage == "Create")
                    {
                        if (step.Stage == XrmPluginStepStage.PreValidation || step.Stage == XrmPluginStepStage.PreOperation)
                        {
                            throw new ArgumentException(GetImageExceptionErrorMessage(step, image));
                        }
                    }
                }
                else
                {
                    if (step.Stage == XrmPluginStepStage.PreValidation || step.Stage == XrmPluginStepStage.PreOperation)
                    {
                        throw new ArgumentException(GetImageExceptionErrorMessage(step, image));
                    }
                    if (step.Stage == XrmPluginStepStage.PostOperationDeprecated || step.Stage == XrmPluginStepStage.PostOperation)
                    {
                        if (step.PluginMessage == "Delete")
                        {
                            throw new ArgumentException(GetImageExceptionErrorMessage(step, image));
                        }
                    }
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to retrieve the correct Message Property Name for Registration.
        /// </summary>
        /// <param name="message">The Message String.</param>
        /// <returns>The Message Property Name String.</returns>
        private string GetMessagePropertyName(string message)
        {
            try
            {
                switch (message)
                {
                    case "Assign":
                        this.MessagePropertyName = "Target";
                        break;
                    case "Create":
                        this.MessagePropertyName = "Id";
                        break;
                    case "Delete":
                        this.MessagePropertyName = "Target";
                        break;
                    case "DeliverIncoming":
                        this.MessagePropertyName = "EmailId";
                        break;
                    case "DeliverPromote":
                        this.MessagePropertyName = "EmailId";
                        break;
                    case "ExecuteWorkflow":
                        this.MessagePropertyName = "Target";
                        break;
                    case "Merge":
                        throw new ArgumentException("No parent or child specified for the Merge message for this image.");
                    case "Route":
                        this.MessagePropertyName = "Target";
                        break;
                    case "Send":
                        this.MessagePropertyName = "EmailId";
                        break;
                    case "SetState":
                        this.MessagePropertyName = "EntityMoniker";
                        break;
                    case "SetStateDynamicEntity":
                        this.MessagePropertyName = "EntityMoniker";
                        break;
                    case "Update":
                        this.MessagePropertyName = "Target";
                        break;
                    default:
                        this.MessagePropertyName = string.Empty;
                        break;
                }
                return this.MessagePropertyName;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Overloaded method to retrieve the correct Message Property Name for Registration.
        /// </summary>
        /// <param name="message">The Message String.</param>
        /// <param name="merge">The Image Merge Enumerator.</param>
        /// <returns>The Message Property Name String.</returns>
        private string GetMessagePropertyName(string message, ImageMerge merge)
        {
            try
            {
                switch (message)
                {
                    case "Assign":
                        this.MessagePropertyName = "Target";
                        break;
                    case "Create":
                        this.MessagePropertyName = "Id";
                        break;
                    case "Delete":
                        this.MessagePropertyName = "Target";
                        break;
                    case "DeliverIncoming":
                        this.MessagePropertyName = "EmailId";
                        break;
                    case "DeliverPromote":
                        this.MessagePropertyName = "EmailId";
                        break;
                    case "ExecuteWorkflow":
                        this.MessagePropertyName = "Target";
                        break;
                    case "Merge":
                        if (merge == ImageMerge.Parent)
                        {
                            this.MessagePropertyName = "Target";
                        }
                        if (merge == ImageMerge.Child)
                        {
                            this.MessagePropertyName = "SubordinateId";
                        }
                        if (merge == ImageMerge.None)
                        {
                            throw new ArgumentException("No parent or child specified for the Merge message for this image.");
                        }
                        break;
                    case "Route":
                        this.MessagePropertyName = "Target";
                        break;
                    case "Send":
                        this.MessagePropertyName = "EmailId";
                        break;
                    case "SetState":
                        this.MessagePropertyName = "EntityMoniker";
                        break;
                    case "SetStateDynamicEntity":
                        this.MessagePropertyName = "EntityMoniker";
                        break;
                    case "Update":
                        this.MessagePropertyName = "Target";
                        break;
                    default:
                        this.MessagePropertyName = string.Empty;
                        break;
                }
                return this.MessagePropertyName;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method that returns an Exception Message.
        /// </summary>
        /// <param name="step">The Step Object.</param>
        /// <param name="image">The Image Object.</param>
        /// <returns>The Error Message.</returns>
        private string GetImageExceptionErrorMessage(PluginStep step, Image image)
        {
            try
            {
                this.ImageExceptionErrorMessage = "Cannot create an image for " + step.PluginMessage + " for a " + step.Stage + " step for a " + image.ImageType + " image.";
                return this.ImageExceptionErrorMessage;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to build a CSV from a Collection of String representing Dynamics CRM Attributes/Fields.
        /// </summary>
        /// <param name="metadata">The XRM Metadata Object.</param>
        /// <param name="image">The Image Object.</param>
        /// <param name="entity">A String representing the Name of the Entity.</param>
        /// <returns>The CSV String of Attributes.</returns>
        private string GetAttributeCSV(XrmMetadata metadata, Image image, string entity)
        {
            try
            {
                AttributeCSV = string.Empty;
                if (image.Attributes != null && image.Attributes.Count != 0)
                {
                    for (int i = 0; i < image.Attributes.Count; i++)
                    {
                        if (metadata.RetrieveAttribute(image.Attributes[i], entity).AttributeMetadata.LogicalName == image.Attributes[i])
                        {
                            AttributeCSV += image.Attributes[i];
                            if (i != image.Attributes.Count - 1)
                            {
                                AttributeCSV += ",";
                            }
                        }
                        else
                        {
                            throw new ArgumentException("The field does not exist in this entity.");
                        }
                    }
                }
                return AttributeCSV;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        #endregion
    }
}
