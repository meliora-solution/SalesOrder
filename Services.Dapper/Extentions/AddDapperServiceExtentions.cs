using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Dapper.CustomerService.Concrete;

namespace ServiceLayer.Dapper.Extentions
{
    public static class AddDapperServiceExtentions
    {
        public static void AddDapperService(this IServiceCollection services)
        {
            services.AddScoped<CustomerServices>();

        }
    }
}
