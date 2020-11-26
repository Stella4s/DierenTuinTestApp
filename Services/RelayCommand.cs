using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DierenTuinTestApp.Services
{
    public class RelayCommand : ICommand
    {
        private Action _executeMethod;
        private Func<bool> _canExecuteMethod;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action executeMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = CanExecuteTrue;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public bool CanExecuteTrue()
        {
            return true;
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
    /*
    public class RelayCommand2 : ICommand
    {
        private readonly Action _executeMethod;
        private readonly Action<object> _executeObjMethod;
        private readonly Func<object, bool> _canExecuteMethod;

        public event EventHandler CanExecuteChanged;

        public RelayCommand2(Action executeMethod)
        {
            _executeMethod = executeMethod;
        }

        public RelayCommand2(Action<object> executeObjMethod)
        {
            _executeObjMethod = executeObjMethod;
        }

        public RelayCommand2(Action<object> executeObjMethod, Func<object, bool> canExcuteMethod)
        {
            _executeObjMethod = executeObjMethod;
            _canExecuteMethod = canExcuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod(parameter);
        }

        public void Execute()
        {
            _executeMethod();
        }

        public void Execute(object parameter)
        {
            _executeObjMethod(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }
    */
}
