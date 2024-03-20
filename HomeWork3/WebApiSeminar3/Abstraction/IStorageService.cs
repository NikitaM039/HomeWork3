using Storage.Dto;
using WebApiSeminar3.Models.Dto;

namespace WebApiSeminar3.Abstraction
{
    public interface IStorageService
    {
        IEnumerable<StorageDto> GetStorages();
        int AddStorage(StorageDto storage);
    }
}