﻿using Microsoft.Extensions.DependencyInjection;
using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository;
using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Create;
using PMI.Hospital.Infrastructure.Persistence.People.Repository;
using PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Create;
using PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Fetch;
using PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Remove;
using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Fetch;
using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Remove;
using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Update;

namespace PMI.Hospital.Infrastructure.Persistence
{
    /// <summary>
    /// Provided extensions to service collection for people persistence layer.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services to work with entities.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>The new service collection.</returns>
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<IPersonFetcher, PersonFetcher>()
                .AddScoped<IPersonCreator, PersonCreator>()
                .AddScoped<IPersonRemover, PersonRemover>()
                .AddScoped<IPersonRepository, PersonRepository>()

                .AddScoped<IChildrenWardPatientCreator, ChildrenWardPatientCreator>()
                .AddScoped<IChildrenWardPatientUpdater, ChildrenWardPatientUpdater>()
                .AddScoped<IChildrenWardPatientFetcher, ChildrenWardPatientFetcher>()
                .AddScoped<IChildrenWardPatientRemover, ChildrenWardPatientRemover>()
                .AddScoped<IChildrenWardPatientRepository, ChildrenWardPatientRepository>();
        }
    }
}
