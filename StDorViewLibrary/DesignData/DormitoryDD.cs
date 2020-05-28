using CommLibrary;
using StDorVMLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StDorViewLibrary.DesignData
{
    public class DormitoryDD : OnPropertyChangedClass, IDormitory
    {
        private string title;
        private string address;
        private int iD;

        public string Title { get => title; set => SetProperty(ref title, value); }
        public string Address { get => address; set => SetProperty(ref address, value); }
        public int ID { get => iD; set => SetProperty(ref iD, value); }
    }
}
