using System;

namespace SE214L22.DI
{
    public class DIContainer
    {
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider ServiceProvider 
        {
            get
            {
                if (_serviceProvider is null)
                {
                     Console.WriteLine("DI Container has not been initialized yet!");
                    return null;
                }
                return _serviceProvider;
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            if (_serviceProvider is null)
            {
                _serviceProvider = serviceProvider;
            }
            else
            {
                Console.WriteLine("DI Container has already been initialized!");
            }
        }
    }
}
