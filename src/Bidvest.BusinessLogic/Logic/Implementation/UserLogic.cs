using Bidvest.DAL;
using Bidvest.DAL.Entities;
using Bidvest.Shared.Models;
using Bidvest.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Bidvest.Shared.Helpers;
using AutoMapper;

namespace Bidvest.BusinessLogic
{
    public class  UserLogic : IUserLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration  _configuration;
        private readonly IMapper _mapper;

        public UserLogic(IUserRepository userRepository, IConfiguration configuration, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _configuration  = configuration;
            _mapper         = mapper;
            _unitOfWork     = unitOfWork;
        }

        /// <summary>
        /// Verifies the users username and password
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public LoginResult Login(LoginModel loginModel)
        {
            //Initialize result
            LoginResult result = new LoginResult();
            
            //Find the user by the username and password inside login model
            User? user = _userRepository.GetByLogin(loginModel);

            //Check that the username and password exist
            if (user != null)
            {
                //Add User claims
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier,user.Username));
                claims.Add(new Claim(ClaimTypes.Name,user.FirstName));
                claims.Add(new Claim(ClaimTypes.Surname,user.LastName));
                claims.AddRange(user.UserRoles.Select(ur => new Claim(ClaimTypes.Role, ur.Role.RoleName)));

                result.IsAuthenticated    = true;
                result.JwtToken           = JwtTokenHelper.WriteTokenAsString(_configuration["JWT:Secret"] ??"", _configuration["JWT:ValidIssuer"] ??"", _configuration["JWT:ValidAudience"] ??"", DateTime.UtcNow.AddDays(7), claims);
            }
            return result;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _userRepository.GetAll().Select(_mapper.Map<UserModel>);
        }

        /// <summary>
        /// Add new user to database
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public RegisterResult Register(UserModel userModel)
        {
            //Initialize result
            RegisterResult result = new RegisterResult();

            //Incase the user tries to bypass authorization with the API
            if (!_userRepository.ExistByUsername(userModel.Username))
            {
                //Encrypt the users password
                userModel.Password = Sha256Helper.WriteSha256AsString(userModel.Password , userModel.Username.ToLower());

                //Add the user
                User user =_userRepository.Insert(_mapper.Map<User>(userModel));

                //Persist the insert
                _unitOfWork.SaveChanges();

                //Add the user roles
                user.UserRoles.Add(new UserRole { UserId = user.UserId, RoleId = 2 });
                _userRepository.Update(user);

                _unitOfWork.SaveChanges();

                //The user is added to the system - Mark the user as registered
                result.IsRegistered = true;
            }
            else
            {
                result.ErrorMessages.Add("Username already exists.");
            }
            return result;
        }
    }
}
