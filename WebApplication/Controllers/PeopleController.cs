using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService service;

        public PeopleController(IPeopleService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.ReadAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Get(string firstName)
        {
            return Ok(await service.ReadByFirstName(firstName));
        }
    }
}
