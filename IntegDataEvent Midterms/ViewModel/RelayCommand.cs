    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    namespace IntegDataEvent_Midterms.ViewModel
    {
        class RelayCommand : ICommand
        {
            private readonly Action<object> _execute;

            public RelayCommand(Action<object> execute) => _execute = execute;

            public bool CanExecute(object? parameter) => true;

            public void Execute(object? parameter) => _execute(parameter);

            // this fix removes the CS0067 by linking to the WPF CommandManager
            public event EventHandler? CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }
    }
