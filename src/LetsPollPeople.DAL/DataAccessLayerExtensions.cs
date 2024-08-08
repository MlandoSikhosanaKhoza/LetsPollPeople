using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPollPeople.DAL
{
    public static class DataAccessLayerExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
