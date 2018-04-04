using System;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The XRM Plugin Image Class.
    /// An Image is linked to a Plugin Step and provides a snapshot of properties in the Plugin Context at a certain point in time, perhaps before or after modification by the Plugin or by Dynamics CRM.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Xrm"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
    public class XrmPluginImage
    {
        /// <summary>
        /// The Step Identifier Property.
        /// This links the Image to its Step.
        /// </summary>
        private Guid? _stepId;

        /// <summary>
        /// The Step Identifier Property.
        /// This links the Image to its Step.
        /// </summary>
        public Guid? StepId
        {
            get
            {
                return _stepId;
            }
            set
            {
                _stepId = value;
            }
        }

        /// <summary>
        /// The Image Identifier Property.
        /// </summary>
        private Guid? _imageId;

        /// <summary>
        /// The Image Identifier Property.
        /// </summary>
        public Guid? ImageId
        {
            get
            {
                return _imageId;
            }
            set
            {
                _imageId = value;
            }
        }

        /// <summary>
        /// Boolean Property indicating if the Image is already registered in Dynamics CRM.
        /// </summary>
        private bool _exists;

        /// <summary>
        /// Boolean Property indicating if the Image is already registered in Dynamics CRM.
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
        /// The XRM Image Type Enumerator Property.
        /// </summary>
        private XrmImageType _imageType;

        /// <summary>
        /// The XRM Image Type Enumerator Property.
        /// </summary>
        public XrmImageType ImageType
        {
            get
            {
                return _imageType;
            }
            set
            {
                _imageType = value;
            }
        }

        /// <summary>
        /// The Entity Alias String Property.
        /// This will be the name used for the Entity Object that will store the snapshot.
        /// </summary>
        private string _entityAlias;

        /// <summary>
        /// The Entity Alias String Property.
        /// This will be the name used for the Entity Object in the Image.
        /// </summary>
        public string EntityAlias
        {
            get
            {
                return _entityAlias;
            }
            set
            {
                _entityAlias = value;
            }
        }

        /// <summary>
        /// The Attributes String Property.
        /// Comma separated list of Attributes/Fields to include in the Image.
        /// If this is not populated, all Attributes will be included in the Image.
        /// </summary>
        private string _attributes;

        /// <summary>
        /// The Attributes String Property.
        /// Comma separated list of Attributes/Fields to include in the Image.
        /// If this is not populated, all Attributes will be included in the Image.
        /// </summary>
        public string Attributes
        {
            get
            {
                return _attributes;
            }
            set
            {
                _attributes = value;
            }
        }

        /// <summary>
        /// The Message Property String Property.
        /// This will be the name of the Property in the Image.
        /// </summary>
        private string _messageProperty;

        /// <summary>
        /// The Message Property String Property.
        /// This will be the name of the Property in the Image.
        /// </summary>
        public string MessageProperty
        {
            get
            {
                return _messageProperty;
            }
            set
            {
                _messageProperty = value;
            }
        }

        /// <summary>
        /// The Message Property Name String Property.
        /// This is the actual name of the Property in the Context that will be stored by the Image.
        /// </summary>
        private string _messagePropertyName;

        /// <summary>
        /// The Message Property Name String Property.
        /// This is the actual name of the Property in the Context that will be stored by the Image.
        /// </summary>
        public string MessagePropertyName
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
    }
}
