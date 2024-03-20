using WebApiSeminar3.Abstraction;
using WebApiSeminar3.Mapper;
using WebApiSeminar3.Query;
using WebApiSeminar3.Services;
using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using WebApiSeminar3.Mutation;

namespace WebApiSeminar3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddMemoryCache();
            builder.Services.AddAutoMapper(typeof(MapperProfile));
            //builder.Services.AddPooledDbContextFactory<AppDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("db")));

            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IStorageService, StorageService>();
            builder.Services.AddTransient<ICategoryService, CategoryService>();
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(cb =>
            {
                cb.Register(c => new AppDbContext(builder.Configuration.GetConnectionString("db"))).InstancePerDependency();
            });
            //builder.Services.AddDbContext<AppDbContext>(conf => conf.UseNpgsql(builder.Configuration.GetConnectionString("db")));


            builder.Services.AddGraphQLServer()
                .AddQueryType<MySimpleQuery>()
                .AddMutationType<MySimpleMutation>();

            builder.Services.AddSingleton<AppDbContext>();

            var app = builder.Build();

            app.MapGraphQL();

            app.Run();
        }
    }
}