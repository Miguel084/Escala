using Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Application;

public static class DepdendencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
        {
            cfg.AutoRegisterRequestProcessors = true;
            cfg.RegisterServicesFromAssemblies(typeof(DepdendencyInjection).Assembly);
        });

        //var cfg = configuration.GetSection(ExternalServicesOptions.Section);


     


        return services;
    }
}
