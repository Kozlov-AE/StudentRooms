using StDorVMLibrary;
using StDorVMLibrary.VMClasses;
using System;

namespace StDorViewModel
{
    /// <summary>Класс ViewModel для Модели работающей с Комнатами Общежитий</summary>
    public partial class MainViewModel : StDorViewModelDD
    {

        protected override void DormitoryRemoveMethod(DormitoryVM dormitory)
        {
            base.DormitoryRemoveMethod(dormitory);
            DormitoryRemoveMethodAsync(dormitory);
        }

        /// <summary>Асинхронный метод удаления Общежития</summary>
        /// <param name="dormitory">Удаляемое Общежитие</param>
        protected virtual async void DormitoryRemoveMethodAsync(DormitoryVM dormitory)
        {
            try { await model.RemoveAsync(dormitory.CopyDTO()); }
            catch (Exception ex) { OnException(ex); }
        }

        protected override void DormitorySaveAddMethod(DormitoryVM dormitory)
        {
            base.DormitorySaveAddMethod(dormitory);
            DormitoryAddMetodAsync(dormitory);
        }
        /// <summary>Асинхронный метод добавления Общежития</summary>
        /// <param name="dormitory">Добавляемое Общежитие</param>
        protected virtual async void DormitoryAddMetodAsync(DormitoryVM dormitory)
        {
            try { await model.AddAsync(dormitory.CopyDTO()); }
            catch (Exception ex) { OnException(ex); }
        }
        protected override void DormitorySaveChangeMethod(DormitoryVM dormitory)
        {
            DormitoryChangeMetodAsync(dormitory);
            base.DormitorySaveChangeMethod(dormitory);
        }
        /// <summary>Асинхронный метод изменения Общежития</summary>
        /// <param name="dormitory">Новые данные для Общежития</param>
        protected virtual async void DormitoryChangeMetodAsync(DormitoryVM dormitory)
        {
            try { await model.ChangeAsync(dormitory.CopyDTO()); }
            catch (Exception ex) { OnException(ex); }
        }

        protected override void RoomRemoveMethod(RoomVM room)
        {
            base.RoomRemoveMethod(room);
            RoomRemoveMethodAsync(room);
        }

        /// <summary>Асинхронный метод удаления Комнаты</summary>
        /// <param name="dormitory">Удаляемая Комната</param>
        protected virtual async void RoomRemoveMethodAsync(RoomVM room)
        {
            try { await model.RemoveAsync(room.CopyDTO()); }
            catch (Exception ex) { OnException(ex); }
        }

        protected override void RoomSaveAddMethod(RoomVM room)
        {
            base.RoomSaveAddMethod(room);
            RoomAddMethodAsync(room);
        }

        /// <summary>Асинхронный метод добавления Комнаты</summary>
        /// <param name="room">Добавляемая Комната</param>
        protected virtual async void RoomAddMethodAsync(RoomVM room)
        {
            try { await model.AddAsync(room.CopyDTO()); }
            catch (Exception ex) { OnException(ex); }
        }

        protected override void RoomSaveChangeMethod(RoomVM room)
        {
            base.RoomSaveChangeMethod(room);
            RoomChangeMethodAsync(room);
        }

        /// <summary>Асинхронный метод изменения Комнаты</summary>
        /// <param name="room">Новые данные для Комнаты</param>
        protected virtual async void RoomChangeMethodAsync(RoomVM room)
        {
            try { await model.ChangeAsync(room.CopyDTO()); }
            catch (Exception ex) { OnException(ex); }
        }
    }
}
