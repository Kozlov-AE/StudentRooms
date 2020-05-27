using StDorModelLibrary.DTOClasses;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace StDorModelLibrary.Interfaces
{
    public interface IRooms : IBaseModelWorker<RoomDTO>
    {
        /// <summary>Возвращает все комнаты заданного общежития</summary>
        /// <param name="dormitory">Общежитие</param>
        /// <returns>Множество комнат</returns>
        /// <exception cref="StDorModelExceptionEnum">Возникает когда нет общежития с таким ID или когда его данные отличны</exception>
        Task<ImmutableHashSet<RoomDTO>> GetRoomsAsync(DormitoryDTO dormitory);

        /// <summary>Событие о любых изменениях в коллекции комнат</summary>
        /// <summary>Возвращает все комнаты заданного общежития</summary>
        /// <param name="dormitory">Общежитие</param>
        /// <returns>Множество комнат</returns>
        /// <exception cref="StDorModelExceptionEnum">Возникает когда нет общежития с таким ID или когда его данные отличны</exception>
        Task<ImmutableHashSet<RoomDTO>> GetRoomsAsync();
        /// <summary>Событие о любых изменениях в коллекции комнат</summary>

        event ChangedRoomsHandler ChangedRoomsEvent;
    }
}
