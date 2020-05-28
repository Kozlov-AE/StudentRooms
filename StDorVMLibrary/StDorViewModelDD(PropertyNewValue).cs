using CommLibrary;
using StDorVMLibrary.Interfaces;
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
                DormitoryEdit.PropertyChanged -= Edit_PropertyChanged;

            /// Отлов изменения свойства RoomEdit
            if (propertyName == nameof(RoomEdit) && RoomEdit != null)
                RoomEdit.PropertyChanged -= Edit_PropertyChanged;

            base.PropertyNewValue(ref fieldProperty, newValue, propertyName);

            /// Отлов необходимости перевычисления свойства AllFalseIsMode
            if (Contains(propertyName, nameof(IsModeDormitoryAdd), nameof(IsModeDormitoryEdit), nameof(IsModeRoomAdd), nameof(IsModeRoomEdit)))
                OnPropertyChanged(nameof(AllFalseIsMode));

            /// Отлов изменения свойства DormitoryEdit
            if (propertyName == nameof(DormitoryEdit) && DormitoryEdit != null)
                DormitoryEdit.PropertyChanged += Edit_PropertyChanged;

            /// Отлов изменения свойства RoomEdit
            if (propertyName == nameof(RoomEdit) && RoomEdit != null)
                RoomEdit.PropertyChanged += Edit_PropertyChanged;


        }

        private void Edit_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender == DormitoryEdit)
                IsDormitoryModify
                    = IsModeDormitoryEdit
                    && string.IsNullOrWhiteSpace(DormitoryEdit.Title)
                    && string.IsNullOrWhiteSpace(DormitoryEdit.Address)
                    && (!IsModeDormitoryAdd && DormitoryEdit.EqualValues(DormitorySelected));
            else if (sender == RoomEdit)
                IsRoomModify
                    = IsModeRoomEdit
                    && Dormitories.Any(dor => dor.ID == RoomEdit.DormitoryID)
                    && (!IsModeRoomAdd && RoomEdit.EqualValues(RoomSelected));
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
