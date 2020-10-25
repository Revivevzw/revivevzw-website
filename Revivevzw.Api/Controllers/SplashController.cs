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
    public class SplashController : ControllerBase
    {
        private readonly ISplashService splashService;

        public SplashController(ISplashService splashService)
        {
            this.splashService = splashService ?? throw new ArgumentNullException(nameof(splashService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Splash>>> Get()
        {
            try
            {
                var result = await this.splashService.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
