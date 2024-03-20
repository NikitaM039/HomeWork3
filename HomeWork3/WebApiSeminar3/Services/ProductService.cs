using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Storage.Db;
using WebApiSeminar3.Abstraction;
using WebApiSeminar3.Models;
using WebApiSeminar3.Models.Dto;

namespace WebApiSeminar3.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public ProductService(AppDbContext context, IMapper mapper, IMemoryCache cache)
        {
            this._context = context;
            this._mapper = mapper;
            this._cache = cache;
        }
        public int AddProduct(ProductDto product)
        {
            using (_context)
            {
                var entity = _mapper.Map<ProductEntity>(product);

                _context.Products.Add(entity);
                _context.SaveChanges();
                _cache.Remove("products");

                return entity.Id;
            }
        }


        public IEnumerable<ProductDto> GetProducts()
        {
            using (_context)
            {
                if (_cache.TryGetValue("products", out List<ProductDto> products))
                    return products;

                products = _context.Products.Select(x => _mapper.Map<ProductDto>(x)).ToList();
                _cache.Set("products", products, TimeSpan.FromMinutes(30));

                return products;
            }
        }
    }
}