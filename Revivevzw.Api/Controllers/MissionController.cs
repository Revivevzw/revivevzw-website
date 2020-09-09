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
    public class MissionController : ControllerBase
    {
        private readonly IMissionService missionService;

        public MissionController(IMissionService missionService)
        {
            this.missionService = missionService ?? throw new ArgumentNullException(nameof(missionService));
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<Mission>> Get(int id)
        {
            try
            {
                var mission = await this.missionService.Get(id);
                return Ok(mission);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet, Route("all")]
        public async Task<ActionResult<ICollection<Mission>>> GetAll()
        {
            try
            {
                var missions = await this.missionService.Get();
                return Ok(missions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
