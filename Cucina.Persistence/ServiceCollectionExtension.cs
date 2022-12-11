using Cucina.Application.Interfaces.Account;
using Cucina.Application.Interfaces.Base;
using Cucina.Persistence.Repository.Account;
using Cucina.Persistence.Repository.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Cucina.Persistence
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
