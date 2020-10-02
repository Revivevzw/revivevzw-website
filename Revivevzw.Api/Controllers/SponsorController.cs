using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Revivevzw.Business.Services;
using Revivevzw.DataContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revivevzw.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("webOriginPolicy")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        private readonly ISponsorService sponsorService;

        public SponsorController(ISponsorService sponsorService)
        {
            this.sponsorService = sponsorService ?? throw new ArgumentNullException(nameof(sponsorService));
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<Sponsor>> Get(int id)
        {
            try
            {
                var model = await this.sponsorService.Get(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet, Route("all")]
        public async Task<ActionResult<IEnumerable<Sponsor>>> GetAll()
        {
            try
            {
                var model = await this.sponsorService.Get();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
