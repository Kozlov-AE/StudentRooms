using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StDorVMLibrary.Interfaces
{
    /// <summary>Интерфейс VM для комнат</summary>
    public interface IRoom : IBaseId
    {
        /// <summary>ID общежития</summary>
        int DormitoryID { get; set; }

        /// <summary>Номер комнаты</summary>
        int Number { get; set; }
    }
}
