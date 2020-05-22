using StDorModelLibrary.DTOClasses;
using StDorModelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StDorModelLibrary
{
    public abstract class StDorModelBase : IStDorModel
    {
        /// <summary>Конструктор по умолчанию. Устанавливает IsDispossble = <see langword="false"/>.</summary>
        protected StDorModelBase() => IsDisposable = false;

        public bool IsDisposable { get; protected set; } = true;
        public bool IsLoaded { get; protected set; } = false;

        public event ChangedDormitoriesHandler ChangedDormitoriesEvent;
        /// <summary>Вспомогательный метод вызова события после удаления общежития</summary>
        /// <param name="dormitories">Удаленное общежитие</param>
        protected void OnRemoveDormitoriesEvent(HashSet<DormitoryDTO> dormitories) => ChangedDormitoriesEvent?.Invoke(this, ActionChanged.Remove, dormitories);
        /// <summary>Вспомогательный метод вызова события после добавления общежития</summary>
        /// <param name="dormitories">Добавленное общежитие</param>
        protected void OnAddDormitoriesEvent(HashSet<DormitoryDTO> dormitories) => ChangedDormitoriesEvent?.Invoke(this, ActionChanged.Add, dormitories);
        /// <summary>Вспомогательный метод вызова события после изменения общежития</summary>
        /// <param name="dormitories">Измененное общежитие</param>
        protected void OnChangeDormitoriesEvent(HashSet<DormitoryDTO> dormitories) => ChangedDormitoriesEvent?.Invoke(this, ActionChanged.Change, dormitories);

        public event ChangedRoomsHandler ChangedRoomsEvent;
        /// <summary>Вспомогательный метод вызова события после удаления комнаты</summary>
        /// <param name="dormitories">Удаленная комната</param>
        protected void OnRemoveRoomsEvent(HashSet<RoomDTO> rooms) => ChangedRoomsEvent?.Invoke(this, ActionChanged.Remove, rooms);
        /// <summary>Вспомогательный метод вызова события после добавления комнаты</summary>
        /// <param name="dormitories">Добавленная комната</param>
        protected void OnAddRoomsEvent(HashSet<RoomDTO> rooms) => ChangedRoomsEvent?.Invoke(this, ActionChanged.Add, rooms);        
        /// <summary>Вспомогательный метод вызова события после изменения комнаты</summary>
        /// <param name="dormitories">Измененная комната</param>
        protected void OnChangeRoomsEvent(HashSet<RoomDTO> rooms) => ChangedRoomsEvent?.Invoke(this, ActionChanged.Change, rooms);


        public Task<HashSet<DormitoryDTO>> GetAsync() => Task.Factory.StartNew(() => GetDormitories());
        /// <summary>Возвращает все общежития</summary>
        /// <returns>Множество общежитий</returns>
        protected abstract HashSet<DormitoryDTO> GetDormitories();

        public Task AddAsync(DormitoryDTO value) => Task.Factory.StartNew(() => AddDormitory(value));
        /// <summary>Добавляет заданное общежитие</summary>
        /// <param name="dormitory">Общежитие, которое надо добавить</param>
        /// <remarks>Dormitory.ID игнорируется</remarks>
        protected abstract void AddDormitory(DormitoryDTO dormitory);

        public Task ChangeAsync(DormitoryDTO value) => Task.Factory.StartNew(() => ChangeDormitory(value));
        /// <summary>Изменяет заданное общежитие</summary>
        /// <param name="dormitory">Новые данные для общежития с заданным ID</param>
        /// <exception cref="StDorModelException">Возникает когда нет общежития с таким ID</exception>
        protected abstract void ChangeDormitory(DormitoryDTO dormitory);

        public Task RemoveAsync(DormitoryDTO value) => Task.Factory.StartNew(() => RemoveDormitory(value));
        /// <summary>Удаляет заданное общежитие</summary>
        /// <param name="dormitory">Общежитие которое надо удалить</param>
        /// <exception cref="StDorModelException">Возникает когда нет общежития с таким ID или когда его данные отличны</exception>
        protected abstract void RemoveDormitory(DormitoryDTO dormitory);


        Task<HashSet<RoomDTO>> IBaseModelWorker<RoomDTO>.GetAsync() => Task.Factory.StartNew(() => GetRooms());
        /// <summary>Возвращает все комнаты всех общежитий</summary>
        /// <returns>Множество комнат</returns>
        protected abstract HashSet<RoomDTO> GetRooms();

        public Task<HashSet<RoomDTO>> GetAsync(DormitoryDTO dormitory) => Task.Factory.StartNew(() => GetRooms(dormitory));
        /// <summary>Возвращает все комнаты заданного общежития</summary>
        /// <returns>Множество комнат</returns>
        protected abstract HashSet<RoomDTO> GetRooms(DormitoryDTO dormitory);

        public Task AddAsync(RoomDTO value) => Task.Factory.StartNew(() => AddRoom(value));
        /// <summary>Добавляет заданную комнату</summary>
        /// <param name="room">Комната, которую надо добавить</param>
        /// <remarks>Room.ID игнорируется</remarks>
        protected abstract void AddRoom(RoomDTO room);

        public Task RemoveAsync(RoomDTO value) => Task.Factory.StartNew(() => RemoveRoom(value));
        /// <summary>Удаляет заданную комнату</summary>
        /// <param name="room"></param>
        protected abstract void RemoveRoom(RoomDTO room);

        public Task ChangeAsync(RoomDTO value) => Task.Factory.StartNew(() => ChangeRoom(value));
        /// <summary>Изменяет заданную комнату</summary>
        /// <param name="room">Новые данные для комнаты с заданным ID</param>
        /// <exception cref="StDorModelException">Возникает когда нет комнаты с таким ID</exception>
        protected abstract void ChangeRoom(RoomDTO room);

        public Task LoadAsync(string source) => Task.Factory.StartNew(() => Load(source));
        /// <summary>Загрузка данных</summary>
        /// <param name="source">Источник с данными</param>
        protected virtual void Load(string source) => IsLoaded = true;

        public Task CloseAsync() => Task.Factory.StartNew(() => Close());
        /// <summary>Закрытие источника данных и освобождение ресурсов</summary>
        protected virtual void Close() => Dispose();

        public void Dispose() => IsLoaded = !(IsDisposable = true);
    }
}
