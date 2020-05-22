using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StDorModelLibrary.Interfaces
{
    /// <summary>Общий интерфейс модели</summary>
    public interface IStDorModel : IDisposable, IDormitories, IRooms
    {
        /// <summary>Загрузка данных</summary>
        /// <param name="source">Источник данных</param>
        Task LoadAsync(string source);
        /// <summary>Закрытие источника данных</summary>
        Task CloseAsync();
        /// <summary>Модель недоступна</summary>
        bool IsDisposable { get; }
        /// <summary>Данные загружены</summary>
        bool IsLoaded { get; }
    }
}
