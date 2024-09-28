using MeetingMinutes.Shared.Models;
using MeetingMinutes.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.BusinessLogic
{
    public interface IUserLogic
    {
        /// <summary>
        /// Authenticate if the user can login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        LoginResult Login(LoginModel loginModel);

        /// <summary>
        /// Register the new user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        RegisterResult Register(UserModel userModel);
    }
}
