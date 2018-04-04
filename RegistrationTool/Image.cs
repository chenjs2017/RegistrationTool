using System.Collections.ObjectModel;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The Image Class.
    /// Contains all the properties of an Image Object.
    /// </summary>
    public class Image
    {
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
        /// </summary>
        private string _entityAlias;

        /// <summary>
        /// The Entity Alias String Property.
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
        /// A Property containing a Collection of Strings, which are the Attributes to be included in the Image.
        /// </summary>
        private Collection<string> _attributes = new Collection<string>();

        /// <summary>
        /// A Property containing a Collection of Strings, which are the Attributes to be included in the Image.
        /// </summary>
        public Collection<string> Attributes
        {
            get
            {
                return _attributes;
            }
        }

        /// <summary>
        /// The Message Property String Property.
        /// </summary>
        private string _messageProperty;

        /// <summary>
        /// The Message Property String Property.
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
        /// The nullable Image Merge Enumerator Property.
        /// </summary>
        private ImageMerge? _merge;

        /// <summary>
        /// The nullable Image Merge Enumerator Property.
        /// </summary>
        public ImageMerge? Merge
        {
            get
            {
                return _merge;
            }
            set
            {
                _merge = value;
            }
        }
    }
}
