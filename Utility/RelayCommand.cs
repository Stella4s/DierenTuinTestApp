using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DierenTuinWPF.Utility
{
    public class RelayCommand : ICommand
    {
        private Action<object> _executeMethod;
        private Func<object, bool> _canExecuteMethod;

        public RelayCommand(Action<object> executeMethod) : this(executeMethod, null) { }
        public RelayCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        #region eventhandling
        //Using CommandManager method of CanExecuteChanged.
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        //Using RaiseCanExecuteChanged method of eventhandling.
        /*public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
            // CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }*/
        #endregion

        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod != null ? _canExecuteMethod(parameter) : true;
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }
    }
}
