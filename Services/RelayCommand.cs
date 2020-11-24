using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DierenTuinTestApp.Services
{
    public class RelayCommand<T> : ICommand
    {
        private Action<object> _executeMethod;
        private Func<object, bool> _canExecuteMethod;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> executeMethod)
        {
            _executeMethod = executeMethod;
        }

        public RelayCommand(Action<object> executeObjMethod, Func<object, bool> canExcuteMethod)
        {
            _executeMethod = executeObjMethod;
            _canExecuteMethod = canExcuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }

    public class RelayCommand : ICommand
    {
        private Action _executeMethod;
        private Func<bool> _canExecuteMethod;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action executeMethod)
        {
            _executeMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod();
        }

        public void Execute(object parameter)
        {
            _executeMethod();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

    }
}
