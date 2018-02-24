using drawboard.Misc;
using System.Windows.Input;

namespace drawboard.ViewModels
{
    /// <summary>
    /// VM for <see cref="MainPage"/>
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        private string username;
        private string password;

        /// <summary>
        /// Ctor
        /// </summary>
        public MainPageViewModel()
        {
            LoginCommand = new RelayCommand(CanLogin, Login);
        }

        #region View-Bound Commands&Props

        public RelayCommand LoginCommand { get; set; }

        public string Username
        {
            get => username;
            set
            {
                username = value;
                RaisePropertyChanged(nameof(Username));
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChanged(nameof(Password));
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion View-Bound Commands&Props

        /// <summary>
        /// Initilizes the app
        /// </summary>
        private void Initialize()
        {

        }

        /// <summary>
        /// Checks if we should let the user login - we can if username and pass have been provided
        /// </summary>
        private bool CanLogin(object value)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        /// <summary>
        /// Attempts to log into the drawboard API using <see cref="Username"/> and <see cref="Password"/>
        /// </summary>
        private void Login(object value)
        {
            
        }
    }
}
