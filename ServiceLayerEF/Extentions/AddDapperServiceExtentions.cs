using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.EF.CustomerService.Concrete;

namespace ServiceLayerEF.Extentions
{
    public static class AddDapperServiceExtentions
    {
        public static void AddDapperService(this IServiceCollection services)
        {
            services.AddScoped<CustomerServices>();

        }
    }
}
