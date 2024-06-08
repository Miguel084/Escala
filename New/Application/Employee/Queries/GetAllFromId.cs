// Arquivo: Application/Employee/Queries/GetAll.cs
using Application.Interfaces;
using Application.Employee.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Employee.Queries;

public record GetAllFromIdQuery(Guid Id) : IRequest<IEnumerable<EmployeeDto>>;
public class GetAllFromId : IRequestHandler<GetAllFromIdQuery, IEnumerable<EmployeeDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetAllFromId(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<IEnumerable<EmployeeDto>> Handle(GetAllFromIdQuery request, CancellationToken cancellationToken)
    {
        var employees = await _dbContext.Employees
            .Include(e => e.Locals)
            .Select(e => new EmployeeDto(
                e.Id,
                e.Name,
                e.Gender,
                e.Locals.Select(l => new LocalDto(l.Id, l.Nome)).ToList()))
            .ToListAsync(cancellationToken);
        
        return employees;
    }
}