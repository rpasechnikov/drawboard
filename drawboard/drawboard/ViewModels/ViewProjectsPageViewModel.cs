using drawboard.ApiModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace drawboard.ViewModels
{
    /// <summary>
    /// VM for <see cref="ViewProjectsPage"/>
    /// </summary>
    public class ViewProjectsPageViewModel : PageViewModelBase
    {
        private bool isErrorMessageVisible;

        /// <summary>
        /// Ctor
        /// </summary>
        public ViewProjectsPageViewModel()
        {
            Initialize();
        }

        /// <summary>
        /// Loads data
        /// </summary>
        public async void Initialize()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        App.AccessToken);

                var loginResult = 
                    await httpClient.GetAsync($"{App.API_PREFIX}project/my?{App.AccessToken}");

                if (loginResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    IsErrorMessageVisible = true;
                }
                else
                {
                    IsErrorMessageVisible = false;
                    var projects = JsonConvert.DeserializeObject<IEnumerable<Project>>(
                                    await loginResult.Content.ReadAsStringAsync());

                    foreach (var project in projects)
                    {
                        Projects.Add(project);
                    }
                }
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

        /// <summary>
        /// Currently using projects directly - may either need to wrap into a VM or extend with INPC
        /// if we decide to add edit capabilities
        /// </summary>
        public ObservableCollection<Project> Projects { get; } = new ObservableCollection<Project>();
    }
}
