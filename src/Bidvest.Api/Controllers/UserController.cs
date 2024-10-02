using Bidvest.BusinessLogic;
using Bidvest.Shared;
using Bidvest.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bidvest.Api.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        /// <summary>
        /// Authenticate the user
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json",Type=typeof(LoginResult))]
        public IActionResult _Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                return Ok(_userLogic.Login(loginModel));
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Add a new user to the database
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json",Type = typeof(RegisterResult))]
        public IActionResult _Register(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                return Ok(_userLogic.Register(userModel));
            }
            return BadRequest(ModelState);
        }
    }
}
