using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StDorVMLibrary.Interfaces
{
    /// <summary>Интерфейс VM для общежитий</summary>
    public interface IDormitory : IBaseId
    {
        /// <summary>Название общежития</summary>
        string Title { get; set; }

        /// <summary>Адрес общежития</summary>
        string Address { get; set; }
    }
}
