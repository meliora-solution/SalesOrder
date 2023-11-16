using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.EF.CustomerService.Concrete;

namespace ServiceLayer.EF.Extentions
{
    public static class AddEFServiceExtentions
    {
        public static void AddEFService(this IServiceCollection services)
        {
            services.AddScoped<CustomerServices>();
        }
    }

}
