using Application.Interfaces;
using Application.Local.Dto;
using MediatR;

namespace Application.Local.Queries;


public record GetAllQuery() : IRequest<IEnumerable<LocalDto>>;
public class GetAll : IRequestHandler<GetAllQuery, IEnumerable<LocalDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetAll(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<LocalDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var locais = _dbContext.Locals.AsEnumerable();

        return await Task.FromResult(locais.Select(x => new LocalDto(x.Id, x.Nome)));
    }
}
