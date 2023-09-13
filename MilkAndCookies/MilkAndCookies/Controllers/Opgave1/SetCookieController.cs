using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers.Opgave1
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetCookieController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> SetCookie([FromQuery] string TaskECookie)
        {
            Response.Cookies.Append("TaskECookie", TaskECookie);
            return Ok($"Cookie {TaskECookie}");
        }
    }
}
