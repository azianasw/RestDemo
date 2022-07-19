using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp.Commands
{
    public abstract class CommandBase : ICommand
    {
        private bool _isExecuting;
        public bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        public void Execute(object parameter)
        {
            IsExecuting = true;

            ExecuteAsync(parameter);

            IsExecuting = false;
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}
