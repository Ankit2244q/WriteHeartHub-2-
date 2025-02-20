using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Application.Services;

namespace Application.DI
{
    public static class Dependencies
    {
        public static IServiceCollection ApplicationLayerDI(this IServiceCollection service)
        {
            service.AddScoped<IUserContentService, UserContentService>();
            return service;
        }
    }
}
