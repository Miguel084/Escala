using Application.Interfaces;
using Application.Models;
using Infrastructure.Data;
using Infrastructure.ExternalServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        var conn = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>((sp, option) =>
        {
            option.UseSqlite(conn);
        });

        services.AddScoped<IApplicationDbContext>((provider) =>
        {
            var dbContext = provider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.EnsureCreated();
            return dbContext;
        });



        services.AddHttpClient();
        services.AddHttpClient<ICalendarService,CalendarService>((sp, client) =>
        {
            var config = sp.GetService<IConfiguration>();
            var url = config.GetSection("ExternalServices:CalendarApi");
            client.BaseAddress = new Uri(url.Value);

        });




        return services;

    }
}
