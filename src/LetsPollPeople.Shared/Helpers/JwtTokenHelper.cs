using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LetsPollPeople.Shared.Helpers
{
    public class JwtTokenHelper
    {
        //Read a JWT Token
        public static string? GetTokenValue(string JwtToken, string TokenField)
        {
            JwtSecurityToken token = ConvertFromString(JwtToken);
            string? tokenValue     = token.Claims.Where(c => c.Type.Equals(TokenField)).FirstOrDefault()?.Value;
            return tokenValue;
        }

        public static JwtSecurityToken ConvertFromString(string JwtToken)
        {
            JwtSecurityToken token = (JwtSecurityToken)new JwtSecurityTokenHandler().ReadJwtToken(JwtToken);
            return token;
        }

        //Read a JWT Token for context accessor
        public static string? GetTokenValue(IHttpContextAccessor ContextAccessor, string TokenField)
        {
            JwtSecurityToken token = (JwtSecurityToken)new JwtSecurityTokenHandler().ReadJwtToken(ContextAccessor.HttpContext.Request.Headers["Authorization"].ToString());
            string? tokenValue     = token?.Claims.Where(c => c.Type.Equals(TokenField)).FirstOrDefault()?.Value;
            return tokenValue;
        }

        public static JwtSecurityToken WriteToken(string Secret, string ValidIssuer, string ValidAudience, DateTime Expires, IEnumerable<Claim> Claims)
        {
            var authSigningKey     = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
            JwtSecurityToken token = new JwtSecurityToken(
                issuer             : ValidIssuer,
                audience           : ValidAudience,
                expires            : Expires,
                claims             : Claims,
                signingCredentials : new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }

        public static string WriteTokenAsString(string Secret, string ValidIssuer, string ValidAudience, DateTime Expires, IEnumerable<Claim> Claims)
        {
            JwtSecurityToken token = WriteToken(Secret, ValidIssuer, ValidAudience, Expires, Claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
