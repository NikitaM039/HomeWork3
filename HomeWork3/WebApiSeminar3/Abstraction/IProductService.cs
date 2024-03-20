using WebApiSeminar3.Models.Dto;

namespace WebApiSeminar3.Abstraction
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();
        int AddProduct(ProductDto product);
    }
}