using Escala.DataBase.DTO;
using Escala.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Escala.DataBase.Data.DbContexts;

public class ApplicationDbContext(IConfiguration configuration) : DbContext
{
    private readonly IConfiguration Configuration = configuration;

    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(Configuration.GetConnectionString("ApplicationDbContext"));
    }

    public DbSet<Employee>? employee { get; set; } = null;
}