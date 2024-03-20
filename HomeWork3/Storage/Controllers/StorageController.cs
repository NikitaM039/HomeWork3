using Microsoft.AspNetCore.Mvc;
using Storage.Abstractions;
using Storage.Db;
using Storage.Dto;
using StorageApi.Product;
using System;

namespace Storage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController
    {
        private readonly IStorageService _storageService;
        private AppDbContext _context;
        private IProduct _product;

        public StorageController(IStorageService storageService, AppDbContext context, IProduct product)
        {
            _storageService = storageService;
            _context = context;
            _product = product;
        }


        [HttpPost(template: "CreateStorage")]
        public int CreateStorage([FromBody] StorageDto storageDto)
        {
            var result = _storageService.AddStorage(storageDto);
            return storageDto.Id;
        }

        [HttpGet(template: "GetStorages")]
        public IEnumerable<StorageDto> GetStorages()
        {
            var result = _storageService.GetStorages();
            return result;
        }

        [HttpGet(template: "IsAvailable")]
        public Task<bool> IsAvailable(int id)
        {
            var result = _product.IsAvailable(id);
            return result;
        }

    }
}