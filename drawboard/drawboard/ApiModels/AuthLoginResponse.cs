using System;

namespace drawboard.ApiModels
{
    /// <summary>
    /// Response that will be recieved post POST call to <see cref="App.API_PREFIX"/>auth/login
    /// </summary>
    public class AuthLoginResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string AuthorizationHeader { get; set; }
        public DateTime ExpiresOnUtc { get; set; }
    }
}
