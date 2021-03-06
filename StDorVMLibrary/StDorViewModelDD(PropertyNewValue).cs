﻿using CommLibrary;
using StDorVMLibrary.Interfaces;
using StDorVMLibrary.VMClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StDorVMLibrary
{
    public partial class StDorViewModelDD : OnPropertyChangedClass, IStDorViewModel
    {
        public static bool Contains(string value, params string[] values)
            => values.Contains(value);
        protected override void PropertyNewValue<T>(ref T fieldProperty, T newValue, string propertyName)
        {
            /// Отлов изменения свойства DormitoryEdit
            if (propertyName == nameof(DormitoryEdit) && DormitoryEdit != null)
                (DormitoryEdit as DormitoryVM).PropertyChanged -= Edit_PropertyChanged;

            /// Отлов изменения свойства RoomEdit
            if (propertyName == nameof(RoomEdit) && RoomEdit != null)
                (RoomEdit as RoomVM).PropertyChanged -= Edit_PropertyChanged;

            base.PropertyNewValue(ref fieldProperty, newValue, propertyName);

            /// Отлов необходимости перевычисления свойства AllFalseIsMode
            if (Contains(propertyName, nameof(IsModeDormitoryAdd), nameof(IsModeDormitoryEdit), nameof(IsModeRoomAdd), nameof(IsModeRoomEdit)))
                OnPropertyChanged(nameof(AllFalseIsMode));

            /// Отлов изменения свойства DormitoryEdit
            if (propertyName == nameof(DormitoryEdit) && DormitoryEdit != null)
                (DormitoryEdit as DormitoryVM).PropertyChanged += Edit_PropertyChanged;

            /// Отлов изменения свойства RoomEdit
            if (propertyName == nameof(RoomEdit) && RoomEdit != null)
                (RoomEdit as RoomVM).PropertyChanged += Edit_PropertyChanged;

            /// Отлов изменения свойств DormitorySelected, IsModeDormitoryEdit
            if (Contains(propertyName, nameof(DormitorySelected), nameof(IsModeDormitoryEdit)) && !IsModeDormitoryEdit)
                DormitoryEdit = DormitorySelected;

            /// Отлов изменения свойств RoomSelected, IsModeRoomEdit
            if (Contains(propertyName, nameof(RoomSelected), nameof(IsModeRoomEdit)) && !IsModeRoomEdit)
                RoomEdit = RoomSelected;
        }

        /// <summary>Проверка модификации общежития или комнаты</summary>
        /// <param name="sender">Модифицируемый объект</param>
        /// <param name="e">Парамеры события</param>
        private void Edit_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender == DormitoryEdit)
                IsDormitoryModify
                    = IsModeDormitoryEdit
                    && !string.IsNullOrWhiteSpace(DormitoryEdit.Title)
                    && !string.IsNullOrWhiteSpace(DormitoryEdit.Address)
                    && (IsModeDormitoryAdd || !(DormitoryEdit as DormitoryVM).EqualValues(DormitorySelected));
            else if (sender == RoomEdit)
                IsRoomModify
                    = IsModeRoomEdit
                    && Dormitories.Any(dor => dor.ID == RoomEdit.DormitoryID)
                    && !(IsModeRoomAdd || (RoomEdit as RoomVM).EqualValues(RoomSelected));
            else
            {
#if DEBUG
                ShowMethod($"Какой-то баг {sender}");
#else
                throw new Exception($"Какой-то баг {sender}");
#endif
            }
        }
    }
}
