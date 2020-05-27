using CommLibrary;
using System.Xml.Serialization;

namespace StDorModel.XMLClases
{
    /// <summary>
    /// Класс для десереализации из XML одного общежития
    /// </summary>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DormitoryXML : BaseId
    {
        /// <summary>
        /// Название общежития
        /// </summary>
        [XmlAttributeAttribute()]
        public string Title { get; set; }

        /// <summary>
        /// Адресс общежития
        /// </summary>
        [XmlAttribute()]
        public string Address { get; set; }
    }


}
