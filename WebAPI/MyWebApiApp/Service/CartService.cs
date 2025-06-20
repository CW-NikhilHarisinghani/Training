using Microsoft.AspNetCore.Mvc;
using Model.Cart;
using Model.Product;
using Service.PaymentService;
using Model.ICart;
using Service.IPaymentService;
[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private ICart inventory;
    private IPaymentService paymentService;
    public CartController(ICart cart, IPaymentService _payment)
    {
        inventory = cart;
        paymentService = _payment;
    }
    [HttpPost("AddProductToCart")]
    public IActionResult AddProductToCart(string key, Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "Product cannot be null.");
        }
        bool setKey = false;
        if (string.IsNullOrEmpty(key))
        {
            setKey = true;
            key = CreateSession().ToString();
        }
        Response.Headers.Add("Session-Key", key);
        inventory.AddProductToCart(key, product);
        return Ok(new { SessionKey = key, Message = "Product added to cart successfully." });
    }

    internal Guid CreateSession()
    {
        return Guid.NewGuid();
    }

    [HttpGet("GetProducts")]
    public List<Product> GetProducts(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Session key cannot be null or empty.", nameof(key));
        }
        return inventory.GetProducts(key);
    }

    [HttpPost("Checkout")]
    public IActionResult Checkout(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return BadRequest("Session key cannot be null or empty.");
        }

        var products = inventory.GetProducts(key);
        if (products == null || products.Count == 0)
        {
            return NotFound("No products found in the cart.");
        }

        try
        {
            int amount = (int)inventory.calculateTotal(key);
            var paymentResult = paymentService.ProcessPayment(amount);
            return Ok("Checkout successful.");
        } catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing the payment: " + ex.Message);
        }
    }

}