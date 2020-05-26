using System;
using System.Windows;
using System.Windows.Input;

namespace Common
{
    #region Делегаты для методов WPF команд
    /// <summary>Делегат исполняющего метода с параметром типа object</summary>
    /// <param name="parameter">Параметр метода</param>
    public delegate void ExecuteHandler(object parameter);
    /// <summary>Делегат проверяющего метода с парамтром типа object</summary>
    /// <param name="parameter">Параметр метода</param>
    public delegate bool CanExecuteHandler(object parameter);
    #endregion
    public class RelayCommand : ICommand
    {
        private readonly CanExecuteHandler canExecute = _ => true;
        private readonly ExecuteHandler onExecute;
        private readonly EventHandler requerySuggested;

        public RelayCommand(ExecuteHandler onExecute, CanExecuteHandler canExecute = null)
        {
            this.onExecute = onExecute;
            if (canExecute != null)
                this.canExecute = canExecute;
            requerySuggested = (o, e) => Invalidate();

        }

        public void Invalidate()
            => Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }), null);


        /// <summary>Событие извещающее об изменении команды</summary>
        public event EventHandler CanExecuteChanged;

        

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
