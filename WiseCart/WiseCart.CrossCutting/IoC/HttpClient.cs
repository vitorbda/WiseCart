using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WiseCart.CrossCutting.IoC
{
    public static class HttpClient
    {
        public static IServiceCollection AddHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("CDBApi", client =>
            {
                client.BaseAddress = new Uri(configuration["ServiceUri:CDBApi"] ?? string.Empty);
            });

            return services;
        }
    }
}
