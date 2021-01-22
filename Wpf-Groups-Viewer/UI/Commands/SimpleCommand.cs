using System;
using System.Windows.Input;

namespace WpfGroupsViewer.UI.Commands
{
    public class SimpleCommand<T> : ICommand
    {
        #region Properties

        public Action<T> CommandAction { get; private set; }

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Fileds

        private bool CanExecuteCommand = true;

        #endregion

        #region Constructors

        public SimpleCommand(Action<T> commandAction)
        {
            CommandAction = commandAction;
        }

        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            return CanExecuteCommand;
        }

        public void Execute(object parameter)
        {
            CommandAction?.Invoke((T)parameter);
        }

        #endregion
    }
}
