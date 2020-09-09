using Microsoft.AspNetCore.Mvc;
using Revivevzw.Business.Services;
using Revivevzw.DataContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revivevzw.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService activityService;

        public ActivityController(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<Activity>> Get(int id)
        {
            try
            {
                var activity = await this.activityService.Get(id);
                return Ok(activity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet, Route("upcoming")]
        public async Task<ActionResult<ICollection<Activity>>> GetUpcoming()
        {
            try
            {
                var activities = await this.activityService.GetUpcoming();
                return Ok(activities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
