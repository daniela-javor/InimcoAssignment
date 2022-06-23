﻿using DataAccessLayer.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    /// <summary>
    /// Services extensions class for adding data access layer DI.
    /// </summary>
    public static class ServicesExtensions
    {
        /// <summary>
        /// Adds dependency injection for data access layer.
        /// </summary>
        /// <param name="services">Services collection.</param>
        /// <param name="filePath">File path used for storing data.</param>
        public static void AddDataAccessLayerDI(this IServiceCollection services, string filePath)
        {
            services.AddSingleton<IFileManager<Person>>(x =>
                ActivatorUtilities.CreateInstance<JsonFileManager<Person>>(x, filePath));
        }
    }
}
