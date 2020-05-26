using StDorModelLibrary.DTOClasses;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading.Tasks;

namespace StDorModelLibrary.Interfaces
{
    public interface IDormitories : IBaseModelWorker<DormitoryDTO>
    {
        /// <summary>Возвращает все объекты из коллекции</summary>
        /// <returns>Множество объектов <typeparamref name="T"/></returns>
        Task<ImmutableHashSet<DormitoryDTO>> GetDormitoriesAsync();

        event ChangedDormitoriesHandler ChangedDormitoriesEvent;
    }
}
