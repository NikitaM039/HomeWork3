using AutoMapper;
using HotChocolate.Utilities;
using Storage.Abstractions;
using Storage.Db;
using Storage.Dto;
using Storage.Models;

namespace Storage.Services
{
    public class StorageService : IStorageService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StorageService(AppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public int AddStorage(StorageDto storage)
        {
            using (_context)
            {
                var entity = _mapper.Map<StorageEntity>(storage);

                _context.Storages.Add(entity);
                _context.SaveChanges();

                return entity.Id;
            }
        }

        public IEnumerable<StorageDto> GetStorages()
        {
            using (_context)
            {
                var storages = _context.Storages.Select(x => _mapper.Map<StorageDto>(x)).ToList();

                return storages;
            }
        }
    }
}