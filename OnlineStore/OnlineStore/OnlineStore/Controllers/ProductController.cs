using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Interfaces;
using OnlineStore.ViewModels.Models;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost("/addProduct")]
        public ActionResult AddProduct(ProductViewModel product)
        {
            var newProduct = productService.InsertProduct(product);
            return Created("api/v1/user/login", newProduct);
        }
    }
}
