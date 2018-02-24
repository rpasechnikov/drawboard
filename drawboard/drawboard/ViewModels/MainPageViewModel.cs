using drawboard.ApiModels;
using drawboard.Misc;
using drawboard.Views;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Windows.Input;

namespace drawboard.ViewModels
{
    /// <summary>
    /// VM for <see cref="MainPage"/>
    /// </summary>
    public class MainPageViewModel : PageViewModelBase
    {
        private string username;
        private string password;
        private bool isErrorMessageVisible;

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

        public bool IsErrorMessageVisible
        {
            get => isErrorMessageVisible;
            set
            {
                isErrorMessageVisible = value;
                RaisePropertyChanged(nameof(IsErrorMessageVisible));
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
        private async void Login(object value)
        {
            using (var httpClient = new HttpClient())
            {
                const string loginFormat = "{{\"username\": \"{0}\", \"password\": \"{1}\"}}";
                var loginString = string.Format(loginFormat, Username, Password);

                var loginResult = await httpClient.PostAsync(
                    $"{App.API_PREFIX}auth/login",
                    new StringContent(loginString, App.API_ENCODING, App.API_MEDIA_TYPE));

                if (loginResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    IsErrorMessageVisible = true;
                }
                else
                {
                    IsErrorMessageVisible = false;

                    var authLoginResponseContent = 
                        JsonConvert.DeserializeObject<AuthLoginResponse>(
                            await loginResult.Content.ReadAsStringAsync());

                    App.AccessToken = authLoginResponseContent.AccessToken;
                    RaiseReadyToNaviageToNextPageChanged(typeof(ViewProjectsPage));
                }
            }
        }
    }
}
