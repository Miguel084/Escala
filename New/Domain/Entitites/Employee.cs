using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitites;

public class Employee : BaseEntity<Guid>
{
    private readonly List<Local> _locals = new List<Local>();
    
    public Employee()
    {
        Id = Guid.NewGuid();
    }

    public required string Name { get; set; }
    
    public List<Local> Locals { get; set; }

    public required string Gender { get; set; }
}
