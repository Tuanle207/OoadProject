using Microsoft.Extensions.DependencyInjection;
using SE214L22.Core.ViewModels;

namespace SE214L22.DI
{
    internal static class ViewModelsRegisters
    {
        public static void RegisterViewModels(this IServiceCollection services)
        {
            services.Scan(scan =>
                scan.FromAssemblies(typeof(BaseViewModel).Assembly)
                    .AddClasses(classes => classes.AssignableTo<BaseViewModel>())
                    .AsSelf()
                    .WithSingletonLifetime()
            );
        }
    }
}
