using Storage.Abstractions;
using Storage.Dto;

namespace Storage.Query
{
    public class MyQuery
    {
        public IEnumerable<StorageDto> GetStorages([Service] IStorageService service) => service.GetStorages();
    }
}