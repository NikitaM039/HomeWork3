using Microsoft.EntityFrameworkCore;
using Storage.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Storage.Db
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;
        public AppDbContext()
        {

        }

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        /*
         dotnet ef migrations add InitialCreate --context AppDbContext
         dotnet ef database update
        */
        public DbSet<StorageEntity> Storages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies().UseNpgsql(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StorageEntity>(entity =>
            {
                entity.HasKey(x => x.Id).HasName("pkey");
                entity.ToTable("storagesProduct");

                entity.Property(e => e.ProductId).HasColumnName("ProductId");
                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsRequired();


            });
        }
    }
}