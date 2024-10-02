using Bidvest.BusinessLogic;
using Bidvest.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bidvest.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller][action]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingLogic _meetingLogic;

        public MeetingController(IMeetingLogic meetingLogic)
        {
            _meetingLogic = meetingLogic;
        }

        /// <summary>
        /// Create new meeting
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json",Type = typeof(MeetingModel))]
        public IActionResult _Create(MeetingModel model)
        {
            if(ModelState.IsValid)
            {
                MeetingModel addedMeetingModel = _meetingLogic.Create(model);
                return Ok(addedMeetingModel);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update a meeting
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json", Type = typeof(MeetingModel))]
        public IActionResult _Update(MeetingModel model)
        {
            if (ModelState.IsValid)
            {
                MeetingModel updatedMeetingModel = _meetingLogic.Update(model);
                return Ok(updatedMeetingModel);
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete a meeting
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(MeetingModel))]
        public IActionResult _Delete(int meetingId)
        {
            return Ok(_meetingLogic.Delete(meetingId));
        }

        /// <summary>
        /// Get all meetings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<MeetingModel>))]
        public IActionResult _GetAll()
        {
            return Ok(_meetingLogic.GetAll());
        }

        /// <summary>
        /// Get meeting by id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(MeetingModel))]
        public IActionResult _Get(int id)
        {
            MeetingModel meetingModel = _meetingLogic.GetById(id);
            return Ok(meetingModel);
        }
    }
}
