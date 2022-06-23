using DataAccessLayer.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class ServicesExtensions
    {
        
        public static void AddDataAccessLayerDI(this IServiceCollection services, string filePath)
        {
            services.AddSingleton<IFileManager<Person>>(x =>
                ActivatorUtilities.CreateInstance<JsonFileManager<Person>>(x, filePath));
        }
    }
}
