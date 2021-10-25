using Microsoft.Extensions.DependencyInjection;
using SE214L22.Contract.Services;
using SE214L22.Core.Services;

namespace SE214L22.DI
{
    internal static class ServiceRegisters
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.Scan(scan =>
                scan.FromAssemblies(typeof(BaseService).Assembly)
                    .AddClasses(classes => classes.AssignableTo<IBaseService>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime()
            );
        }
    }
}
