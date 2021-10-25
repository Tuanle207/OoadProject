using Microsoft.Extensions.DependencyInjection;
using SE214L22.Contract.Repositories;
using SE214L22.Data.Repositories;

namespace SE214L22.DI
{
    internal static class RepositoryRegisters
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.Scan(scan =>
                scan.FromAssemblies(typeof(BaseRepository<>).Assembly)
                    .AddClasses(classes => classes.AssignableTo(typeof(IBaseRepository<>)))
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime()
            );
        }
    }
}
