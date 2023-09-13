using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkAndCookies.Models;
using System.Collections.Generic;


namespace MilkAndCookies.Controllers.Opgave2
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingcartController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Product>> AddToCart([FromQuery] string productName, decimal price)
        {
            // Create a new product
            var product = new Product
            {
                Name = productName,
                Price = price
            };

            // Retrieve or create the shopping cart in the session
            var shoppingCart = HttpContext.Session.GetObjectFromJson<List<Product>>("ShoppingCart") ?? new List<Product>();

            // Add the product to the shopping cart
            shoppingCart.Add(product);

            // Store the updated shopping cart in the session
            HttpContext.Session.SetObjectAsJson("ShoppingCart", shoppingCart);

            return Ok(shoppingCart);
        }
    }
}
