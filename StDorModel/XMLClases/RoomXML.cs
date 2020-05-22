using CommLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace StDorModel.XMLClases
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RoomXML : BaseId
    {
        /// <summary>
        /// ID общежития
        /// </summary>
        [XmlAttributeAttribute()]
        public int DormitoryID { get; set; }

        /// <summary>
        /// Номер комнаты
        /// </summary>
        [XmlAttributeAttribute()]
        public int Number { get; set; }
    }


}
