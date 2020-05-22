using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StDorModelLibrary.Interfaces
{
    /// <summary>Интерфейс дял работы с моделями</summary>
    /// <typeparam name="T">Тип модели</typeparam>
    public interface IBaseModelWorker<T>
    {
        /// <summary>Возвращает все объекты из коллекции</summary>
        /// <returns>Множество объектов <typeparamref name="T"/></returns>
        Task<HashSet<T>> GetAsync();
        /// <summary>Удаляет заданный экземпляр коллекции</summary>
        /// <param name="value">Удаляемый экземпляр</param>
        /// <exception cref="StDorModelExceptionEnum">Возникает когда нет экземпляра с таким ID или когда его данные отличны</exception>
        Task RemoveAsync(T value);
        /// <summary>Добавляет заданный экземпляр коллекции</summary>
        /// <param name="value">Добавляемый экземпляр</param>
        /// <remarks>value.ID игнорируется</remarks>
        Task AddAsync(T value);
        /// <summary>Изменяет заданный экземпляр коллекции</summary>
        /// <param name="value">Именяемый экземпляр</param>
        /// <exception cref="StDorModelExceptionEnum">Возникает когда нет экземпляра с таким ID</exception>
        Task ChangeAsync(T value);
    }
}
