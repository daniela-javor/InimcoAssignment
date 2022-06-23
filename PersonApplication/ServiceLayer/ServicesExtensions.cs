using Microsoft.Extensions.DependencyInjection;

namespace ServiceLayer
{
    /// <summary>
    /// Services extensions class for adding service layer DI.
    /// </summary>
    public static class ServicesExtensions
    {
        /// <summary>
        /// Adds dependency injection for service layer.
        /// </summary>
        /// <param name="services">Services collection.</param>
        public static void AddServiceLayerDI(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
