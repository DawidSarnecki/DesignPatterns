using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Command
{
    //There is general() implementation of Command pattern. RelayCommand is a standard command used in WPF (MVVM)
    class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute is null");
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        //There is a little problem. This event should react on changes of _canExecute value so there is two ways to resolve: 
        //1. way - manual handling changes of _canexecute value
        //2. auto cycle checking and reaction after check
        //I this situasion wpf librrary with CommandManager comes in handy.
        // I can transfer responsibility of handle changes of _canexecute value to the CommanManager. To use this class add reference to PresentationCore library is necesary.
        //There is no CommandManager on WindowsMobile or WindowsPhone.
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    // transfer responsibility of handle changes of this value to the CommanManager. 
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
