using Blazored.LocalStorage;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Bidvest.UI.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IAuthorizationService _authorizationService;

        public HttpClientService(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        private HttpClient _httpClient = new HttpClient();
        public HttpClient GetPollApiClient()
        {
            
            _httpClient.BaseAddress = new Uri(AppSettingConstants.ApiUrl);

            string login_token = _authorizationService.GetToken();

            if (!string.IsNullOrEmpty(login_token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login_token);
            }

            return _httpClient;
        }
    }
}
