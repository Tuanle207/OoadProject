using Microsoft.Extensions.DependencyInjection;
using SE214L22.Data.Interfaces.Repositories;

namespace SE214L22.DI
{
    internal static class RepositoryRegisters
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.Scan(scan =>
                scan.FromAssemblies(typeof(IBaseRepository<>).Assembly)
                    .AddClasses(classes => classes.AssignableTo(typeof(IBaseRepository<>)))
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime()
            );
        }
    }
}
