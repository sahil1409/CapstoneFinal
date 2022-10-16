using ABCHealthcare.DataTransferObjects;
using ABCHealthcare.Model;
using ABCHealthcare.Store;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ABCHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly StoreContext _context;

        public CartController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetCart")]
        public async Task<ActionResult<CartDto>> GetCart()
        {
            var cart = await RetrieveCart();

            if (cart == null) return NotFound();
            return MapCartToDto(cart);
        }

        [HttpPost] // api/Cart?medicineId=2&quantity=5
        public async Task<ActionResult<CartDto>> AddItemToCart(int medicineId, int quantity)
        {
            // get cart
            var cart = await RetrieveCart();

            // if cart not there, create one
            if (cart == null) cart = CreateCart();

            // get medicine
            var medicine = await _context.Medicines.FindAsync(medicineId);
            if (medicine == null) return NotFound(); // this case should not arrive as we have proper ID for medicines, still adding for safety

            // add item
            cart.AddItem(medicine, quantity);

            // save changes
            var result = await _context.SaveChangesAsync() > 0; // this method returns an int for number of changes has been made to the DB
            if (result) return CreatedAtRoute("GetCart", MapCartToDto(cart));
            return BadRequest(new ProblemDetails { Title = "Problem saving item to cart" });
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveCartItem(int medicineId, int quantity)
        {
            // get cart
            var cart = await RetrieveCart();
            if (cart == null) return NotFound();

            // remove item or reduce quantity
            cart.RemoveItem(medicineId, quantity);

            // save changes
            var result = await _context.SaveChangesAsync() > 0;
            if (result) return Ok();
            return BadRequest(new ProblemDetails { Title = "Problem removing item from cart" });
        }

        private async Task<Cart> RetrieveCart()
        {
            return await _context.Carts
                .Include(i => i.Items)
                .ThenInclude(m => m.Medicine)
                .FirstOrDefaultAsync(x => x.BuyerId == Request.Cookies["buyerId"]);
        }

        private Cart CreateCart()
        {
            var buyerId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Append("buyerId", buyerId, cookieOptions);
            var cart = new Cart { BuyerId = buyerId };
            _context.Carts.Add(cart);
            return cart;
        }

        private CartDto MapCartToDto(Cart cart)
        {
            return new CartDto
            {
                Id = cart.Id,
                BuyerId = cart.BuyerId,
                Items = cart.Items.Select(item => new CartItemDto
                {
                    MedicineId = item.MedicineId,
                    Name = item.Medicine.Name,
                    Price = item.Medicine.Price,
                    Image = item.Medicine.Image,
                    Seller = item.Medicine.Seller,
                    Description = item.Medicine.Description,
                    Quantity = item.Quantity,
                    Category = item.Medicine.Category
                }).ToList()
            };
        }

    }
}
