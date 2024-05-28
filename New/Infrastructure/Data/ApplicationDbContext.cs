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
        throw new NotImplementedException();
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{

    //    //modelBuilder.Entity<Employee>()
    //    //     .HasKey(x => x.Id);

    //    //modelBuilder.Entity<Local>()
    //    //    .HasKey(x => x.Id);

    //    //modelBuilder.Entity<Employee>()
    //    //    .HasMany(x => x.Unidade)
    //    //    .WithOne(x => x.Employee)
    //    //    .HasForeignKey(x => x.EmployeeId)
    //    //    .IsRequired(false);


    //    base.OnModelCreating(modelBuilder); 
    //}
}
