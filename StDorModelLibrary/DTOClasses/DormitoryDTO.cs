using CommLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace StDorModelLibrary.DTOClasses
{
    public class DormitoryDTO : BaseIdDTO
    {
        /// <summary>
        /// Конструктор задающий значения
        /// </summary>
        /// <param name="id">ID экземпляра</param>
        /// <param name="title">Название общежития</param>
        /// <param name="address">Фдресс общежития</param>
        public DormitoryDTO(int id, string title, string address): base(id)
        {
            Title = title;
            Address = address;
        }
        /// <summary>
        /// Название общежития
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Адресс общежития
        /// </summary>
        public string Address { get; set; }

    }
}
