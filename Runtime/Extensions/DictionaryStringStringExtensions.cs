using SorceressSpell.LibrarIoh.Xml;
using System.Collections.Generic;
using System.Xml;

namespace SorceressSpell.LibrarIoh.Collections
{
    public static class DictionaryStringStringExtensions
    {
        #region Methods

        public static void LoadFrom(this IDictionary<string, string> dictionary, XmlElement xmlElement, string propertyTag)
        {
            dictionary.Clear();

            if (xmlElement != null)
            {
                foreach (XmlElement propertyElement in xmlElement.SelectNodes(propertyTag))
                {
                    string propertyName = propertyElement.GetAttributeValue(Attribute.Name, "");
                    string propertyValue = propertyElement.GetAttributeValue(Attribute.Value, "");

                    dictionary.Add(propertyName, propertyValue);
                }
            }
        }

        public static void LoadFrom(this IDictionary<string, string> dictionary, XmlElement xmlElement)
        {
            dictionary.LoadFrom(xmlElement, Tag.Property);
        }

        #endregion Methods

        #region Classes

        public static class Attribute
        {
            #region Fields

            public const string Name = "name";
            public const string Value = "value";

            #endregion Fields
        }

        public static class Tag
        {
            #region Fields

            public const string Property = "Property";

            #endregion Fields
        }

        #endregion Classes
    }
}
