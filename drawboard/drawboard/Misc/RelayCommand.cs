using System;

namespace drawboard.Misc
{
    /// <summary>
    /// Basic ICommand implementation
    /// </summary>
    public class RelayCommand : System.Windows.Input.ICommand
	{
		private Predicate<object> canExecute;
		private Action<object> execute;

		public RelayCommand(Predicate<object> canExecute, Action<object> execute)
		{
			this.canExecute = canExecute;
			this.execute = execute;
		}

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// WinRT does not support CommandManager.. so need to raise these manually??
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

		public bool CanExecute(object parameter)
		{
			return canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			execute(parameter);
		}
	}
}
