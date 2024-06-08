using Application.Employee.Dto;
using Application.Interfaces;
using MediatR;

namespace Application.Employee.Command;

public record CriarFuncionarioCommand(string Name, string Gender) : IRequest<int>;
internal class CriarFuncionario : IRequestHandler<CriarFuncionarioCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CriarFuncionario(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CriarFuncionarioCommand request, CancellationToken cancellationToken)
    {
        var func = new Domain.Entitites.Employee
        {
            Gender = request.Gender,
            Name = request.Name,
        };

        await _dbContext.Employees.AddAsync(func, cancellationToken);

        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
