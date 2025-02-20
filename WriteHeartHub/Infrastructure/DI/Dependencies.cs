using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DI
{
    public static class Dependencies
    {
        public static IServiceCollection InfrastructureDI(this IServiceCollection service)
        {
            service.AddScoped<IUserContentRepository, UserContentRepository>();
            return service;
        }
    }
}
