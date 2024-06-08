using Application.Interfaces;
using Application.Local.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
        var locals = await _dbContext.Locals
            .Select(l => new LocalDto(l.Id, l.Nome, l.EmployeeId))
            .ToListAsync(cancellationToken);
        
        if(locals == null)
            throw new Exception("Locals not found"
        );
        
        return locals;
    }
}
