using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers.Opgave1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteCookiesController : ControllerBase
    {
        [HttpGet("DeleteCookie")] // Create a new route for deleting the cookie
        public IActionResult DeleteCookie()
        {
            // Delete the "favoriteMilkshake" cookie by setting its expiration date in the past
            Response.Cookies.Delete("favoriteMilkshake");
            Response.Cookies.Delete("TaskECookie");

            return Ok("Cookies deleted successfully");
        }
    }
}
