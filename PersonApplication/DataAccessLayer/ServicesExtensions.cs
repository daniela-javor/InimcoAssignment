using FileContextCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class ServicesExtensions
    {
        public static void AddDataAccessLayerDI(this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseFileContextDatabase());
        }
    }
}
