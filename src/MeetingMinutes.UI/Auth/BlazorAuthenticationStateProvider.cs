using Blazored.LocalStorage;
using MeetingMinutes.Shared.Helpers;
using MeetingMinutes.UI.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;

namespace MeetingMinutes.UI.Auth
{
    public class BlazorAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthorizationService _authorizationService;
        public BlazorAuthenticationStateProvider(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await _authorizationService.ProcessTokenAsync();
            string login_token        = _authorizationService.GetToken();
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
