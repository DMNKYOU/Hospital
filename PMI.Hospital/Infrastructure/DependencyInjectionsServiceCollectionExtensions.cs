using PMI.Hospital.Business.ChildrenWardPatients.Services;
using PMI.Hospital.Business.People.Services;

namespace PMI.Service.PersonalizationHub.Infrastructure.DependencyInjections
{
    /// <summary>
    /// Provides extension methods for <see cref="IServiceCollection"/> for the business layer services.
    /// </summary>
    public static class DependencyInjectionsServiceCollectionExtensions
    {
        /// <summary>
        /// Adds business layer services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        public static void AddBusinessLayerDependencies(
            this IServiceCollection services)
        {
            services
                 .AddScoped<IPersonService, PersonService>()
                 .AddScoped<IChildrenWardPatientService, ChildrenWardPatientService>();
        }
    }
}
