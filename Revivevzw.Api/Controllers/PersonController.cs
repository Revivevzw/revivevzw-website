using Microsoft.AspNetCore.Mvc;
using Revivevzw.Business.Services;
using Revivevzw.DataContracts;
using System;

namespace Revivevzw.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

        [HttpPost, Route("subscribe")]
        public void Subscribe(SubscribeRequest request)
        {
            this.personService.Subscribe(request);
        }
    }
}
