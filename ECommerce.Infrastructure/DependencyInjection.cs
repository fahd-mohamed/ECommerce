using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Collections;
using ECommerce.Infrastructure.Persistencs.DbContexts;
using ECommerce.Infrastructure.Persistencs.Seeding;
using ECommerce.Domain.UnitOfWork;
using ECommerce.Infrastructure.UnitOfWorks;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Repositories;

namespace ECommerce.Infrastructure;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration config)
    {
        services.AddDbContext<StoreDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                   .EnableSensitiveDataLogging();
        });

        services.AddScoped<IDdataSeeder, ProductBrandSeeder>();
        services.AddScoped<IDdataSeeder, ProductTypeSeeder>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork,UnitOfWork>();

        return services;
    }
}
