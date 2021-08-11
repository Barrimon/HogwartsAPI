using HogwartsCore.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsCore.Extensions
{
    public static class CoreExtension
    {
        public static IServiceCollection InitializerCore(this IServiceCollection services) =>
                services.AddTransient<IApplicationForIncomeService, ApplicationForIncomeService>()
                        .AddTransient<IFraternityService, FraternityService>();

    }
}
