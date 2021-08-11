using HogwartsCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HogwartsCore.Extensions
{
    public static class CoreExtension
    {
        public static IServiceCollection InitializerCore(this IServiceCollection services) =>
                services.AddTransient<IApplicationForIncomeService, ApplicationForIncomeService>()
                        .AddTransient<IFraternityService, FraternityService>();

    }
}
