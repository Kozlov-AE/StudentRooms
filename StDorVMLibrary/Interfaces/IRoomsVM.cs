﻿using CommLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StDorVMLibrary.Interfaces
{
    public interface IRoomsVM : IRoomEdit
    {
        /// <summary>Выделенное общежитие</summary>
        IDormitory DormitorySelected { get; set; }

        /// <summary>Коллекция комнат выделенного общежития</summary>
        ObservableCollection<IRoom> Rooms { get; }
        /// <summary>Выделенная комната</summary>
        IRoom RoomSelected { get; set; }

        /// <summary>Все режимы False</summary>
        bool AllFalseIsMode { get; }

        /// <summary>Команда добавления комнаты</summary>
        RelayCommand RoomAddCommand { get; }
        /// <summary>Команда редактирования комнаты</summary>
        RelayCommand RoomEditCommand { get; }
        /// <summary>Команда удаления комнаты</summary>
        RelayCommand RoomRemoveCommand { get; }
        /// <summary>Команда сохранения изменений в редактируемой/добавляемой комнате</summary>
        RelayCommand RoomSaveCommand { get; }
        /// <summary>Команда отмены изменений и выхода из режима редактирования/добавления комнаты</summary>
        RelayCommand RoomCancelCommand { get; }
    }
}
