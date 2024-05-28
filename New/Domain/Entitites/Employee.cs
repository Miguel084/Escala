using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitites;

public class Employee : BaseEntity<Guid>
{
    public Employee()
    {
        Id = Guid.NewGuid();
    }

    public required string Name { get; set; }

    [InverseProperty("Employee")]
    public List<Local>? Local { get; set; } 

    public required string Gender { get; set; }
}
