using System;
using System.Windows;
using System.Windows.Input;

namespace CommLibrary
{
    #region Делегаты для методов WPF команд
    /// <summary>Делегат исполняющего метода с параметром типа object</summary>
    /// <param name="parameter">Параметр метода</param>
    public delegate void ExecuteHandler(object parameter);
    /// <summary>Делегат проверяющего метода с парамтром типа object</summary>
    /// <param name="parameter">Параметр метода</param>
    public delegate bool CanExecuteHandler(object parameter);
    #endregion

    #region Класс команд - RelayCommand

    public class RelayCommand : ICommand
    {
        private readonly CanExecuteHandler canExecute = _ => true;
        private readonly ExecuteHandler onExecute;
        private readonly EventHandler requerySuggested;
        
        /// <summary>Конструктор команды</summary>
        /// <param name="onExecute">Выполняемый метод команды</param>
        /// <param name="canExecute">Метод разрешающий выполнение команды</param>
        public RelayCommand(ExecuteHandler onExecute, CanExecuteHandler canExecute = null)
        {
            this.onExecute = onExecute;
            if (canExecute != null)
                this.canExecute = canExecute;
            requerySuggested = (o, e) => Invalidate();
        }

        /// <summary>Метод вызывающий событие для перепроверки состояния</summary>
        public void Invalidate()
            => Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }), null);


        /// <summary>Событие извещающее об изменении команды</summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>Вызов метода проверяющего состояние команды</summary>
        /// <param name="parameter">Параметр команды</param>
        /// <returns><see langword="true"/>Если выполнение команды разрешено</returns>
        public bool CanExecute(object parameter) => canExecute.Invoke(parameter);
        /// <summary>Вызов исполняющего метода команды</summary>
        /// <param name="parameter">Параметр команды</param>
        public void Execute(object parameter) => onExecute?.Invoke(parameter);
    }
    #endregion
}
