using CommLibrary;
using StDorModelLibrary.DTOClasses;
using StDorVMLibrary.Interfaces;
using StDorVMLibrary.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StDorVMLibrary
{
    public partial class StDorViewModelDD : OnPropertyChangedClass, IStDorViewModel
    {

        #region if DEBUG
        /// <summary>Показывать исполняемые методы</summary>       
        private RelayCommand dormitoryCancelCommand;

        protected bool ShowExecutableMethod = true;

        /// <summary>Показ вызванного метода</summary>
        /// <param name="metodName">Название метода</param>
        protected void ShowMethod([CallerMemberName] string methodName = null)
        {
            if (ShowExecutableMethod)
                MessageBox.Show($"Вызван метод {methodName}");
        }
#endregion

        public RelayCommand DormitoryAddCommand => dormitoryAddCommand ?? (dormitoryAddCommand =
            new RelayCommandAction(DormitoryAddMethod, () => AllFalseIsMode));
        /// <summary>Метод добавления общежития</summary>
        protected virtual void DormitoryAddMethod()
        {
#region if DEBUG
            ShowMethod();
#endregion
            ///Создание нового экземпляра classVM для добавления
            DormitoryEdit = new DormitoryVM();
            ///Установка режимов
            IsModeDormitoryAdd = IsModeDormitoryEdit = true;
        }

        public RelayCommand DormitoryEditCommand => dormitoryEditCommand ?? (dormitoryEditCommand =
            new RelayCommandAction<DormitoryVM>(DormitoryEditMethod, _ => AllFalseIsMode));

        /// <summary>Метод редактирования общежития</summary>
        /// <param name="dormitory">Редактируемое общежитие</param>
        protected virtual void DormitoryEditMethod(DormitoryVM dormitory)
        {
#if DEBUG
            ShowMethod($"{dormitory.ID} {dormitory.Title} {dormitory.Address}");
#endif

            /// Запись экземпляра для редактирования
            DormitoryEdit = dormitory.Copy();
            IsModeDormitoryEdit = true;
            IsModeDormitoryAdd = false;
        }

        public RelayCommand DormitoryRemoveCommand => dormitoryRemoveCommand ?? (dormitoryRemoveCommand =
            new RelayCommandAction<DormitoryVM>(DormitoryRemoveMethod, _ => IsModeDormitoryEdit && IsDormitoryModify && DormitoryEdit != null));
        /// <summary>Метод удаления общежития</summary>
        /// <param name="dormitory">Удаляемое общежитие</param>
        protected virtual void DormitoryRemoveMethod(DormitoryVM dormitory)
        {
#if DEBUG
            ShowMethod($"{dormitory.ID} {dormitory.Title} {dormitory.Address}");
#endif
        }

        public RelayCommand DormitorySaveCommand => dormitorySaveCommand ?? (dormitorySaveCommand =
            new RelayCommandAction<DormitoryVM>(DormitorySaveMethod, _ => IsModeDormitoryEdit && IsDormitoryModify && DormitoryEdit != null));
        /// <summary>Метод сохранения Общежития</summary>
        protected void DormitorySaveMethod(DormitoryVM dormitory)
        {
#if DEBUG
            ShowMethod($" {DormitoryEdit.ID} {DormitoryEdit.Title} {DormitoryEdit.Address}");
#endif
            if (IsModeDormitoryAdd)
                DormitorySaveAddMethod(dormitory);
            else
                DormitorySaveChangeMethod(dormitory);

            /// После сохранения выход из режима редактирования
            DormitoryCancelMetod();
        }

        /// <summary>Метод сохранения добавляемого Общежития</summary>
        protected virtual void DormitorySaveAddMethod(DormitoryVM dormitory)
        {
#if DEBUG
            ShowMethod($"Добавляется {DormitoryEdit.ID} {DormitoryEdit.Title} {DormitoryEdit.Address}");
#endif
        }
        /// <summary>Метод сохранения изменяемого Общежития</summary>
        protected virtual void DormitorySaveChangeMethod(DormitoryVM dormitory)
        {
#if DEBUG
            ShowMethod($"Сохраняется {DormitoryEdit.ID} {DormitoryEdit.Title} {DormitoryEdit.Address}");
#endif
        }

        public RelayCommand DormitoryCancelCommand => dormitoryCancelCommand ?? (dormitoryCancelCommand =
            new RelayCommandAction(DormitoryCancelMetod, () => IsModeDormitoryEdit));
        protected virtual void DormitoryCancelMetod()
        {
#if DEBUG
            ShowMethod();
#endif
            DormitoryEdit = null;
            IsModeDormitoryEdit = IsModeDormitoryAdd = false;
        }

        public RelayCommand RoomAddCommand => roomAddCommand ?? (roomAddCommand =
            new RelayCommandAction(RoomAddMethod, () => AllFalseIsMode));
        /// <summary>Метод добавления комнаты</summary>
        protected virtual void RoomAddMethod()
        {
#if DEBUG
            ShowMethod();
#endif
            /// Создание нового экземпляра для добавления
            RoomEdit = new RoomVM();
            /// Установка режимов
            IsModeRoomEdit = IsModeRoomAdd = true;
        }

        /// <summary>Метод редактирования комнаты</summary>
        /// <param name="room">Редактируемая комната</param>
        public RelayCommand RoomEditCommand => roomEditCommand ?? (roomEditCommand =
            new RelayCommandAction<RoomVM>(RoomEditMethod, _ => AllFalseIsMode));
        protected virtual void RoomEditMethod(RoomVM room)
        {
#if DEBUG
            ShowMethod($"{room.ID} {room.DormitoryID} {room.Number}");
#endif
            /// Запись экземпляра для редактирования
            RoomEdit = room.Copy();
            IsModeRoomEdit = true;
            IsModeRoomAdd = false;
        }

        public RelayCommand RoomRemoveCommand => roomRemoveCommand ?? (roomRemoveCommand =
            new RelayCommandAction<RoomVM>(RoomRemoveMethod, _ => AllFalseIsMode));
        /// <summary>Метод удаления комнаты</summary>
        /// <param name="room">Удаляемая комната</param>
        protected virtual void RoomRemoveMethod(RoomVM room)
        {
#if DEBUG
            ShowMethod($"{room.ID} {room.DormitoryID} {room.Number}");
#endif
        }

        public RelayCommand RoomSaveCommand => roomSaveCommand ?? (roomSaveCommand =
            new RelayCommandAction(RoomSaveMethod, () => IsModeRoomEdit && IsRoomModify && RoomEdit != null));
        /// <summary>Метод сохранения общежития из свойства DormitoryEdit</summary>
        protected void RoomSaveMethod(RoomVM room)
        {
#if DEBUG
            ShowMethod($"{RoomEdit.ID} {RoomEdit.DormitoryID} {RoomEdit.Number}");
#endif
            if (IsModeRoomAdd)
                RoomSaveAddMethod(room);
            else
                RoomSaveChangeMethod(room);
            /// После сохранения выход из режима редактирования
            RoomCancelMethod();
        }


        /// <summary>Метод сохранения добавляемой Комнаты</summary>
        protected virtual void RoomSaveAddMethod(RoomVM room)
        {
#if DEBUG
            ShowMethod($"Добавляется {RoomEdit.ID} {RoomEdit.DormitoryID} {RoomEdit.Number}");
#endif
        }
        /// <summary>Метод сохранения изменяемой Комнаты</summary>
        protected virtual void RoomSaveChangeMethod(RoomVM room)
        {
#if DEBUG
            ShowMethod($"Сохраняется {RoomEdit.ID} {RoomEdit.DormitoryID} {RoomEdit.Number}");
#endif
        }

        public RelayCommand RoomCancelCommand => roomCancelCommand ?? (roomCancelCommand =
            new RelayCommandAction(RoomCancelMethod, () => IsModeRoomEdit));
        /// <summary>Метод отмены изменений</summary>
        private void RoomCancelMethod()
        {
#if DEBUG
            ShowMethod();
#endif
            RoomEdit = null;
            IsModeRoomEdit = IsModeRoomAdd = false;
        }

        private RelayCommand dormitoryAddCommand;
        private RelayCommand dormitoryEditCommand;
        private RelayCommand dormitoryRemoveCommand;
        private RelayCommand dormitorySaveCommand;
        private RelayCommand roomAddCommand;
        private RelayCommand roomEditCommand;
        private RelayCommand roomRemoveCommand;
        private RelayCommand roomSaveCommand;
        private RelayCommand roomCancelCommand;
    }
}
