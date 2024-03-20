using WebApiSeminar3.Abstraction;
using WebApiSeminar3.Models.Dto;

namespace WebApiSeminar3.Mutation
{
    public class MySimpleMutation
    {
        public int AddProduct(ProductDto product, [Service] IProductService service)
        {
            var id = service.AddProduct(product);
            return id;
        }
    }
}