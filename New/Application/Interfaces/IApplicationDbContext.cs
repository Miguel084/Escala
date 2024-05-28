using Domain.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{

    DbSet<Employee> Employees { get; set; }

    DbSet<Domain.Entitites.Local> Locals { get; set; }

    Task<int> SaveChanges(CancellationToken cancellationToken);
    int SaveChanges();

}
