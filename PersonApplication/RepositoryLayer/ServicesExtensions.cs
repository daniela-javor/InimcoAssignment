using DataAccessLayer.Data;
using Microsoft.Extensions.DependencyInjection;

namespace RepositoryLayer
{
    /// <summary>
    /// Services extensions class for adding repository layer DI.
    /// </summary>
    public static class ServicesExtensions
    {
        /// <summary>
        /// Adds dependency injection for repository layer.
        /// </summary>
        /// <param name="services">Services collection.</param>
        public static void AddRepositoryLayerDI(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
        }
    }
}
