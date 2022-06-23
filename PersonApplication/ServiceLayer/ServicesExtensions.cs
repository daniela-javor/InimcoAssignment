using Microsoft.Extensions.DependencyInjection;

namespace ServiceLayer
{
    public static class ServicesExtensions
    {
        public static void AddServiceLayerDI(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
