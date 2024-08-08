using LetsPollPeople.DAL.Entities;
using LetsPollPeople.DAL.Repository;
using LetsPollPeople.Shared;
using LetsPollPeople.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace LetsPollPeople.DAL
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Find User with a username and password
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public User? GetByLogin(LoginModel loginModel)
        {
            string hashedPassword = Sha256Helper.WriteSha256AsString(loginModel.Password);
            return 
                _dbSet
                .Include(u=>u.UserRole).ThenInclude(u=>u.Role)
                .FirstOrDefault(u => u.Username.ToLower() == loginModel.Username.ToLower()
                    && u.Password == hashedPassword);
        }

        /// <summary>
        /// Find if user exists by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool ExistByUsername(string username)
        {
            return _dbSet.Any(u=> u.Username.ToLower() == username.ToLower());
        }
    }
}
