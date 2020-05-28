using CommLibrary;
using StDorVMLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StDorViewLibrary.DesignData
{
    class RoomDD : OnPropertyChangedClass, IRoom
    {
        private int dormitoryID;
        private int number;
        private int iD;

        public int DormitoryID { get => dormitoryID; set => SetProperty(ref dormitoryID, value); }
        public int Number { get => number; set => SetProperty(ref number, value); }
        public int ID { get => iD; set => SetProperty(ref iD, value); }
    }
}
