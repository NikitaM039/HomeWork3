using Autofac.Extensions.DependencyInjection;
using Autofac;
using Storage.Abstractions;
using Storage.Mapper;
using Storage.Services;
using Storage.Db;
using Storage.Query;
using Storage.Mutation;

namespace Storage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Add services to the container.

            builder.Services.AddTransient<IStorageService, StorageService>();
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(cb =>
            {
                cb.Register(c => new AppDbContext(builder.Configuration.GetConnectionString("db"))).InstancePerDependency();
            });


            builder.Services.AddGraphQLServer()
                .AddQueryType<MyQuery>()
                .AddMutationType<MyMatation>();

            builder.Services.AddSingleton<AppDbContext>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapGraphQL();

            app.Run();
        }
    }
}