using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;
using PMI.Hospital.Infrastructure.Persistence;

namespace PMI.Hospital.Infrastructure
{
    /// <summary>
    /// Provides extension methods for <see cref="IServiceCollection"/> for services configuration.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        private const string MsSqlConnection = "MsSql";
        /// <summary>
        /// Adds configuration for the configuration service.
        /// </summary>
        /// <param name="services">The application service collection.</param>
        /// <param name="configuration">The application configuration provider.</param>
        public static void AddPersistenceStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString(MsSqlConnection)))
                .AddPersistenceDependencies();
        }
    }
}
