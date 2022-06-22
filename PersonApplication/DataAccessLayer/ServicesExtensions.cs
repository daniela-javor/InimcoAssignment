using DataAccessLayer.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class ServicesExtensions
    {
        public static void AddDataAccessLayerDI(this IServiceCollection services)
        {
            services.AddSingleton<IFileManager<Person>, FileManager<Person>>();
        }
    }
}
