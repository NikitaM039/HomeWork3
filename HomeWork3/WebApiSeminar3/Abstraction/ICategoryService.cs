using WebApiSeminar3.Models.Dto;

namespace WebApiSeminar3.Abstraction
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetCategories();
        int AddCategory(CategoryDto category);
    }
}