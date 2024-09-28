
using Blazored.LocalStorage;
using MeetingMinutes.Shared;
using MeetingMinutes.Shared.Helpers;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace MeetingMinutes.UI.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ILocalStorageService _localStorageService;
        private string Token { get; set; }
        public AuthorizationService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public string GetToken()
        {
            return Token;
        }

        public bool IsValidToken()
        {
            if (!string.IsNullOrEmpty(this.Token))
            {
                JwtSecurityToken jwtSecurityToken = JwtTokenHelper.ConvertFromString(this.Token);
                if (DateTime.UtcNow < jwtSecurityToken.ValidTo)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task ProcessTokenAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(Token))
                {
                    Token = await _localStorageService.GetItemAsStringAsync("login_token") ?? "";
                }
            }
            catch (Exception)
            {

            }

        }

        public async Task SetLoginToken(string Token)
        {
            this.Token = Token;
            try
            {
                await _localStorageService.SetItemAsStringAsync("login_token", Token ?? "");
            }
            catch (Exception)
            {

            }
        }

        public async Task WipePersonalDataAsync()
        {
            await _localStorageService.ClearAsync();
        }
    }
}
