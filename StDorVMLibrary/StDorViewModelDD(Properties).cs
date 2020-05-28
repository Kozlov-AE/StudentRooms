using CommLibrary;
using StDorVMLibrary.Interfaces;
using StDorVMLibrary.VMClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StDorVMLibrary
{
    public partial class StDorViewModelDD : OnPropertyChangedClass, IStDorViewModel
    {
        #region Поля для хранения свойств
        private DormitoryVM dormitorySelected;
        private DormitoryVM dormitoryEdit;
        private RoomVM roomSelected;
        private RoomVM roomEdit;
        private bool isDormitoryModify;
        private bool isModeDormitoryEdit;
        private bool isModeDormitoryAdd;
        private bool isRoomModify;
        private bool isModeRoomEdit;
        private bool isModeRoomAdd;
        private bool allFalseIsMode;
        #endregion

        public ObservableCollection<DormitoryVM> Dormitories { get; } = new ObservableCollection<DormitoryVM>();
        public DormitoryVM DormitorySelected { get => dormitorySelected; set => SetProperty(ref dormitorySelected, value); }
        public DormitoryVM DormitoryEdit { get => dormitoryEdit; set => SetProperty(ref dormitoryEdit, value); }

        public ObservableCollection<RoomVM> Rooms { get; } = new ObservableCollection<RoomVM>();
        public RoomVM RoomSelected { get => roomSelected; set => SetProperty(ref roomSelected, value); }
        public RoomVM RoomEdit { get => roomEdit; set => SetProperty(ref roomEdit, value); }

        public bool IsDormitoryModify { get => isDormitoryModify; set => SetProperty(ref isDormitoryModify, value); }
        public bool IsModeDormitoryEdit { get => isModeDormitoryEdit; set => SetProperty(ref isModeDormitoryEdit, value); }
        public bool IsModeDormitoryAdd { get => isModeDormitoryAdd; set => SetProperty(ref isModeDormitoryAdd, value); }

        public bool IsRoomModify { get => isRoomModify; set => SetProperty(ref isRoomModify, value); }
        public bool IsModeRoomEdit { get => isModeRoomEdit; set => SetProperty(ref isModeRoomEdit, value); }
        public bool IsModeRoomAdd { get => isModeRoomAdd; set => SetProperty(ref isModeRoomAdd, value); }

        public bool AllFalseIsMode => !(IsModeDormitoryEdit || IsModeDormitoryAdd || IsModeRoomEdit || IsModeRoomAdd);

    }
}
