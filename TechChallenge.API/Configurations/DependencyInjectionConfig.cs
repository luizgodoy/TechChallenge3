using TechChallenge.Data.Repository;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.Services;


namespace TechChallenge.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IStateService, StateService>();

            return services;
        }
    }
}
