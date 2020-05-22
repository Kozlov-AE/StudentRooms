using CommLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace StDorModelLibrary.DTOClasses
{
    public class RoomDTO : BaseIdDTO
    {
        /// <summary>Коструктор задающий значения свойствам</summary>
        /// <param name="id">ID экземпляра комнаты</param>
        /// <param name="dormitoryID">ID общежития</param>
        /// <param name="number">Номер комнаты</param>
        public RoomDTO(int id, int dormitoryID, int number) : base(id)
        {
            DormitoryID = dormitoryID;
            Number = number;
        }
        /// <summary>ID общежития</summary>
        public int DormitoryID { get; set; }
        /// <summary>Номер комнаты</summary>
        public int Number { get; set; }
    }
}
