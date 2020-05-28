using CommLibrary;
using StDorVMLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StDorViewLibrary.DesignData
{
    public class RoomEditDD : OnPropertyChangedClass, IRoomEdit
    {
        private IRoom roomEdit;
        private bool isRoomModify;
        private bool isModeRoomEdit;
        private bool isModeRoomAdd;

        public ObservableCollection<IDormitory> Dormitories { get; } = new ObservableCollection<IDormitory>();
        public IRoom RoomEdit { get => roomEdit; set => SetProperty(ref roomEdit, value); }
        public bool IsRoomModify { get => isRoomModify; set => SetProperty(ref isRoomModify, value); }
        public bool IsModeRoomEdit { get => isModeRoomEdit; set => SetProperty(ref isModeRoomEdit, value); }
        public bool IsModeRoomAdd { get => isModeRoomAdd; set => SetProperty(ref isModeRoomAdd, value); }
    }
}
