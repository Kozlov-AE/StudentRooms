using CommLibrary;
using System.Collections.Generic;
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
    [System.Xml.Serialization.XmlRootAttribute(IsNullable = false, ElementName = "StudentDormitories")]
    public partial class StudentDormitoriesXML
    {
        /// <summary>
        /// Множество общежитий
        /// </summary>
        [XmlArrayItemAttribute("Dormitory", IsNullable = false)]
        public HashSet<DormitoryXML>  Dormitories { get; set; }

        /// <summary>
        /// Множество комнат
        /// </summary>
        [XmlArrayItem("Room", IsNullable = false)]
        public HashSet<RoomXML> Rooms { get; set; }
    }


}
