// Arquivo: Application/Employee/Queries/GetAll.cs
using Application.Interfaces;
using Application.Employee.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Employee.Queries;

    public record GetAllQuery() : IRequest<IEnumerable<EmployeeDto>>;
    public class GetAll : IRequestHandler<GetAllQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetAll(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
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
