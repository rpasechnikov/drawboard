using drawboard.ApiModels;
using drawboard.Views;
using Newtonsoft.Json;
using System.Collections;
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
                    // Error
                }
                else
                {
                    var authLoginResponseContent = 
                        JsonConvert.DeserializeObject<IEnumerable<Project>>(
                            await loginResult.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
