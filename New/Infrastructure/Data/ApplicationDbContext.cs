using Application.Interfaces;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : DbContext(option), IApplicationDbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Local> Locals { get; set; }

    public Task<int> SaveChanges(CancellationToken cancellationToken)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Locals)
            .WithOne()
            .Metadata.PrincipalToDependent?.SetField("_locals");

        base.OnModelCreating(modelBuilder);
    }
}
