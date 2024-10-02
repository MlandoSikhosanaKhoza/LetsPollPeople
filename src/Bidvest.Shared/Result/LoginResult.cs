using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidvest.Shared
{
    public class LoginResult
    {
        public bool IsAuthenticated {  get; set; }
        public string? JwtToken {  get; set; }

        public LoginResult() {
            IsAuthenticated = false;
        }
    }
}
