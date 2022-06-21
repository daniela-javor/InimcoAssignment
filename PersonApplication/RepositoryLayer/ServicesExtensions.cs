using DataAccessLayer.Data;
using Microsoft.Extensions.DependencyInjection;

namespace RepositoryLayer
{
    public static class ServicesExtensions
    { 
        public static void AddRepositoryLayerDI(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
        }
    }
}
