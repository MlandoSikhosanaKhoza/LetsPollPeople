using Blazored.LocalStorage;
using LetsPollPeople.Shared.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;

namespace LetsPollPeople.UI.Auth
{
    public class BlazorAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public BlazorAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string login_token        = await _localStorageService.GetItemAsStringAsync("login_token") ?? "";
            IEnumerable<Claim> claims = new List<Claim>();

            if (!string.IsNullOrEmpty(login_token))
            {
                JwtSecurityToken securityToken = JwtTokenHelper.ConvertFromString(login_token);
                claims                         = securityToken.Claims;
            }

            ClaimsIdentity claimsIdentity   = new (claims);
            ClaimsPrincipal claimsPrincipal = new (claimsIdentity);

            return new AuthenticationState(claimsPrincipal);
        }
    }
}
