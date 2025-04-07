using System.Windows.Input;

namespace InventoryApp.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null) return true;
                
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (_execute == null) return;

            _execute(parameter);
        }
    }
}
