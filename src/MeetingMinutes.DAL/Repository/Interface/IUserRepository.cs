using MeetingMinutes.DAL.Entities;
using MeetingMinutes.DAL.Repository;
using MeetingMinutes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.DAL
{
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Find User with a username and password
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        User? GetByLogin(LoginModel loginModel);

        /// <summary>
        /// Find if user exists by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        bool ExistByUsername(string username);
    }
}
