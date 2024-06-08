using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entitites;

public class Local : BaseEntity<Guid>
{
    private readonly List<Local> _locals = new List<Local>();
    
    public Local()
    {
        Id = Guid.NewGuid();
    }
    public string Nome { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }
}   