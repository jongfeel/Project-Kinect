namespace Kinect.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using System.Diagnostics;

    class RelayCommand : ICommand
    {
        private Action<object> _action;

        public RelayCommand(Action<object> action)
        {
            _action = action;
        }

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged = null;

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        #endregion
    }
}
