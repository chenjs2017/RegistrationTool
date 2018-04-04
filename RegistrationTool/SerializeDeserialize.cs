using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace PluginRegistrationTool
{
    /// <summary>
    /// This class provides serialization methods.
    /// </summary>
    public class SerializeDeserialize
    {
        #region Properties

        /// <summary>
        /// Xml Serializer.
        /// </summary>
        private XmlSerializer _serializer;

        /// <summary>
        /// Xml Serializer.
        /// </summary>
        private XmlSerializer Serializer
        {
            get
            {
                return _serializer;
            }
            set
            {
                _serializer = value;
            }
        }

        /// <summary>
        /// ASCII Encoder.
        /// </summary>
        private ASCIIEncoding _encoder;

        /// <summary>
        /// ASCII Encoder.
        /// </summary>
        private ASCIIEncoding Encoder
        {
            get
            {
                return _encoder;
            }
            set
            {
                _encoder = value;
            }
        }

        /// <summary>
        /// Memory Stream.
        /// </summary>
        private MemoryStream _stream;

        /// <summary>
        /// Memory Stream.
        /// </summary>
        private MemoryStream Stream
        {
            get
            {
                return _stream;
            }
            set
            {
                _stream = value;
            }
        }

        /// <summary>
        /// Node.
        /// </summary>
        private XmlNode _node;

        /// <summary>
        /// Node.
        /// </summary>
        private XmlNode Node
        {
            get
            {
                return _node;
            }
            set
            {
                _node = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method deserializes an XML document into an object of a certain type.
        /// </summary>
        /// <param name="xmlInput">The XML Document to be deserialized.</param>
        /// <param name="type">The object type that the XML Document must be deserialized to.</param>
        /// <returns>An object of the type the XML Document is being deserialized to.</returns>
        /// <example>
        /// Serialization serializer = new Serialization();
        /// Object object = (Object)serializer.DeserializeXML(YourInputXmlDocument, typeof(Object));
        /// Substitute Object with your object type.
        /// </example>
        public object DeserializeXml(IXPathNavigable xmlInput, Type type)
        {
            try
            {
                if (xmlInput != null)
                {
                    Serializer = new XmlSerializer(type);
                    Encoder = new ASCIIEncoding();
                    Node = (XmlNode)xmlInput;
                    byte[] bytes = Encoder.GetBytes(Node.OuterXml);
                    Stream = new MemoryStream(bytes);
                    return Serializer.Deserialize(Stream);
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method serializes an object into an XML Document.
        /// </summary>
        /// <param name="deserializedValue">The object to be serialized into XML.</param>
        /// <returns>An XML Document.</returns>
        /// <example>
        /// Serialization serializer = new Serialization();
        /// XmlDocument xml = new XmlDocument();
        /// xml = serializer.SerializeObject(YourObject);
        /// </example>
        public IXPathNavigable SerializeObject(object deserializedValue)
        {
            try
            {
                if (deserializedValue != null)
                {
                    XmlDocument Xml = new XmlDocument();
                    Serializer = new XmlSerializer(deserializedValue.GetType());
                    Encoder = new ASCIIEncoding();
                    Stream = new MemoryStream();
                    Serializer.Serialize(Stream, deserializedValue);
                    byte[] bytes = Stream.ToArray();
                    Xml.LoadXml(Encoder.GetString(bytes));
                    return Xml;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
