using HogwartsCore.Services;
using HogwartsInfrastructure.Data;
using HogwartsInfrastructure.Data.Seeder;
using HogwartsInfrastructure.Logger;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsInfrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection InitializerInfrastructure(this IServiceCollection services) =>
                services.AddTransient<HogwartsContext>()
                .AddTransient(typeof(IAppLogger<>), typeof(AppLogger<>))
                .AddTransient<ISeeder, Seeder>();
    }
}
