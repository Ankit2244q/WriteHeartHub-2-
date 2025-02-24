﻿using Application.DI;
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
        public static IServiceCollection WriteHeartApiDi(this IServiceCollection services)
        {
            services.ApplicationLayerDI().InfrastructureDI();
            return services;
        }
    }
}
