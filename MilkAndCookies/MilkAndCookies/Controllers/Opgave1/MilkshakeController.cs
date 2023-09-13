using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers.Opgave1
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilkshakeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> CreateCookie([FromQuery] string favoritemilkshake)
        {
            CookieOptions cookieOptions = new CookieOptions();

            cookieOptions.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Append("favoriteMilkshake", favoritemilkshake);
            return Ok($"Din yndlingsmilkshake er: {favoritemilkshake}");
        }

        [HttpGet("GetFromCookie")]
        public ActionResult<string> GetFromCookie()
        {
            // Retrieve the favorite milkshake from the cookie
            string? favoritemilkshake = Request.Cookies["favoriteMilkshake"];

            if (favoritemilkshake != null)
            {
                return Ok($"Din cookie er: {favoritemilkshake}");
            }
            else
            {
                return NotFound("Ingen cookie blev fundet.");
            }
        }
    }
}
