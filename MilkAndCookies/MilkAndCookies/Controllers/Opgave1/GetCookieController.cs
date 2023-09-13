using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers.Opgave1
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCookieController : ControllerBase
    {
        [HttpGet("GetCookie")]
        public ActionResult<string> GetCookie()
        {
            // Retrieve the favorite milkshake from the cookie
            string? TaskECookie = Request.Cookies["TaskECookie"];

            if (TaskECookie != null)
            {
                return Ok($"Din cookie er: {TaskECookie}");
            }
            else
            {
                return NotFound("Ingen cookie blev fundet.");
            }
        }
    }
}
