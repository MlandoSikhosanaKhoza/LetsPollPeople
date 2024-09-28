using MeetingMinutes.BusinessLogic;
using MeetingMinutes.Shared.Models;
using MeetingMinutes.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MeetingMinutes.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller][action]")]
    [ApiController]
    public class PollsController : ControllerBase
    {
        private readonly IPollLogic _pollLogic;

        public PollsController(IPollLogic pollLogic)
        {
            _pollLogic = pollLogic;
        }

        /// <summary>
        /// Get Questions By Id
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(QuestionModel))]
        public IActionResult _GetQuestionById(int questionId)
        {
            return Ok(_pollLogic.GetQuestionById(questionId));
        }

        /// <summary>
        /// Vote for option
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("text/plain",Type = typeof(string))]
        public IActionResult _Vote(int questionId,int optionId)
        {
            _pollLogic.Vote(questionId, optionId);
            return Ok();
        }

        /// <summary>
        /// Get all polling questions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<QuestionModel>))]
        public IActionResult _GetQuestions()
        {
            return Ok(_pollLogic.GetQuestions());
        }

        /// <summary>
        /// Add new polling question
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json", Type = typeof(QuestionModel))]
        public IActionResult _CreateQuestion(QuestionModel questionModel)
        {
            if(ModelState.IsValid)
            {
                return Ok(_pollLogic.CreateQuestion(questionModel));
            }
            return BadRequest(ModelState);
        }
    }
}
