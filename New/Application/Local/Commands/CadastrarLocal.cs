using Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Local.Commands;


public record CadastrarLocalCommand(string Nome) : IRequest<int>;

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

        var local = new Domain.Entitites.Local
        {
            Nome = request.Nome,
        };

        await _dbContext.Locals.AddAsync(local, cancellationToken);

        return _dbContext.SaveChanges();

    }

}


