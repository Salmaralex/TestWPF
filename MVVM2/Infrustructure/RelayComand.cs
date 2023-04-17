using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM2.Infrustructure
{
    class RelayComand : ICommand

    {
        public readonly Predicate<Object> predicate;

        public readonly Action<Object> action;

        public RelayComand(Action<Object> action, Predicate<Object> predicate = null)
        {

            this.action = action;
            this.predicate = predicate;

        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return predicate == null ? true : predicate(parameter);
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
