using Blazored.LocalStorage;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LetsPollPeople.UI.Services
{
    public class HttpClientService
    {
        private HttpClient _httpClient = new HttpClient();
        private readonly ILocalStorageService _localStorage;
        public HttpClientService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<HttpClient> GetPollApiClient()
        {
            
            _httpClient.BaseAddress = new Uri(AppSettingConstants.ApiUrl);
            
            string login_token = await _localStorage.GetItemAsStringAsync("login_token")??"";

            if (!string.IsNullOrEmpty(login_token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login_token);
            }

            return _httpClient;
        }
    }
}
