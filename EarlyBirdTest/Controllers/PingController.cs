using Microsoft.AspNetCore.Mvc;

namespace EarlyBirdTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("pong");
        }
    }
}
