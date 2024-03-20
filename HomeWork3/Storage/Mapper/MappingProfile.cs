using AutoMapper;
using Storage.Dto;
using Storage.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Storage.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StorageEntity, StorageDto>().ReverseMap();
        }
    }
}