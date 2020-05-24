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
    private readonly IActivityService missionService;

    public ActivityController(IActivityService missionService)
    {
      this.missionService = missionService;
    }

    [HttpGet, Route("upcoming")]
    public async Task<ActionResult<ICollection<Activity>>> GetUpcoming()
    {
      try
      {
        var missions = await missionService.GetUpcoming();
        return Ok(missions);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }
  }
}
