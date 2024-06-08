using Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Local.Commands;


public record CadastrarLocalCommand(string Nome, Guid EmployeeId) : IRequest<int>;

public class CadastrarLocal : IRequestHandler<CadastrarLocalCommand, int>
{
    private readonly ILogger<CadastrarLocal> _logger;
    private readonly IApplicationDbContext _dbContext;

    public CadastrarLocal(ILogger<CadastrarLocal> logger, IApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CadastrarLocalCommand request, CancellationToken cancellationToken)
    {

        var employeeExists = _dbContext.Employees.Any(e => e.Id == request.EmployeeId);


        var local = new Domain.Entitites.Local
        {
            Nome = request.Nome,
            EmployeeId = request.EmployeeId
        };

        await _dbContext.Locals.AddAsync(local, cancellationToken);

        return await _dbContext.SaveChanges(cancellationToken);
    }

}


