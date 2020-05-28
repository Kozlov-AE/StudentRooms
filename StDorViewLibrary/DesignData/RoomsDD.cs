using CommLibrary;
using StDorModelLibrary.DTOClasses;
using StDorModelLibrary.Interfaces;
using StDorVMLibrary.Interfaces;
using StDorVMLibrary.VMClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StDorViewLibrary.DesignData
{
    class RoomsDD : RoomEditDD, IRoomsVM
    {
        private IDormitory dormitorySelected;
        private IRoom roomSelected;
        private bool allFalseIsMode;

        public IDormitory DormitorySelected { get => dormitorySelected; set => SetProperty(ref dormitorySelected, value); }
        public ObservableCollection<IRoom> Rooms { get; } = new ObservableCollection<IRoom>();
        public IRoom RoomSelected { get => roomSelected; set => SetProperty(ref roomSelected, value); }
        public bool AllFalseIsMode { get => allFalseIsMode; set => SetProperty(ref allFalseIsMode, value); }

        public RelayCommand RoomAddCommand { get; }
        public RelayCommand RoomEditCommand { get; }
        public RelayCommand RoomRemoveCommand { get; }
        public RelayCommand RoomSaveCommand { get; }
        public RelayCommand RoomCancelCommand { get; }
    }
}
