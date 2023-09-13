using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkAndCookies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkAndCookies.Models;
using System.Collections.Generic;
using System.Linq;

namespace MilkAndCookies.Controllers.Opgave2
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteFromCartController : ControllerBase
    {

        [HttpDelete("{productName}")]
        public ActionResult<IEnumerable<Product>> RemoveFromCart(string productName)
        {
            // Retrieve the shopping cart from the session
            var shoppingCart = HttpContext.Session.GetObjectFromJson<List<Product>>("ShoppingCart") ?? new List<Product>();

            // Find the product in the cart by name and remove it
            Product productToRemove = null;
            foreach (var product in shoppingCart)
            {
                if (product.Name == productName)
                {
                    productToRemove = product;
                    break; // Exit the loop when a matching product is found
                }
            }

            if (productToRemove != null)
            {
                shoppingCart.Remove(productToRemove);
                // Store the updated shopping cart in the session
                HttpContext.Session.SetObjectAsJson("ShoppingCart", shoppingCart);
            }


            return Ok(shoppingCart);
        }

    }

}

