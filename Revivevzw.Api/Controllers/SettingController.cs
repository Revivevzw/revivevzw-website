using Microsoft.AspNetCore.Mvc;
using Revivevzw.Business.Services;
using Revivevzw.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revivevzw.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService settingService;
        public SettingController(ISettingService settingService)
        {
            this.settingService = settingService ?? throw new ArgumentNullException(nameof(settingService));
        }

        [HttpGet, Route("{organigram}")]
        public async Task<ActionResult<Settings>> GetOrganigram()
        {
            try
            {
                var organigram = await settingService.GetOrganigramURL();
                var url = organigram.V0;
                return Ok(url);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
    }
}
