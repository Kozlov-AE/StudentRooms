using CommLibrary;
using System.Xml.Serialization;

namespace StDorModel.XMLClases
{
    // Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
    /// <summary>
    /// Класс для десериализации XML с данными
    /// </summary>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class StudentDormitoriesXML : BaseId
    {
        /// <summary>
        /// Множество общежитий
        /// </summary>
        [XmlArrayItemAttribute("Dormitory", IsNullable = false)]
        public DormitoryXML[] Dormitories { get; set; }

        /// <summary>
        /// Множество комнат
        /// </summary>
        [XmlArrayItem("Room", IsNullable = false)]
        public RoomXML[] Rooms { get; set; }
    }


}
