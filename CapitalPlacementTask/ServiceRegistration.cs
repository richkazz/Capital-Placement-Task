using System.Reflection;
using CapitalPlacementTask.Data;
using CapitalPlacementTask.Interfaces;
using CapitalPlacementTask.IRepositories;
using CapitalPlacementTask.Repositories;
using CapitalPlacementTask.Services;
using Microsoft.EntityFrameworkCore;

namespace CapitalPlacementTask
{
    public static class ServiceRegistration

    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            var connectionString = configuration
                            .GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            // Add services to the container.
            var databaseName = configuration
                            .GetSection("Databases")["DefaultDatabase"] ?? throw new InvalidOperationException("Database string 'DefaultDatabase' not found.");

            services.AddDbContext<CapitalPlacementTaskDbContext>(options =>
                options.UseCosmos(connectionString, databaseName));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IProgramDetailRepository, ProgramDetailRepository>();
            services.AddScoped<IProgramDetailService, ProgramDetailService>();
            services.AddScoped<IApplicationFormService, ApplicationFormService>();
            services.AddScoped<IStageService, StageService>();
            return services;
        }
    }
}
