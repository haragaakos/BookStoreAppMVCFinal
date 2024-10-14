using Microsoft.AspNetCore.Mvc;
using BookStoreAppMVC.Utilities;
using System.Security.Claims;

namespace BookStoreAppMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService _shoppingCartService;

        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the current user's ID
            if (string.IsNullOrEmpty(userId))
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Login", "Account");
            }

            await _shoppingCartService.AddToCartAsync(userId, productId, quantity);
            return RedirectToAction("Index", "Home"); // Redirect to home page or shopping cart page
        }

        public async Task<IActionResult> ViewCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var cart = await _shoppingCartService.GetCartAsync(userId);
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            await _shoppingCartService.RemoveFromCartAsync(userId, productId);
            return RedirectToAction(nameof(ViewCart));
        }

        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            await _shoppingCartService.ClearCartAsync(userId);
            return RedirectToAction(nameof(ViewCart));
        }
    }
}