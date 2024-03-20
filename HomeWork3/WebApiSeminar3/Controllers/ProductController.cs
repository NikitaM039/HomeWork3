using Microsoft.AspNetCore.Mvc;
using Storage.Db;
using WebApiSeminar3.Abstraction;
using WebApiSeminar3.Models.Dto;

namespace WebApiSeminar3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private readonly IProductService _productService;
        private AppDbContext _context;

        public ProductController(IProductService productService, AppDbContext context)
        {
            _productService = productService;
            _context = context;
        }

        [HttpGet(template: "GetProducts")]
        public IEnumerable<ProductDto> GetProducts()
        {
            var result = _productService.GetProducts();
            return result;
        }
    }
}