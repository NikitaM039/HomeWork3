using AutoMapper;
using Storage.Dto;
using Storage.Models;
using WebApiSeminar3.Models;
using WebApiSeminar3.Models.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiSeminar3.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
            CreateMap<StorageEntity, StorageDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
        }
    }
}