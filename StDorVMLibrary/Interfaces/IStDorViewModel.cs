using CommLibrary;
using StDorVMLibrary.VMClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StDorVMLibrary.Interfaces
{
    /// <summary>Делегат события возникновения исключения</summary>
    /// <param name="sender">Источник исключения</param>
    /// <param name="nameMetod">Метод где возникло исключение</param>
    /// <param name="exc">Параметры исключения</param>
    public delegate void ExceptionHandler(object sender, string nameMetod, Exception exc);
    public interface IStDorViewModel : IDormitoryEdit, IRoomEdit, IDormitoriesVM, IRoomsVM, INotifyPropertyChanged
    {
        /// <summary>Событие с сообщением об ошибке</summary>
        event ExceptionHandler ExceptionEvent;
    }
}
