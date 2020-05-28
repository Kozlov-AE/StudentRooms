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
    public class DormitoriesDD : DormitoryEditData, IDormitoriesVM
    {
        private IDormitory dormitorySelected;
        private bool allFalseIsMode;

        public ObservableCollection<IDormitory> Dormitories { get; } = new ObservableCollection<IDormitory>();
        public IDormitory DormitorySelected { get => dormitorySelected; set => SetProperty(ref dormitorySelected, value); }
        public bool AllFalseIsMode { get => allFalseIsMode; set => SetProperty(ref allFalseIsMode, value); }

        public RelayCommand DormitoryAddCommand { get; }
        public RelayCommand DormitoryEditCommand { get; }
        public RelayCommand DormitoryRemoveCommand { get; }
        public RelayCommand DormitorySaveCommand { get; }
        public RelayCommand DormitoryCancelCommand { get; }
    }
}
