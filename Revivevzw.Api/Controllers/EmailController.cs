using Microsoft.AspNetCore.Mvc;
using Revivevzw.Business.Services;
using Revivevzw.DataContracts;
using System;
using System.Threading.Tasks;

namespace Revivevzw.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailService mailService;

        public EmailController(IMailService mailService)
        {
            this.mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }

        [HttpPost, Route("send")]
        public async Task<ActionResult> Send(Mail mail)
        {
            await this.mailService.Send(mail);
            return Ok();
        }
    }
}
