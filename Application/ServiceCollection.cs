using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiceCollection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ServiceCollection).Assembly));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}