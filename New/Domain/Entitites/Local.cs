using Domain.Common;

namespace Domain.Entitites;

public class Local : BaseEntity<Guid>
{
    public Local()
    {
        Id = Guid.NewGuid();
    }

    public string Nome { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
