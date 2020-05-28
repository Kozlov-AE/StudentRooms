using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>Базовый интерфейс для типов с ID</summary>
    public interface IBaseId
    {
        /// <summary>Идентификатор</summary>
        int ID { get; set; }
    }
}
