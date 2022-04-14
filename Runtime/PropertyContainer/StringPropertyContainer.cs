using SorceressSpell.LibrarIoh.Core;
using SorceressSpell.LibrarIoh.Xml;
using System.Xml;

namespace SorceressSpell.LibrarIoh.Collections
{
    public class StringPropertyContainer : PropertyContainer<string>, ICopyFrom<StringPropertyContainer>, ILoadFrom<XmlElement>
    {
        #region Properties

        public string PropertyTag { private set; get; }

        #endregion Properties

        #region Constructors

        public StringPropertyContainer()
            : base()
        {
            PropertyTag = StringPropertyContainerXmlNames.Tag.Property;
        }

        public StringPropertyContainer(string propertyTag)
            : this()
        {
            PropertyTag = propertyTag;
        }

        #endregion Constructors

        #region Methods

        public void CopyFrom(StringPropertyContainer original)
        {
            base.CopyFrom(original);

            PropertyTag = original.PropertyTag;
        }

        public void LoadFrom(XmlElement xmlElement)
        {
            Clear();

            if (xmlElement != null)
            {
                foreach (XmlElement propertyElement in xmlElement.SelectNodes(PropertyTag))
                {
                    string propertyName = propertyElement.GetAttributeValue(StringPropertyContainerXmlNames.Attribute.Name, "");
                    string propertyValue = propertyElement.GetAttributeValue(StringPropertyContainerXmlNames.Attribute.Value, "");

                    Add(propertyName, propertyValue);
                }
            }
        }

        public void LoadFrom(XmlElement xmlElement, string propertyTag)
        {
            PropertyTag = propertyTag;
            LoadFrom(xmlElement);
        }

        #endregion Methods
    }
}
