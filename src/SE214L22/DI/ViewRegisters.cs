using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace SE214L22.DI
{
    internal static class ViewRegisters
    {
        public static void RegisterViews(this IServiceCollection services)
        {
            //services.Scan(scan => {
            //    scan.FromAssemblies(typeof(ViewRegisters).Assembly)
            //        .AddClasses(classes => classes.AssignableTo<Window>())
            //        .AsSelf()
            //        .WithSingletonLifetime();

            //    scan.FromAssemblies(typeof(ViewRegisters).Assembly)
            //        .AddClasses(classes => classes.AssignableTo<UserControl>())
            //        .AsSelf()
            //        .WithSingletonLifetime();
            //});
        }
    }
}
