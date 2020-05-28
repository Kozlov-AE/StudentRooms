using CommLibrary;
using StDorVMLibrary.Interfaces;
using StDorVMLibrary.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StDorViewLibrary.DesignData
{
    public class DormitoryEditData : OnPropertyChangedClass, IDormitoryEdit
    {
        private IDormitory dormitoryEdit;
        private bool isDormitoryModify;
        private bool isModeDormitoryEdit;
        private bool isModeDormitoryAdd;

        public IDormitory DormitoryEdit { get => dormitoryEdit; set => SetProperty(ref dormitoryEdit, value); }
        public bool IsDormitoryModify { get => isDormitoryModify; set => SetProperty(ref isDormitoryModify, value); }
        public bool IsModeDormitoryEdit { get => isModeDormitoryEdit; set => SetProperty(ref isModeDormitoryEdit, value); }
        public bool IsModeDormitoryAdd { get => isModeDormitoryAdd; set => SetProperty(ref isModeDormitoryAdd, value); }
    }
}
