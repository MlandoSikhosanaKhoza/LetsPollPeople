using Blazored.LocalStorage;
using Bidvest.Shared.Helpers;
using Bidvest.UI.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;

namespace Bidvest.UI.Auth
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
