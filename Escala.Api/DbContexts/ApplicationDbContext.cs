using Microsoft.EntityFrameworkCore;

namespace Escala.Api.DbContexts;

public class ApplicationDbContext(IConfiguration configuration) : DbContext
{
    private readonly IConfiguration Configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(Configuration.GetConnectionString("ApplicationDbContext"));
    }
}