﻿using Storage.Models;
using System.Data.SqlTypes;

namespace WebApiSeminar3.Models
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public uint Cost { get; set; }
        public decimal Price { get; set; }
        public virtual CategoryEntity? Category { get; set; }
        public virtual StorageEntity? Storage { get; set; }
    }
}