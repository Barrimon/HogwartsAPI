using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsAPI.Services
{
    public static class InitializerSwaggerExtension
    {
        public static IServiceCollection InitializerSwagger(this IServiceCollection services) =>
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Hogwarts  API",
                Version = "v1",
                Description = $"Copyright {DateTime.Now.Year} by Ramón Barrios.-"
            });
        });
    }
}
