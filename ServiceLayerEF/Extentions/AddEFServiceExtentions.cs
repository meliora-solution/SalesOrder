using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.EF.CustomerService.Concrete;

namespace ServiceLayerEF.Extentions
{
    public static class AddEFServiceExtentions
    {
        public static void AddEFService(this IServiceCollection services)
        {
            services.AddScoped<CustomerServices>();
            services.AddScoped<CustomerServicesMapper>();
        }
    }
}
