using Storage.Abstractions;
using Storage.Dto;

namespace Storage.Mutation
{
    public class MyMatation
    {
        public int AddStorage(StorageDto storage, [Service] IStorageService service)
        {
            var id = service.AddStorage(storage);
            return id;
        }
    }
}